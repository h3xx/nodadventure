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
		public static readonly string CopyrightMsg =
			"Copyright (C) 2012 Dan Church.";
		public static readonly string LicenseMsg =
			"License GPLv3+: GNU GPL version 3 or later "+
			"(http://gnu.org/licenses/gpl.html). "+
			"This is free software: you are free to change "+
				"and redistribute it. There is NO WARRANTY, "+
				"to the extent permitted by law.\n"+
				"Other elements distributed under the "+
				"Creative Commons Attribution NonCommercial ShareAlike "+
				"3.0 Unported license.";

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
			"I don't understand that.",
			"I don't understand that.",
			"I'm sorry but I don't understand that.",
			"I don't know what you mean by that.",
			"I don't know what you mean.",
			"I'm sorry but I don't know what you mean.",
			"Wha'chu talkin' 'bout, Willis?",
			"You seem to be missing a verb.",
			"English, motherf**ker. Do you speak it?",
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

		private static List<string> cantExit = new List<string>() {
			"You see no exit in that direction.",
			"You see no exit in that direction.",
			"You bump into a wall. Ouch.",
			"You can't exit that way.",
			"You can't go that way.",
		};

		private static List<string> locked = new List<string>() {
			"Locked.",
			"Locked.",
			"You pull on the handle but it's firmly locked.",
			"You pull on the handle but it's locked.",
			"It's locked.",
			"It's locked. Perhaps the key is around here somewhere.",
		};

		private static List<string> unlockAction = new List<string>() {
			"You unlock {0}.",
			"You unlock {0}.",
			"You succeed in unlocking {0}.",
			"You successfully unlock {0}.",
			"You hear a click as you unlock {0}.",
		};

		private static List<string> lockAction = new List<string>() {
			"You lock {0}.",
			"You lock {0}.",
			"You succeed in locking {0}.",
			"You successfully lock {0}.",
			"You hear a click as you lock {0}.",
		};

		private static List<string> sillyVerb = new List<string>() {
			"That's a silly thing to {0}.",
			"What a silly thing to {0}.",
		};

		private static List<string> noObject = new List<string>() {
			"You don't see any {0} here.",
			"You don't see that object anywhere.",
			"You don't see {0} anywhere.",
		};

		private static List<string> noCmd = new List<string>() {
			"Just keep hitting the enter key, see what happens.",
			"You're going to break your enter key if you keep doing that.",
			"You didn't enter a command.",
			"You kind of failed to say anything.",
			"Y U NO ENTER COMMAND?",
		};

		private static List<string> noCmd_mad = new List<string>() {
			"Just keep hitting the enter key, see what happens.",
			"You had better enter a command soon or something bad might happen.",
		};

		private static List<string> noRoom = new List<string>() {
			"You don't seem to be anywhere in particular at the moment.",
			"Looks like the programmer forgot to place you somewhere.",
			"You are floating in the void.",
		};

		private static List<string> noTransitiveObject = new List<string>() {
			"You're not sure how to {0} nothing.",
			"What? What do you want to {0}?",
			"What? What do you want to {0}?",
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

		public static string RandomCantExit () {
			return selectRandom(cantExit);
		}

		public static string RandomLocked () {
			return selectRandom(locked);
		}

		public static string RandomSillyVerb (string verb) {
			return formatRandom(sillyVerb, verb);
		}

		public static string RandomNoCmd () {
			return selectRandom(noCmd);
		}

		public static string RandomNoCmdMad () {
			return selectRandom(noCmd_mad);
		}

		public static string RandomNoRoom () {
			return selectRandom(noRoom);
		}

		public static string RandomUnknownObject (string thing) {
			return formatRandom(noObject, thing);
		}

		public static string RandomNoObjectForVerb (string thing) {
			return formatRandom(noTransitiveObject, thing);
		}

		public static string RandomUnlockSuccess (string articalizedThing) {
			return formatRandom(unlockAction, articalizedThing);
		}

		public static string RandomLockSuccess (string articalizedThing) {
			return formatRandom(lockAction, articalizedThing);
		}

		public static string GreetingMsg () {
			return "Welcome to the Nod Adventure, an interactive fiction game.\n"+
				CopyrightMsg + "\n" + LicenseMsg;
		}
	}
}

// vi: sw=4 sts=4