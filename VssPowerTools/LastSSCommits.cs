using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VssPowerTools.Properties;

namespace VssPowerTools
{
	public partial class LastSSCommits : Form
	{
		class TimeSpanFilterItem
		{
			readonly string Name;
			public readonly int LastNCommits;
			public TimeSpanFilterItem(int n, string name)
			{
				Name = name;
				LastNCommits = n;
			}

			public override string ToString()
			{
				return Name;
			}
		}

		readonly string _baseDir;

		public LastSSCommits()
		{
			InitializeComponent();

			_baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

			comboBoxTimeFilter.Items.Add(new TimeSpanFilterItem(10, "Last 10 commits"));
			comboBoxTimeFilter.Items.Add(new TimeSpanFilterItem(50, "Last 50 commits"));
			comboBoxTimeFilter.Items.Add(new TimeSpanFilterItem(100, "Last 100 commits"));
			comboBoxTimeFilter.Items.Add(new TimeSpanFilterItem(200, "Last 200 commits"));
			comboBoxTimeFilter.Items.Add(new TimeSpanFilterItem(500, "Last 500 commits"));
			comboBoxTimeFilter.Items.Add(new TimeSpanFilterItem(int.MaxValue, "All"));

			comboBoxTimeFilter.SelectedIndex = 0;
		}

		class CommitInfo
		{
			public string Author;
			public DateTime ParsedCommitTime;
			public string CommitTime;
		}

		enum CommitAction
		{
			Unknown,
			Commit,
			Label,
			Add,
			Share,
			Delete,
			Copy,
			Purge,
			Move,
			Recover,
			Branch,
			Destroy,
			Archived,
			Rollback,
		}

		class CommitAtom
		{
			public CommitInfo Info;
			public string File;
			public int Version = -1;
			public string Comment;
			public CommitAction Action = CommitAction.Unknown;
			// ReSharper disable NotAccessedField.Local
			public string From;
			public string To;
			// ReSharper restore NotAccessedField.Local
		}

		class Commit
		{
			public CommitInfo Info
			{
				get
				{
					return Atoms[0].Info;
				}
			}
			public readonly List<CommitAtom> Atoms = new List<CommitAtom>();
			public List<CommitAtom> FilteredAtoms = new List<CommitAtom>();
		}

		readonly Regex _commitInfoRx = new Regex(@"User:\s+(?<user>[^\s]+)\s+Date:\s+(?<date>[0-9./-]+)\s+Time:\s+(?<time>[0-9:ap]+)");
		readonly Regex _time = new Regex(@"(?<hour>\d+):(?<min>\d+)(a|p)?");
		readonly Regex _date = new Regex(@"(?<p1>\d+)[./-](?<p2>\d+)[./-](?<year>\d+)");

		readonly List<Commit> _commits = new List<Commit>();

		static Func<T, bool> BuildChecker<T>(string pattern, Func<T, string> selector, Func<T, bool> prevPredicate)
		{
			var rawPattern = pattern.TrimStart("|!~".ToCharArray());
			var opts = pattern.Substring(0, pattern.Length - rawPattern.Length);

			Func<T, bool> textMatcher;

			if(opts.Contains('~'))
			{
				var rx = new Regex(rawPattern, RegexOptions.IgnoreCase);
				textMatcher = c => rx.IsMatch(selector(c));
			}
			else
			{
				var startsWith = false;
				var rawTestLwr = rawPattern.ToLowerInvariant();
				if (rawTestLwr.StartsWith("^"))
				{
					rawTestLwr = rawTestLwr.Substring(1);
					startsWith = true;
				}
				textMatcher = c => { var text = selector(c).ToLowerInvariant(); return startsWith ? text.StartsWith(rawTestLwr) : text.Contains(rawTestLwr); };
			}

			if(opts.Contains('!'))
			{
				var oldMatcher = textMatcher;
				textMatcher = c => !oldMatcher(c);
			}

			if (prevPredicate != null)
			{
				if (opts.Contains('|'))
				{
					var oldMatcher = textMatcher;
					textMatcher = c => prevPredicate(c) || oldMatcher(c);
				}
				else
				{
					var oldMatcher = textMatcher;
					textMatcher = c => prevPredicate(c) && oldMatcher(c);
				}
			}

			return textMatcher;
		}

