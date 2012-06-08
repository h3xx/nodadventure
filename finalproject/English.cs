/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Text.RegularExpressions;
	/**
	 * Class to handle some simple things relating to proper English.
	 *
	 * @author Dan Church
	 */
	public class English {
		// note: "an history" and "an histological" are proper
		// "an 18-karat" "a 180 pound fish"
		// TODO : there are probably more, but to hell with it
		private static Regex an = new Regex("^\\s*([aeiouAEIOU]|hist|18\\b|8)");
		private static Regex isCaps = new Regex("^\\s*[A-Z]");

		/**
		 * Gives the article for the given noun.
		 *
		 * @param noun
		 *			The noun you want the article for.
		 */
		public static string Article (string noun) {
			if (an.IsMatch(noun)) {
				if (isCaps.IsMatch(noun)) {
					return "An";
				}
				return "an";
			}
			if (isCaps.IsMatch(noun)) {
				return "A";
			}
			return "a";
		}

		/**
		 * Turns the noun into an articlized noun, for example, "apple" becomes
		 * "an apple."
		 *
		 * @param noun
		 *			The noun you want the article put in front of.
		 */
		public static string Articalize (string noun) {
			return Article(noun) + " " + noun;
		}

		/**
		 * Pluralize a given noun.
		 *
		 * @param noun
		 *			The noun you want pluralized.
		 */
		public static string Plural (string noun) {
			if (noun.Length == 1) {
				// e.g. G's
				return noun + "'s";
			}
			if (noun.EndsWith("s")) {
				// e.g. ass => asses
				return noun + "es";
			}
			if (noun.EndsWith("y")) {
				// e.g. sky => skies
				return noun.Substring(0, noun.Length - 1) + "ies";
			}

			// e.g. everything else: cat => cats
			return noun + "s";
		}
	}
}

// vi: sw=4 sts=4 ts=4
