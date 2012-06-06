/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class Door
		: Item {

		private int triedPickup = 0;
		private static List<string> failPickupMsgs = new List<string>() {
			"You can't get your arms around it.",
			"You doubt if you could fit it in your pockets.",
			"Sure, I'll just take it off its hinges and stick it in my pocket.",
			"I'll pick it up after you hand me those pianoes.",
			"Seriously, dude, you can't pick it up.",
			"Why don't you try exploring more instead of wasting my time?",
		};

		private string roomNr;

		public Door (string roomNr)
			: this (roomNr, null) {
		}

		public Door (string roomNr, string[] addSyns)
			: base(
				"door",
				new List<string>() {
					"doorway",
				}
			) {

			this.CanPickUp = false;
			this.roomNr = roomNr;
			if (this.roomNr != null) {
				this.synonyms.Add(roomNr);
				this.synonyms.Add(roomNr+ " door");
				this.actionMessages.Add("read", "\""+Toolbox.UcFirst(roomNr)+".\"");
				this.actionMessages.Add("open", "Locked.");
				this.actionMessages.Add("look", "It's a door, it's made of wood. You see a small plaque on the door that reads \""+Toolbox.UcFirst(roomNr)+".\"");
			} else {
				this.actionMessages.Add("look", "It's a door, it's made of wood. What else do you want me to say?");
			}

			if (addSyns != null) {
				this.synonyms.AddRange(addSyns);
			}

		}

		public override string MsgFailPickup () {
			// cycle through messages
			return failPickupMsgs[this.triedPickup++ % failPickupMsgs.Count];
		}

		public void SetUnlocked () {
			// HACK : this feels stupid
			this.actionMessages.Remove("open");
		}
	}
}
