/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class LightSwitch
		: Item {

		private int triedPickup = 0;
		private static List<string> failPickupMsgs = new List<string>() {
			"You pull the clock from the nightstand and the short cord almost comes unplugged. You decide that the alarm clock is happier where it can get power and put it back.",
			"You don't think the alarm clock would be happy in your inventory.",
			"What would be the use of having an unpowered clock?",
			"Seriously, you can't pick it up.",
			"Why don't you try exploring more?",
		};

		public LightSwitch ()
			: base(
				"lightswitch",
			    new List<string>() {
					"light",
					"switch",
					"light switch",
				}
			) {

			this.CanPickUp = false;
			this.actionMessages.Add("read", "There's nothing to read on it.");
			this.actionMessages.Add("look", "You see a small lightswitch.");
		}

		public override string MsgFailPickup () {
			// cycle through messages
			return failPickupMsgs[this.triedPickup++ % failPickupMsgs.Count];
		}
	}
}

