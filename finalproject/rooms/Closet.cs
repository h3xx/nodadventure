/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class Closet
		: Room {

		private Inventory itemsHere_dark, itemsHere_light;

		private static string roomDesc_light = "You are standing in a small closet.",
							  roomDesc_dark = "It is too dark to see much. You do, however feel a lightswitch on the wall.";
		private Carpet carpet = new Carpet();
		private LightSwitch lightswitch;

		public Closet ()
			: base(
				"Closet",
				roomDesc_dark
			) {

			this.lightswitch = new LightSwitch(this);

			this.itemsHere_light = new Inventory(
				new List<Item>() {
					new Bucket(3),
					this.lightswitch,
					this.carpet,
				}
			);

			this.itemsHere_dark = new Inventory(
				new List<Item>() {
					this.lightswitch,
				}
			);

			this.DeIlluminate();
		}

		public void Illuminate () {
			this.roomDesc = roomDesc_light;
			this.SpecialMessage = null;
			this.itemsHere = this.itemsHere_light;
		}

		public void DeIlluminate () {
			this.roomDesc = null;
			this.SpecialMessage = roomDesc_dark;

			// prevent items from being listed if we're in darkness
			this.itemsHere = this.itemsHere_dark;
		}
	}
}

