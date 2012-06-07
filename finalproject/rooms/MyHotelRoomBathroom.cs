/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class MyHotelRoomBathroom
		: Room {

		private Toilet toilet = new Toilet();
		private static string lookString = "You are standing in a small bathroom. It is impeccably clean, but the lights seem to be underpowered. There is a grubby-looking toilet here.";

		public MyHotelRoomBathroom ()
			: base (
				"Bathroom",
				lookString
			) {

			this.itemsHere = new Inventory(
				new List<Item>() {
					this.toilet,
					new Toothbrush(),
					new Aspirin(),
				}
			);
		}
	}
}

