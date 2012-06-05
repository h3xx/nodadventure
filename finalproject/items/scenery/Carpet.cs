/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class Carpet
		: Item {

		private int triedPickup = 0;
		private static List<string> failPickupMsgs = new List<string>() {
			"You pull on the carpet and a small handful of fuzz comes off.",
			"What would be the use?",
			"Seriously, it won't come up.",
			"Why don't you try exploring more?",
		};

		public Carpet ()
			: base(
				"carpet",
				"dull red",
				new List<string>() {
					"floor",
					"rug",
					"area rug",
				}
			) {

			this.CanPickUp = false;

			this.actionMessages.Add("look", "You are standing on dull red carpet, worn down throughout the years.");
		}

		public override string MsgFailPickup () {
			// cycle through messages
			return failPickupMsgs[this.triedPickup++ % failPickupMsgs.Count];
		}
	}
}

