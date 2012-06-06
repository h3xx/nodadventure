/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class HallwayFloorOneMid
		: Room {
		private static string lookString = "You are standing in a dimly-lit hallway.";
		private Sconce lights = new Sconce();
		private Carpet carpet = new Carpet();
		private Door doorSouth = new Door(
			"room 102",
			new string[] {
				"south door",
				"south doorway",
				"102 door",
				"102 doorway",
				"102",
			}
		);
		private Door doorNorth = new Door(
			"room 105",
			new string[] {
				"north door",
				"north doorway",
				"105 door",
				"105 doorway",
				"105",
			}
		);
		public HallwayFloorOneMid ()
			: base(
				"First Floor Hallway",
				lookString
			) {

			this.itemsHere = 
				new Inventory(
					new List<Item>() {
						this.lights,
						this.carpet,
						this.doorSouth,
						this.doorNorth,
					}
				);
		}
	}
}

// vi: sw=4 sts=4