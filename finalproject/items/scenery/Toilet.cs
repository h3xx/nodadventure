/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class Toilet
		: Item {
		private int triedPickup = 0;
		private static List<string> failPickupMsgs = new List<string>() {
			"You can't get your arms around it.",
			"You doubt if you could fit it in your pockets.",
			"Seriously, you can't pick it up.",
			"You try to pick up, putting your face in an awkward and smelly position. You almost vomit, then decide that was a stupid idea.",
			"Why don't you try exploring more instead of wasting my time?",
		};
		public Toilet ()
			: base(
				"toilet",
				new List<string>() {
					"shitter",
					"bowl",
					"crapper",
				}
			) {

			this.CanPickUp = false;
		}

		public override string MsgFailPickup () {
			// cycle through messages
			return failPickupMsgs[this.triedPickup++ % failPickupMsgs.Count];
		}
	}
}

