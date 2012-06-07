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
			"You pull on the light switch and it gives you a nasty shock.",
			"You pull on the light switch and it gives you a nasty shock. Why you keep doing this is beyond me.",
			"What would be the use of having this item?",
			"Seriously, you can't pick it up.",
			"Why don't you try exploring more?",
		};

		private static string
			readString = "There's nothing to read on it.",
			lookString = "You see a small lightswitch.";

		private bool isOn = false;
		private Closet parent;

		public LightSwitch (Closet whereAmI)
			: base(
				"lightswitch",
			    new List<string>() {
					"light",
					"switch",
					"light switch",
				}
			) {

			this.CanPickUp = false;
			this.actionMessages.Add("read", readString);
			this.actionMessages.Add("look", lookString);
			this.parent = whereAmI;
		}

		public override string TurnOff () {
			if (this.isOn) {
				this.isOn = false;
				this.parent.DeIlluminate();
				return "You switch off the light.";
			} else {
				return "The light is already off.";
			}
		}

		public override string TurnOn () {
			if (!this.isOn) {
				this.isOn = true;
				this.parent.Illuminate();
				return "You switch on the light.";
			} else {
				return "The light is already on.";
			}
		}

		public override string UseIntransitive () {
			return this.isOn ? this.TurnOff() : this.TurnOn();
		}

		public override string MsgFailPickup () {
			// cycle through messages
			return failPickupMsgs[this.triedPickup++ % failPickupMsgs.Count];
		}
	}
}

