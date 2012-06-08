/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class Synonyms {
		public readonly static Dictionary<string, List<string>> DirectionSynonyms = new Dictionary<string, List<string>>() {
			// cardinal directions
			{"nw", new List<string>() {"northwest", "north west", "north-west"}},
			{"sw", new List<string>() {"southwest", "south west", "south-west"}},
			{"ne", new List<string>() {"northeast", "north east", "north-east"}},
			{"se", new List<string>() {"southeast", "south east", "south-east"}},
			{"n", new List<string>() {"north"}},
			{"s", new List<string>() {"south"}},
			{"w", new List<string>() {"west"}},
			{"e", new List<string>() {"east"}},

			// relative directions
			{"r", new List<string>() {"right"}},
			{"l", new List<string>() {"left"}},
			{"u", new List<string>() {"up"}},
			{"d", new List<string>() {"down"}},
		};

		public readonly static Dictionary<string, List<string>> VerbSynonyms = new Dictionary<string, List<string>>() {
			// *** DIRECTIONS ***
			{"go nw", new List<string>() {"nw", "northwest", "north west", "north-west", "go northwest", "go north-west", "walk nw", "walk northwest", "walk north-west"}},
			{"go sw", new List<string>() {"sw", "southwest", "south west", "south-west", "go southwest", "go south-west", "walk sw", "walk southwest", "walk south-west"}},
			{"go ne", new List<string>() {"ne", "northeast", "north east", "north-east", "go northeast", "go north-east", "walk ne", "walk northeast", "walk north-east"}},
			{"go se", new List<string>() {"se", "southeast", "south east", "south-east", "go southeast", "go south-east", "walk se", "walk southeast", "walk south-east"}},
			{"go n",  new List<string>() {"n", "north", "go north", "walk n", "walk north"}},
			{"go e",  new List<string>() {"e", "east",  "go east",  "walk e", "walk east"}},
			{"go w",  new List<string>() {"w", "west",  "go west",  "walk w", "walk west"}},
			{"go s",  new List<string>() {"s", "south", "go south", "walk s", "walk south"}},

			{"go r",  new List<string>() {"r", "right", "go r", "go right", "walk r", "walk right"}},
			{"go l",  new List<string>() {"l", "left", "go l", "go left", "walk l", "walk left"}},
			{"go u",  new List<string>() {"u", "up", "go u", "go up", "walk u", "walk up", "climb u", "climb up"}},
			{"go d",  new List<string>() {"d", "down", "go d", "go down", "walk d", "walk down", "climb d", "climb down"}},

			// *** ACTIONS ***
			{"take",  new List<string>() {"get", "pick up", "pick", "steal", "acquire"}},
			{"drop",  new List<string>() {"put down", "throw away"}},
			{"inventory", new List<string>() {"i", "inv"}},
			{"look", new List<string>() {"look at", "examine", "l"}},
			{"speak", new List<string>() {"say"}},
			{"put", new List<string>() {"place", "set", "drop"}},
			{"hit", new List<string>() {"strike", "punch"}},
			{"throw", new List<string>() {"toss", "chuck", "pitch"}},
			{"search", new List<string>() {"sift", "feel", "pick through"}},
			{"turn on", new List<string>() {"flip on", "switch on"}},
			{"turn off", new List<string>() {"flip off", "switch off"}},
			// just mark as a verb
			{"use", null},
			{"read", null},
			{"kick", null},
			{"unlock", null},
			{"lock", null},
		 	// XXX : in order to avoid conflicts, please search from most verbose to least verbose when choosing synonyms
			{"walk", null},
			{"go", null},
			{"wait", null},
			{"quit", null},
		};

		public readonly static List<string> TransitiveVerbs = new List<string>() {
			// note: only use the root synonyms from VerbSynonyms
			"kick", "use", "read", "put", "take", "go", "hit", "walk", "lock", "unlock",
			"drop", "turn on", "turn off", "open", "close", "search", "throw", "look",
		};

		public readonly static List<string> Prepositions = new List<string>() {
			// c/o Wikipedia
			//"a",
			"abaft",
			"aboard",
			"about",
			"above",
			"absent",
			"across",
			"afore",
			"after",
			"against",
			"along",
			"alongside",
			"amid",
			"amidst",
			"among",
			"amongst",
			//"an",
			"apropos",
			"around",
			"as",
			"aside",
			"astride",
			"at",
			"athwart",
			"atop",
			"barring",
			"before",
			"behind",
			"below",
			"beneath",
			"beside",
			"besides",
			"between",
			"betwixt",
			"beyond",
			//"but",
			"by",
			"circa",
			"concerning",
			"despite",
			"down",
			"during",
			"except",
			"excluding",
			"failing",
			"following",
			"for",
			"from",
			"given",
			"in",
			"including",
			"inside",
			"into",
			"lest",
			"like",
			"mid",
			"midst",
			"minus",
			"modulo",
			"near",
			"next",
			"notwithstanding",
			"of",
			"off",
			"on",
			"onto",
			"opposite",
			"out",
			"outside",
			"over",
			"pace",
			"past",
			"per",
			//"plus",
			//"pro",
			//"qua",
			"regarding",
			"round",
			"sans",
			"save",
			"since",
			"than",
			"through",
			"thru",
			"throughout",
			"thruout",
			"till",
			"times",
			"to",
			"toward",
			"towards",
			"under",
			"underneath",
			"unlike",
			"until",
			"unto",
			//"up",
			"upon",
			"versus",
			"via",
			//"vice",
			"with",
			"within",
			"without",
			//"worth",
			/*** two words ***/
			"according to",
			"ahead of",
			"apart from",
			"as for",
			"as of",
			"as per",
			"as regards",
			"aside from",
			"back to",
			"because of",
			"close to",
			"due to",
			"except for",
			"far from",
			"in to",
			"into",
			"inside of",
			"instead of",
			"left of",
			"near to",
			"next to",
			"on to",
			"onto",
			"out from",
			"out of",
			"outside of",
			"owing to",
			"prior to",
			"pursuant to",
			"regardless of",
			"right of",
			"subsequent to",
			"thanks to",
			"that of",
			"up to",
			"where as",
			/*** three words ***/
			"as far as",
			"as well as",
			"as long as",
			/*** preposition + (article) + noun + preposition ***/
			"by means of",
			"for the sake of",
			"in accordance with",
			"in addition to",
			"in case of",
			"in front of",
			"in lieu of",
			"in order to",
			"in place of",
			"in point of",
			"in spite of",
			"on account of",
			"on behalf of",
			"on top of",
			"with regard to",
			"with respect to",
			"with a view to",
		};

		public static readonly Dictionary<string, List<string>> PrepositionSynonyms = new Dictionary<string, List<string>>() {
			{"with", new List<string>() {
				"amid",
				"about",
				"among",
				"amongst",
				"amidst",
				"midst",
				"through",
				"thru",
				"throughout",
				"thruout",
			}},
			{"on", new List<string>() {
				"above",
				"across",
				"against",
				"aside",
				"atop",
				"onto",
				"athwart",
				"over",
				"unto",
				"upon",
				"on to",
				"onto",
				"on top of",
			}},
			{"in", new List<string>() {
				"aboard",
				"between",
				"betwixt",
				"with",
				"within",
				"into",
				"inside",
				"in to",
				"into",
				"inside of",
			}},
			{"by", new List<string>() {
				"along",
				"alongside",
				"after",
				"beside",
				"besides",
				"astride",
				"near",
				"next",
				"opposite",
				"outside",
				"close to",
				"left of",
				"near to",
				"next to",
				"ahead of",
				"outside of",
				"right of",
				"up to",
				"in front of",
			}},
			{"below", new List<string>() {
				"behind",
				"beneath",
				"beyond",
				"down",
				"under",
				"underneath",
			}},
			{"at", new List<string>() {
				"around",
				"round",
				"afore",
				"abaft",
				"before",
				"circa",
				"to",
				"toward",
				"towards",
			}},
		};

		public static string GetBaseSynonym (Dictionary<string, List<string>> dict, string syn) {
			List<string> val;
			foreach (string key in dict.Keys) {
				if (syn == key) {
					return key;
				}
				if (dict.TryGetValue(key, out val)) {
					if (val != null && val.Contains(syn)) {
						return key;
					}
				}
			}
			return null;
		}

		public static string GetVerbBaseSynonym (string syn) {
			return GetBaseSynonym(VerbSynonyms, syn);
		}

		public static string GetDirectionBaseSynonym (string syn) {
			return GetBaseSynonym(DirectionSynonyms, syn);
		}

		public static string GetPrepositionBaseSynonym (string syn) {
			return GetBaseSynonym(PrepositionSynonyms, syn);
		}
	}
}

// vi: sw=4 sts=4 ts=4
