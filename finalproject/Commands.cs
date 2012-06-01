/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	class Commands {
		private static List<string> transitiveVerbs = new List<string>() {
			"take",
			"pull",
			"push",
			"eat",
			"drop",
			"read",
		};

		private static Regex wordSplit = new Regex("\\s+"),
							 whiteSpace = new Regex("(^\\s+|\\s+$)"),
							 articles = new Regex("\\b(the|a)\\b");

/*
		public static string RunCommand (string command, Player pl, Room rm) {

		}*/

		private static string normalizeCommand (string cmd) {
			// normalize the command
			string stripCmd = cmd.ToLower();
			stripCmd = whiteSpace.Replace(stripCmd, "");
			stripCmd = articles.Replace(stripCmd, "");

			return stripCmd;
		}

		private static string[] splitCommand (string cmd) {
			string stripCmd = normalizeCommand(cmd);
			return wordSplit.Split(stripCmd);
		}

		/**
		 * Compile a list of word combinations from shortest to longest.
		 *
		 * Example:
		 * "take"
		 * "take brown"
		 * "take brown thing"
		 */
		private static List<string> wordCombinationsFromBeginning (string cmd) {
			return wordCombinationsFromBeginning(splitCommand(cmd));
		}

		private static List<string> wordCombinationsFromBeginning (string[] words) {
			string tw = words[0];
			List<string> wordCombos = new List<string>() {
				tw,
			};

			int wi;
			for (wi = 1; wi < words.Length; ++wi) {
				tw += " " + words[wi];
				wordCombos.Add(tw);
			}

			return wordCombos;
		}

		/**
		 * Compile a list of word combinations from shortest to longest.
		 *
		 * Example:
		 * "thing"
		 * "brown thing"
		 * "take brown thing"
		 */
		private static List<string> wordCombinationsFromEnd (string cmd) {
			return wordCombinationsFromEnd(splitCommand(cmd));
		}

		private static List<string> wordCombinationsFromEnd (string[] words) {
			string tw = words[words.Length-1];
			List<string> wordCombos = new List<string>() {
				tw,
			};

			int wi;
			for (wi = words.Length - 2; wi > -1; --wi) {
				tw = words[wi] + " " + tw;
				wordCombos.Add(tw);
			}

			return wordCombos;
		}

		private static List<string> allWordCombinations (string cmd) {
			return allWordCombinations(splitCommand(cmd));
		}

		private static List<string> allWordCombinations (string[] words) {
			List<string> topCombos = wordCombinationsFromBeginning(words);
			List<string> subcombos;
			string[] subsplit;
			List<string> allCombos = new List<string>();
			foreach (string tc in topCombos) {
				allCombos.Add(tc);
				// only three-word combos or higher
				subsplit = wordSplit.Split(tc);
				if (subsplit.Length > 2) {
					subcombos = wordCombinationsFromEnd(subsplit);
					foreach (string sc in subcombos) {
						allCombos.Add(sc);
					}
				}

			}
			return allCombos;
		}

		public static string[] GetCommandVerb (string cmd) {
			return GetCommandVerb(splitCommand(cmd));
		}

		public static string[] GetCommandVerb (string[] words) {
			List<string> tryWordCombinations = wordCombinationsFromBeginning(words);
			tryWordCombinations.Reverse();

			string vbase;
			foreach (string phrase in tryWordCombinations) {
				vbase = Synonyms.GetVerbBaseSynonym(phrase);
				if (vbase != null) {
					return new string[] {phrase, vbase}; // note: do not get base synonym just yet
				}
			}

			return null;
		}

		public static string[] GetCommandPreposition (string cmd) {
			return GetCommandPreposition(splitCommand(cmd));
		}

		public static string[] GetCommandPreposition (string[] words) {
			List<string> tryWordCombinations = allWordCombinations(words);
			tryWordCombinations.Sort(
				delegate(string a, string b) {
					//return a.Length.CompareTo(b.Length);
					// longest first
					return b.Length.CompareTo(a.Length);
				}
			);
			string pbase;

			foreach (string phrase in tryWordCombinations) {
				pbase = Synonyms.GetPrepositionBaseSynonym(phrase);
				if (pbase != null) {
					return new string[] {phrase, pbase}; // note: do not get base synonym just yet
				}
			}

			return null;
		}

		public static List<string[]> GetCommandParts (string cmd) {
			return GetCommandParts(splitCommand(cmd));
		}

		public static List<string[]> GetCommandParts (string[] words) {
			int readFrom = 0;
			List<string[]> parts = new List<string[]>();

			// figure out the verb (should be first word or close to the first word
			string[] partFound = GetCommandVerb(words);
			if (partFound != null) {
				// Update our index
				readFrom += wordSplit.Split(partFound[0]).Length;
				Toolbox.ArrayShift<string>(ref words, readFrom);
			}
			parts.Add(partFound); // (even if it's null)

			// preposition
			partFound = GetCommandPreposition(words);
			parts.Add(partFound); // (even if it's null)

			// FIXME : moar parts of sentence

			return parts;
		}
	}
}

// vi: sw=4 sts=4