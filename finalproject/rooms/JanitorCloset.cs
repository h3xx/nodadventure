/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class JanitorCloset
		: Room {

		Door doorOut = new Door (null);

		private static readonly string
			lookString = "You in a small and dirty janitor's closet.";

		public JanitorCloset ()
			: base (
				"Janitor's closet",
				lookString
			) {

			this.itemsHere = new Inventory(
				new List<Item>() {
					new Bucket(5),
					this.doorOut,
				}

			);
		}
	}
}

