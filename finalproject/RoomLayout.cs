/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	class RoomLayout {
		public Room StartingPoint;

		public RoomLayout () {
			Room fl2westhall, fl2easthall, fl1westhall, fl1easthall;
			secondFloor(out fl2westhall, out fl2easthall);
			firstFloor(out fl1westhall, out fl1easthall);
			connectSections(fl1westhall, fl1easthall, fl2westhall, fl2easthall);
		}

		private void firstFloor (out Room hallwayWest, out Room hallwayEast) {
			Room hallwayMid = new HallwayFloorOneMid();
			hallwayWest = new HallwayFloorOneWest();

			// connect mid <=> west hallways
			hallwayWest.ExitsHere.AddExit("e", null, "From here the hallway continues east.", hallwayMid);
			hallwayMid.ExitsHere.AddExit("w", null, "From here the hallway continues east and west.", hallwayWest);

			hallwayEast = new HallwayFloorOneEast();

			// connect mid <=> east hallways
			hallwayMid.ExitsHere.AddExit("e", null, "From here the hallway continues east and west.", hallwayEast);
			hallwayEast.ExitsHere.AddExit("w", null, "From here the hallway continues west.", hallwayMid);
		}

		private void secondFloor (out Room hallwayWest, out Room hallwayEast) {
			Room myroom = new MyHotelRoom(); 
			Room myBathroom = new MyHotelRoomBathroom();
			Room myCloset = new Closet();

			this.StartingPoint = myroom;

			// connect room to bathroom
			myroom.ExitsHere.AddExit("e", "door", "leading to a small bathroom {0}", myBathroom);
			myBathroom.ExitsHere.AddExit("w", "door", "leading back into your hotel room {0}", myroom);

			// connect room to closet
			myroom.ExitsHere.AddExit("ne", "doorway", "leading to a small closet {0}", myCloset);
			myCloset.ExitsHere.AddExit("sw", "doorway", "leading back into your hotel room {0}", myroom);

			Room hallwayMid = new HallwayFloorTwoMid();

			// connect room to hallway
			myroom.ExitsHere.AddExit("n", "door", hallwayMid);
			hallwayMid.ExitsHere.AddExit("s", "door", myroom);

			hallwayWest = new HallwayFloorTwoWest();

			// connect mid <=> west hallways
			hallwayWest.ExitsHere.AddExit("e", null, "From here the hallway continues east.", hallwayMid);
			hallwayMid.ExitsHere.AddExit("w", null, "From here the hallway continues east and west.", hallwayWest);

			hallwayEast = new HallwayFloorTwoEast();

			// connect mid <=> east hallways
			hallwayMid.ExitsHere.AddExit("e", null, "From here the hallway continues east and west.", hallwayEast);
			hallwayEast.ExitsHere.AddExit("w", null, "From here the hallway continues west.", hallwayMid);
		}

		private void connectSections (Room fl1westhall, Room fl1easthall, Room fl2westhall, Room fl2easthall) {
			// connect staircase
			fl1easthall.ExitsHere.AddExit("u", "staircase", fl2easthall);
			fl2easthall.ExitsHere.AddExit("d", "staircase", fl1easthall);
		}
	}
}

// vi: sw=4 sts=4