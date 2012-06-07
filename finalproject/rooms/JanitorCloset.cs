/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
using System;
namespace finalproject {
	public class JanitorCloset
		: Room {
		Door doorOut = new Door (null);

		private bool canExit = false;
		private static readonly string
			lookString = "You in a small and dirty janitor's closet.";

		private EntranceToCloset closetEntrance = new EntranceToCloset();

		public JanitorCloset ()
			: base (
				"Janitor's closet",
				lookString
			) {

			this.itemsHere = new Inventory(
				new List<Item>() {
					new AlarmClock(),
					this.closetEntrance,
				}

			);
		}
	}
}

