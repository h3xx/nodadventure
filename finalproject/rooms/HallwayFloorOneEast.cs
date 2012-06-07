/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class HallwayFloorOneEast
		: Room {

		private static readonly string
			lookString = "You are standing in a dimly-lit hallway. There are doors on the north and south walls.";
		private Sconce lights = new Sconce();
		private Carpet carpet = new Carpet();
		private Door doorSouth = new Door(
			"room 101",
			new string[] {
				"south door",
				"south doorway",
				"101 door",
				"101 doorway",
				"101",
			}
		);
		private Door doorNorth = new Door(
			"room 206",
			new string[] {
				"north door",
				"north doorway",
				"106 door",
				"106 doorway",
				"106",
			}
		);

		public HallwayFloorOneEast ()
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
