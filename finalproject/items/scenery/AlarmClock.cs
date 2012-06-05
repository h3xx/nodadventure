/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class AlarmClock
		: Item {

		private int triedPickup = 0;
		private static List<string> failPickupMsgs = new List<string>() {
			"You pull the clock from the nightstand and the short cord almost comes unplugged. You decide that the alarm clock is happier where it can get power and put it back.",
			"You don't think the alarm clock would be happy in your inventory.",
			"What would be the use of having an unpowered clock?",
			"Seriously, you can't pick it up.",
			"Why don't you try exploring more?",
		};

		public AlarmClock ()
			: base(
				"alarm clock",
				"small red",
			    new List<string>() {
					"clock",
					"watch",
					"alarm",
					"time",
				}
			) {

			this.CanPickUp = false;
			this.actionMessages.Add("look", "You see a small red alarm clock resting on the nightstand.");

		}

		private string clockface () {
			Globals.CurrentGlobals.Time.ToString("hh:mm tt");
		}

		public override string Look () {
			// use this.actionMessages to look up the string.
			return base.Look() + " " + this.Read();

		}

		public override string Read () {
			return "The time reads " + this.clockface() + ".";
		}

		public override string MsgFailPickup () {
			// cycle through messages
			return failPickupMsgs[this.triedPickup++ % failPickupMsgs.Count];
		}
	}
}

