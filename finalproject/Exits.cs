/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
    using System.Collections.Generic;
	class Exits {
		private static Dictionary<string, string> directionLongs = new Dictionary<string, string>() {
			{"nw", "to the northwest"},
			{"ne", "to the northeast"},
			{"sw", "to the southwest"},
			{"se", "to the southeast"},
			{"n", "to the north"},
			{"s", "to the south"},
			{"w", "to the west"},
			{"e", "to the east"},

			{"r", "to the right"},
			{"l", "to the left"},
			{"u", "upwards"},
			{"d", "downwards"},
		};

		private Dictionary<string, Room> exits;
		private Dictionary<string, string> exitMethod;
		private Dictionary<string, List<string>> exitGroups;
		private Dictionary<string, string> exitVerbose;
		private Dictionary<string, bool> lockedExit;

		public bool HasExit (string shortDir) {
			return this.exits.ContainsKey(shortDir);
		}

		public Room GetExit (string shortDir) {
			Room ex;
			if (this.exits.TryGetValue(shortDir, out ex)) {
				return ex;
			}
			return null;
		}

		public void AddExit (string dir, Room dest) {
			this.AddExit(dir, "exit", null, dest);
		}

		public void AddExit (string dir, string method, Room dest) {
			this.AddExit(dir, method, null, dest);
		}

		public void AddExit (string dir, string method, string verbose, Room dest) {

			// create structures if they don't exist
			if (this.exits == null) {
				this.exits = new Dictionary<string, Room>();
			}
			if (this.exitMethod == null) {
				this.exitMethod = new Dictionary<string, string>();
			}

			// associate exit, direction and method
			this.exits.Add(dir, dest);
			this.exitMethod.Add(dir, method);

			// add grouping by method for pretty English
			if (verbose != null) {
				if (this.exitVerbose == null) {
					this.exitVerbose = new Dictionary<string, string>();
				}
				this.exitVerbose.Add(dir, verbose);
			} else {
				if (this.exitGroups == null) {
					this.exitGroups = new Dictionary<string, List<string>>();
				}
				// similar exits
				List<string> similarExits;
				if (this.exitGroups.TryGetValue(method, out similarExits)) {
					similarExits.Add(dir);
				} else {
					similarExits = new List<string>() {
						dir
					};
					this.exitGroups.Add(method, similarExits);
				}
			}
		}

		public bool ExitIsLocked (string shortDir) {
			if (this.lockedExit == null) return false;

			bool state;
			if (this.lockedExit.TryGetValue(shortDir, out state)) {
				return state;
			}
			return false;
		}

		public void LockExit (string shortDir) {
			this.setLock(shortDir, true);
		}

		public void UnlockExit (string shortDir) {
			this.setLock(shortDir, false);
		}

		private void setLock (string shortDir, bool state) {
			if (this.lockedExit == null) {
				this.lockedExit = new Dictionary<string, bool>() {
					{shortDir, state},
				};
			} else {
				this.lockedExit.Remove(shortDir);
				this.lockedExit.Add(shortDir, state);
			}
		}

		private static string directionToLong (string shortDir) {
			string dirDesc;
			if (directionLongs.TryGetValue(shortDir, out dirDesc)) {
				return dirDesc;
			}
			return shortDir;
		}

		// new stringification method, reads better
		public override string ToString () {
			// nothing to print if there are no exits here
			if (this.exits == null || this.exits.Count == 0) {
				return null;
			}

			string exitsSentence = "";

			// grouped exits
			if (this.exitGroups != null) {
				foreach (string eMethod in this.exitGroups.Keys) {
					List<string> shortDirs;
					if (this.exitGroups.TryGetValue(eMethod, out shortDirs)) {
						if (shortDirs.Count != 0) {
							if (shortDirs.Count > 1) {
								exitsSentence += Messages.RandomDeclarativePlural() + " " + English.Plural(eMethod) + " leading";
							} else {
								exitsSentence += Messages.RandomDeclarativeSingular() + " " + English.Articalize(eMethod) + " leading";
							}
							bool inList = false;
	
							int dirIdx = 0;
							foreach (string shortDir in shortDirs) {
								// look up how the exit is presented
								string dirDesc = directionToLong(shortDir);
								if (inList) {
									exitsSentence += ",";
								}
								exitsSentence += " " + dirDesc;
								inList = true;
								// TODO : fix this convolution
								if (1 + ++dirIdx == shortDirs.Count) {
									// TODO : leave the Oxford Comma in...?
									exitsSentence += " and";
									inList = false; // no more commas needed
								}
							}
	
							exitsSentence += ". ";
						}
					} // else we're fucked
				}
			}

			// verbose exits
			if (this.exitVerbose != null) {
				foreach (string shortDir in this.exitVerbose.Keys) {
					string verbose, dirDesc, method;
					if (this.exitVerbose.TryGetValue(shortDir, out verbose) &&
					    this.exitMethod.TryGetValue(shortDir, out method)) {

						dirDesc = directionToLong(shortDir);
						if (method != null) {
							exitsSentence += Messages.RandomDeclarativeSingular() + " " + English.Articalize(method) + " here " +
								String.Format(verbose, dirDesc) + ".";
						} else if (verbose != null && !exitsSentence.Contains(verbose)) {
							exitsSentence += verbose;
						}

						exitsSentence += " ";
					} // else we're fucked
				}
			}

			return exitsSentence;
		}

		/* old stringification method, reads terribly
		public override string ToString () {
			if (this.exits.Count == 0) {
				return null;
			}

			string exitsSentence = "";
			foreach (string shortDir in directionLongs.Keys) {
				if (this.exits.ContainsKey(shortDir)) {
					// look up how the exit is presented
					string mthod; // e.g. "ladder"
					if (!this.exitMethod.TryGetValue(shortDir, out mthod) || mthod == null) {
						mthod = "exit"; // vague method of exit
					}

					string dirDesc;
					if (directionLongs.TryGetValue(shortDir, out dirDesc)) {
						exitsSentence += "There is " + English.Article(mthod) + " " + mthod + " leading " + dirDesc + ". ";

					} // else we're fucked
				}
			}

			return exitsSentence;
		}
		*/
	}
}

// vi: sw=4 sts=4 ts=4
