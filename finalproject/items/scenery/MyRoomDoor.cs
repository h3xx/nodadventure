/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	class MyRoomDoor
		: LockedDoor {

		private static readonly string needsToLockUnlock = "room key";

		public MyRoomDoor (Room whereAmI, string doorDirection)
			: base (
				whereAmI, doorDirection, needsToLockUnlock
			) {
		}
	}
}

