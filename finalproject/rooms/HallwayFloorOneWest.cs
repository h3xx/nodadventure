/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class HallwayFloorOneWest
		: Room {

		private static readonly string
			lookString = "You are standing in a dimly-lit hallway. There are doors on the north and south walls.";

		private Sconce lights = new Sconce();
		private Carpet carpet = new Carpet();
		private Door doorSouth = new Door(
			"room 103",
			new string[] {
				"south door",
				"south doorway",
				"103 door",
				"103 doorway",
				"103",
			}
		);
		private Door doorNorth = new Door(
			"room 104",
			new string[] {
				"north door",
				"north doorway",
				"104 door",
				"104 doorway",
				"104",
			}
		);
		public HallwayFloorOneWest ()
			: base(
				"First Floor Hallway",
				lookString
			) {

			this.itemsHere = new Inventory(
				new List<Item>() {
					this.lights,
					this.carpet,
					this.doorSouth,
					this.doorNorth,
				}
			);

			this.ExitsHere.AddExit("n", null);
			this.ExitsHere.LockExit("n");
			this.ExitsHere.AddExit("s", null);
			this.ExitsHere.LockExit("s");
		}
	}
}
