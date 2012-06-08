/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class EntranceToCloset
		: Item {

		private int triedPickup = 0;
		private static List<string> failPickupMsgs = new List<string>() {
			"You can't pick that up.",
			"Seriously, dude, it won't come loose.",
			"Why don't you try exploring more?",
		};
		private static string
			readString = "There's nothing to read on it.",
			lookString = "It's a doorway leading to a closet.";

		public EntranceToCloset ()
			: base(
				"closet",
				new List<string>() {
					"small closet",
					"door to closet",
					"doorway to closet",
				}
			) {

			this.CanPickUp = false;
			this.actionMessages.Add("read", readString);
			this.actionMessages.Add("look", lookString);
		}

		public override string MsgFailPickup () {
			// cycle through messages
			return failPickupMsgs[this.triedPickup++ % failPickupMsgs.Count];
		}
	}
}

// vi: sw=4 sts=4 ts=4
