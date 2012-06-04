/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class SmallKey
		: Item {
		private static List<string> synonyms_before = new List<string>() {
			"dust",
			"pile",
			"dust pile",
			"debris pile",
			"debris",
		};
		private static List<string> synonyms_after = new List<string>() {
			// after
			"small key",
			"rusted key",
		};

		private bool isRevealed = false;

		public SmallKey ()
			: base(
				"pile of dust",
				"small",
				synonyms_before
			) {
			this.CanPickUp = false;
			this.IsImportant = true;
		}

		public override string MsgFailPickup () {
			return "You get dust on your fingers.";
		}

		public override string PerformAction (string act) {
			string baseSyn = Synonyms.GetVerbBaseSynonym(act);
			if (this.isRevealed) {
				if (baseSyn == "take") {
					return this.Take();
				}
			} else {
				if (baseSyn == "search") {
					// convert to a key
					this.isRevealed = true;
					this.type = "key";
					this.synonyms = synonyms_after;
					this.CanPickUp = true;
					return "Searching the dust pile reveals a small key.";
				}
			}
			return base.PerformAction(act);
		}
	}
}

