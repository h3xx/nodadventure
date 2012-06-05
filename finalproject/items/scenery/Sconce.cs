/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class Sconce
		: Item {

		private int triedPickup = 0;
		private static List<string> failPickupMsgs = new List<string>() {
			"You pull on the light fixture, but it won't budge.",
			"Seriously, dude, it won't come loose.",
			"Why don't you try exploring more?",
		};

		public Sconce ()
			: base(
				"sconce",
				new List<string>() {
					"light",
					"fixture",
					"light fixture",
					"light socket",
					"light bulb",
					"lightbulb",
					"socket",
					"chandelier",
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

