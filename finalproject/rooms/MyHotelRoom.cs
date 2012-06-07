/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class MyHotelRoom 
		: Room {
		Door doorOut = new Door (null);

		private bool canExit = false;
		private static readonly string lookString = "You are standing in your hotel room. There is a bed along the south wall, with a nightstand next to it. On the nightstand there is an alarm clock.";
		private EntranceToCloset closetEntrance = new EntranceToCloset();

		public MyHotelRoom ()
			: base (
				"Room 202",
				lookString
			) {

			this.itemsHere = new Inventory(
				new List<Item>() {
					new AlarmClock(),
					this.closetEntrance,
				}

			);
		}

		public void Unlock () {
			this.canExit = true;
		}
	}
}

// vi: sw=4 sts=4