		void FillCommits()
		{
			listViewCommits.Items.Clear();

			var commits = _commits.AsEnumerable();

			// build filter predicate
			Func<Commit, bool> commitPredicate = c => true;

			// author filter
			if (!string.IsNullOrWhiteSpace(textBoxAuthorFilter.Text))
			{
				commitPredicate = BuildChecker<Commit>(
					textBoxAuthorFilter.Text,
					c => c.Info.Author,
					null
				);
			}

			Func<CommitAtom, bool> atomPredicate = c => true;

			// action filter
			if (!string.IsNullOrWhiteSpace(textBoxActionFilter.Text))
			{
				atomPredicate = BuildChecker(
					textBoxActionFilter.Text,
					a => a.Action.ToString(),
					atomPredicate
				);
			}

			// comment filter
			if (!string.IsNullOrWhiteSpace(textBoxComment.Text))
			{
				atomPredicate = BuildChecker(
					textBoxComment.Text,
					a => a.Comment ?? "",
					atomPredicate
				);
			}

			// paths filter
			if (!string.IsNullOrWhiteSpace(textBoxFilePath.Text))
			{
				atomPredicate = BuildChecker(
					textBoxFilePath.Text,
					a => a.File,
					atomPredicate
				);
			}

			// max commits filter
			var filteredCommits = commits
				.Where(commitPredicate)
				.Select(c => {
					c.FilteredAtoms = c.Atoms.Where(atomPredicate).ToList();

					return c;
				})
				.Where(c => c.FilteredAtoms.Count > 0)
			;

			int count;
			var filter = comboBoxTimeFilter.SelectedItem as TimeSpanFilterItem;
			if (filter != null)
			{
				count = filter.LastNCommits;
			}
			else
			{
				if (!Int32.TryParse(comboBoxTimeFilter.Text, out count))
				{
					comboBoxTimeFilter.Text = "10";
					count = 10;
				}
			}

			if(count < Int32.MaxValue)
				filteredCommits = filteredCommits.Reverse().Take(count);

			foreach (var c in filteredCommits)
			{
				var atoms = c.FilteredAtoms;

				var ago = (DateTime.Now - c.Info.ParsedCommitTime);
				var agoS = string.Format("{0:D2} minutes", ago.Minutes);
				if(ago.Hours > 0)
					agoS = string.Format("{0} hours, {1}", ago.Hours, agoS);
				if(ago.Days > 0)
					agoS = string.Format("{0} days, {1}", ago.Days, agoS);
				var grp = new ListViewGroup(c.Info.Author + " (" + agoS + " ago ?)") {
					Tag = c
				};
				listViewCommits.Groups.Add(grp);

				foreach (var atom in atoms)
				{
					var lvi = new ListViewItem(new[] { atom.Info.CommitTime, atom.Info.Author, atom.Action.ToString(), atom.File, atom.Comment });
					lvi.Group = grp;
					lvi.Tag = atom;
					listViewCommits.Items.Add(lvi);
				}
			}
		}

		void AddAtom(IList<Commit> commits, CommitAtom atom)
		{
			if(atom == null)
				return;

			if(commits.Count == 0)
			{
				var commit = new Commit();
				commit.Atoms.Add(atom);
				commits.Add(commit);
				return;
			}

			var last = commits[commits.Count - 1];
			if(last.Info.Author != atom.Info.Author || atom.Info.ParsedCommitTime - last.Info.ParsedCommitTime > TimeSpan.FromMinutes(3))
			{
				last = new Commit();
				commits.Add(last);
			}

			last.Atoms.Add(atom);
		}

		void buttonApply_Click(object sender, EventArgs e)
		{
			FillCommits();
		}

		void Form_KeyUp(object sender, KeyEventArgs e)
		{
			if(e.Control && e.KeyCode == Keys.C)
			{
				CopyPaths();
			}
		}

		void copyPathsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyPaths();
		}

		void CopyPaths()
		{
			var sb = listViewCommits
				.SelectedItems
				.Cast<ListViewItem>()
				.Select(i => i.Tag as CommitAtom)
				.Where(a => a != null)
				.Aggregate(new StringBuilder(), (acc, next) => acc.AppendLine(next.File))
			;

			Clipboard.SetText(sb.ToString());
		}

