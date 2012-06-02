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

			{"r", "to the right"},
			{"l", "to the left"},
			{"u", "upwards"},
			{"d", "downwards"},
		};

		private Dictionary<string, Room> exits;
		private Dictionary<string, string> exitMethod;
		private Dictionary<string, List<string>> exitGroups;

		public bool HasExit (string shortDir) {
			return this.exits.ContainsKey(shortDir);
		}

		public void AddExit (string dir, Room dest) {
			this.AddExit(dir, "exit", dest);
		}

		public void AddExit (string dir, string method, Room dest) {
			if (method == null) {
				method = "exit";
			}

			// create structures if they don't exist
			if (this.exits == null) {
				this.exits = new Dictionary<string, Room>();
			}
			if (this.exitMethod == null) {
				this.exitMethod = new Dictionary<string, string>();
			}
			if (this.exitGroups == null) {
				this.exitGroups = new Dictionary<string, List<string>>();
			}

			// associate exit, direction and method
			this.exits.Add(dir, dest);
			this.exitMethod.Add(dir, method);

			// add grouping by method for pretty English
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

		// new stringification method, reads better
		public override string ToString () {
			// nothing to print if there are no exits here
			if (this.exits == null || this.exits.Count == 0) {
				return null;
			}

			string exitsSentence = "";
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
							string dirDesc;
							if (directionLongs.TryGetValue(shortDir, out dirDesc)) {
								if (inList) {
									exitsSentence += ",";
								}
								exitsSentence += " " + dirDesc;
								inList = true;
							}
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

// vi: sw=4 sts=4