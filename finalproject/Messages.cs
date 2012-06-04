/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/

namespace finalproject {
	using System;
	using System.Collections.Generic;
	class Messages {
		private static Random rng = new Random();

		private static List<string> sillyActions = new List<string>() {
			"That's a silly thing to do to {0}!",
			"You're not entirely sure how to do that.",
			"Your better judgement prevents you from attempting that.",
			"I don't believe that can be done.",
		};

		private static List<string> dontSeeItem = new List<string>() {
			"You don't see any {0} here.",
		};

		private static List<string> dontUnderstand = new List<string>() {
			"I don't understand that.",
			"I don't know what you mean by that.",
			"I don't know what you mean.",
			"Wha'chu talkin' 'bout, Willis?",
		};

		private static List<string> declarativesPlural = new List<string>() {
			"There are",
			"You see here",
			"You can see",
		};

		private static List<string> declarativesSingular = new List<string>() {
			"There is",
			"There is",
			"You see",
			"You see",
			"You can see",
		};

		private static List<string> thingDeclarativeSingular = new List<string>() {
			"Just an ordinary {0}.",
			"You see nothing special about it.",
			"It looks like an ordinary {0}.",
		};

		private static List<string> failGeneric = new List<string>() {
			"You try and fail.",
			"You fail to do that.",
			"A strange force prevents you.",
		};
		
		private static List<string> alreadyHaveIt = new List<string>() {
			"You already have it.",
			"You already have it.",
			"You already have it.",
			"You take it out of your pocket, give it to yourself and put it back in your pocket. You feel this was a silly thing to do.",
			"You're certain you already have it.",
		};

		private static List<string> dontHaveIt = new List<string>() {
			"You don't have that item.",
			"You don't have that item.",
			"You don't have it.",
			"You don't have it.",
			"You don't see that item among your possessions.",
		};

		private static string selectRandom (List<string> dict) {
			return dict[rng.Next(dict.Count-1)];
		}

		private static string formatRandom (List<string> dict, string thing) {
			return String.Format(selectRandom(dict), thing);
		}

		public static string RandomSilly (string thing) {
			return formatRandom(sillyActions, thing);
		}

		public static string RandomItemNotFound (string thing) {
			return formatRandom(dontSeeItem, thing);
		}

		public static string RandomThingDeclarativeSinglular (string thing) {
			/* for generic "look" messages */
			return formatRandom(thingDeclarativeSingular, thing);
		}

		public static string RandomDontUnderstand () {
			return selectRandom(dontUnderstand);
		}

		public static string RandomDeclarativePlural () {
			return selectRandom(declarativesPlural);
		}

		public static string RandomDeclarativeSingular () {
			return selectRandom(declarativesSingular);
		}
		
		public static string RandomAlreadyHave (string thing) {
			return formatRandom(alreadyHaveIt, thing);
		}

		public static string RandomDontHave (string thing) {
			return formatRandom(dontHaveIt, thing);
		}

		public static string RandomFailure () {
			return selectRandom(failGeneric);
		}


	}
}

// vi: sw=4 sts=4