		void generateFDPToFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var sb = new StringBuilder();

			sb.Append(File.ReadAllText(Path.Combine(_baseDir, "fdp-template.txt")));

			// detect changed sources
			var paths = listViewCommits
				.SelectedItems
				.Cast<ListViewItem>()
				.Select(i => i.Tag as CommitAtom)
				.Where(a => a != null)
				.Aggregate(new StringBuilder(), (acc, next) => acc.AppendLine("\t" + next.File))
				.ToString()
			;

			sb.Replace("$$PATHS$$", paths);

			var path = Path.GetTempFileName();
			var newPath = path + ".fdp.txt";
			File.Move(path, newPath);

			File.WriteAllText(newPath, sb.ToString());

			Process.Start(newPath);
		}

		void buttonLoad_Click(object sender, EventArgs e)
		{
			ReloadCommits();
		}

		void ReloadCommits()
		{
			listViewCommits.Items.Clear();
			_commits.Clear();

			var journal = GetJournalFile(textBoxSS.Text);
			if (journal == null)
				return;

			CommitAtom atom = null;
			var nextAction = false;
			foreach (var line in File.ReadAllLines(journal).Where(l => !string.IsNullOrWhiteSpace(l)))
			{
				if (nextAction)
				{
					// parse action
					if (line == "Checked in")
					{
						atom.Action = CommitAction.Commit;
					}
					else if (line.StartsWith("Labeled"))
					{
						atom.Action = CommitAction.Label;
					}
					else if (line.StartsWith("Rolled back"))
					{
						atom.Action = CommitAction.Rollback;
					}
					else if (line.EndsWith(" added"))
					{
						var fn = line.Substring(0, line.Length - " added".Length);
						atom.File += "/" + fn;
						atom.Action = CommitAction.Add;
					}
					else if (line.EndsWith(" created"))
					{
						var fn = line.Substring(0, line.Length - " created".Length);
						atom.File += "/" + fn;
						atom.Action = CommitAction.Add;
					}
					else if (line.EndsWith(" deleted"))
					{
						var fn = line.Substring(0, line.Length - " deleted".Length);
						atom.File += "/" + fn;
						atom.Action = CommitAction.Delete;
					}
					else if (line.EndsWith(" archived"))
					{
						atom.File += line;
						atom.Action = CommitAction.Archived;
					}
					else if (line.EndsWith(" purged"))
					{
						var fn = line.Substring(0, line.Length - " purged".Length);
						atom.File += "/" + fn;
						atom.Action = CommitAction.Purge;
					}
					else if (line.EndsWith(" destroyed"))
					{
						var fn = line.Substring(0, line.Length - " destroyed".Length);
						atom.File += "/" + fn;
						atom.Action = CommitAction.Destroy;
					}
					else if (line.EndsWith(" recovered"))
					{
						var fn = line.Substring(0, line.Length - " recovered".Length);
						atom.File += "/" + fn;
						atom.Action = CommitAction.Recover;
					}
					else if (line.EndsWith(" branched"))
					{
						var fn = line.Substring(0, line.Length - " branched".Length);
						atom.File += "/" + fn;
						atom.Action = CommitAction.Branch;
					}
					else if (line.Contains(" shared from "))
					{
						var pos = line.IndexOf(" shared from ", StringComparison.Ordinal);
						var fn = line.Substring(0, pos);
						atom.File += "/" + fn;
						atom.Action = CommitAction.Share;
						atom.From = line.Substring(pos + " shared from ".Length);
					}
					else if (line.Contains(" copied from "))
					{
						var pos = line.IndexOf(" copied from ", StringComparison.Ordinal);
						var fn = line.Substring(0, pos);
						atom.File += "/" + fn;
						atom.Action = CommitAction.Copy;
						atom.From = line.Substring(pos + " copied from ".Length);
					}
					else if (line.Contains(" moved to "))
					{
						var pos = line.IndexOf(" moved to ", StringComparison.Ordinal);
						var fn = line.Substring(0, pos);
						atom.File += "/" + fn;
						atom.Action = CommitAction.Move;
						atom.To = line.Substring(pos + " moved to ".Length);
					}
					else if (line.Contains(" renamed to "))
					{
						var pos = line.IndexOf(" renamed to ", StringComparison.Ordinal);
						var fn = line.Substring(0, pos);
						atom.To = atom.File + "/" + line.Substring(pos + " renamed to ".Length);
						atom.File += "/" + fn;
						atom.Action = CommitAction.Move;
					}

					nextAction = false;
					continue;
				}

				if (line.StartsWith("$"))
				{
					// add previous atom
					AddAtom(_commits, atom);

					atom = new CommitAtom {
						Info = new CommitInfo(),
						File = line
					};
					continue;
				}

				if (line.StartsWith("Version: "))
				{
					Int32.TryParse(line.Substring("Version: ".Length), out atom.Version);
					continue;
				}

				if (line.StartsWith("User: "))
				{
					nextAction = true;
					var m = _commitInfoRx.Match(line);
					if (m.Success)
					{
						atom.Info.Author = m.Groups["user"].Value;

						var date = m.Groups["date"].Value;
						var time = m.Groups["time"].Value;

						atom.Info.CommitTime = date + " " + time;

						var year = 0;
						var month = 0;
						var day = 0;
						var hour = 0;
						var min = 0;

						var mt = _time.Match(time);
						if (mt.Success)
						{
							hour = Int32.Parse(mt.Groups["hour"].Value);
							min = Int32.Parse(mt.Groups["min"].Value);
						}

						if (time.EndsWith("p") && hour < 12)
						{
							hour += 12;
						}

						var dm = _date.Match(date);
						if (dm.Success)
						{
							year = 2000 + Int32.Parse(dm.Groups["year"].Value);

							var p1 = Int32.Parse(dm.Groups["p1"].Value);
							var p2 = Int32.Parse(dm.Groups["p2"].Value);

							if (time.EndsWith("p") || time.EndsWith("a"))
							{
								month = p1;
								day = p2;
							}
							else
							{
								month = p2;
								day = p1;
							}

							if (month > 12)
							{
								int t = day;
								day = month;
								month = t;
							}
						}

						atom.Info.ParsedCommitTime = new DateTime(year, month, day, hour, min, 0);
					}
					continue;
				}

				if (line.StartsWith("Comment: "))
				{
					atom.Comment = line.Substring("Comment: ".Length);
					continue;
				}
				atom.Comment += line;
			}
			// add last parsed atom
			AddAtom(_commits, atom);

			FillCommits();

			Settings.Default.Save();
		}

		string GetJournalFile(string vss)
		{
			var theirsSsIni = vss;
			if (Directory.Exists(theirsSsIni))
			{
				theirsSsIni = Path.Combine(theirsSsIni, "srcsafe.ini");

				if (!File.Exists(theirsSsIni))
				{
					MessageBox.Show("srcsafe.ini not found in " + vss);
					return null;
				}
			}

			if (Path.GetFileName(theirsSsIni).ToLowerInvariant() != "srcsafe.ini")
			{
				MessageBox.Show("Should be specified VSS dir or scrsafe.ini path");
				return null;
			}

			// find journal file:
			var journalFilePath = File.ReadAllLines(theirsSsIni)
				.Select(l => l.Trim().ToLowerInvariant())
				.Where(l => l.StartsWith("journal_file"))
				.Select(l => l.Substring(l.IndexOf('=') + 1).Trim())
				.FirstOrDefault()
			;

			if (journalFilePath == null)
			{
				MessageBox.Show("Should not detect journal file path");
				return null;
			}

			if (!File.Exists(journalFilePath))
			{
				MessageBox.Show("Journal file not found: " + journalFilePath);
				return null;
			}

			return journalFilePath;
		}

		private void LastSSCommits_Load(object sender, EventArgs e)
		{
			ReloadCommits();
		}

		void blameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var selected = listViewCommits
				.SelectedItems
				.Cast<ListViewItem>()
				.Select(i => i.Tag as CommitAtom)
				.Where(a => a != null)
				.ToArray()
			;

			if(selected.Length != 1)
			{
				MessageBox.Show("Select exactly one item", "Error");
				return;
			}

			var commit = selected[0];

			if(commit.Action == CommitAction.Delete || commit.Action == CommitAction.Destroy)
			{
				MessageBox.Show("Can't show blame for deleted files", "Error");
				return;
			}

			new VssBame(textBoxSS.Text.TrimEnd('\\', '/'), commit.File).ShowDialog();
		}

		void ShowUnifiedDiffToolStripMenuItemClick(object sender, EventArgs e)
		{
			var selected = listViewCommits
				.SelectedItems
				.Cast<ListViewItem>()
				.Select(i => i.Tag as CommitAtom)
				.Where(a => a != null)
				.ToArray()
			;

			if(selected.Length != 1)
			{
				MessageBox.Show("Select exactly one item", "Error");
				return;
			}

			var commit = selected[0];

			if(commit.Action != CommitAction.Commit)
			{
				MessageBox.Show("Can show diff only for commit action", "Error");
				return;
			}

			var outFile = Path.Combine(
				Path.GetTempPath(),
				string.Format(
					"tgd-{0}.{1}.{2}-{3}.patch",
					DateTime.Now.Ticks,
					Path.GetFileName(commit.File.Trim('$')),
					commit.Version - 1,
					commit.Version
				)
			);

			try
			{
				new CreatePatch().Create(textBoxSS.Text.TrimEnd('\\', '/'),
					commit.File,
					commit.Version - 1,
					commit.Version,
					outFile,
					false)
				;

				Process
					.Start(outFile)
					.WaitForExit()
				;
			}
			finally
			{
				if (File.Exists(outFile))
					File.Delete(outFile);
			}
		}

		void CreatePatchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var selected = listViewCommits
				.SelectedItems
				.Cast<ListViewItem>()
				.Select(i => i.Tag as CommitAtom)
				.Where(a => a != null)
				.ToArray()
			;

			if(selected.Any(a => a.Action != CommitAction.Commit))
			{
				MessageBox.Show("Can create patch only for commit action.", "Error");
				return;
			}

			var outputDir = Path.Combine(_baseDir, DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture));
			Directory.CreateDirectory(outputDir);

			foreach (var commit in selected)
			{
				var file = commit.File.Trim('$');

				var outFile = string.Format("{0}.{1}.patch", Path.GetFileName(file), commit.Version);

				new CreatePatch().Create(
					textBoxSS.Text.TrimEnd('\\', '/'),
					commit.File,
					commit.Version - 1,
					commit.Version,
					Path.Combine(outputDir, outFile),
					false)
				;
			}

			Process.Start(outputDir);
		}

		PatchQueueForm _patchPad;

		void EnsurePatchPadHere()
		{
			if(_patchPad != null)
				return;

			_patchPad = new PatchQueueForm(textBoxSS.Text.TrimEnd('\\', '/'));
			_patchPad.Closed += (s, e) => {
				_patchPad = null;
			};
			_patchPad.Show();
		}

		void QueuePatches(bool toLatest)
		{
			EnsurePatchPadHere();

			var selected = listViewCommits
				.SelectedItems
				.Cast<ListViewItem>()
				.Select(i => i.Tag as CommitAtom)
				.Where(a => a != null)
				.ToList()
				;

			if (selected.Any(a => a.Action != CommitAction.Commit))
			{
				MessageBox.Show("Can create patch only for commit action.", "Error");
				return;
			}

			selected.ForEach(
				c => _patchPad.AddPatch(c.File, c.Version - 1, toLatest ? -1 : c.Version)
			);
		}

		private void QueuePatchToolStripMenuItemClick(object sender, EventArgs e)
		{
			QueuePatches(false);
		}

		private void QueuePatchToLatestToolStripMenuItemClick(object sender, EventArgs e)
		{
			QueuePatches(true);
		}

		void CSV2ClipboardToolStripMenuItemClick(object sender, EventArgs e)
		{
			var index = 0;
			var selected = listViewCommits
				.SelectedItems
				.Cast<ListViewItem>()
				.Select(i => i.Tag as CommitAtom)
				.Where(a => a != null)
				.Select(a => FormatCSVLine(index++, a))
				.ToArray()
			;

			var csv = string.Join("\n", selected);

			Clipboard.SetText(csv);
		}

		const char CSVSeparator = '\t';

		string FormatCSVLine(int index, CommitAtom a)
		{
			return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}",
				index,
				CSVSeparator,
				a.Info.Author,
				CSVSeparator,
				a.Info.CommitTime,
				CSVSeparator,
				a.Action,
				CSVSeparator,
				a.File,
				CSVSeparator,
				a.Version
			);
		}
	}
}
