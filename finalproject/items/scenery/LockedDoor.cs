/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	class LockedDoor
		: Door {

		private Room whereAmI;
		private string doorDirection;
		private string inventoryNeededToLockUnLock;

		public LockedDoor (Room whereAmI, string doorDirection, string inventoryNeededToLockUnlock)
			: base (null) {

			this.whereAmI = whereAmI;
			this.doorDirection = doorDirection;
			this.inventoryNeededToLockUnLock = inventoryNeededToLockUnlock;
		}

		private string setLockedState (bool state) {
			if (this.inventoryNeededToLockUnLock != null &&
			    !Globals.CurrentGlobals.CurrentPlayer.Inv.HasItem(this.inventoryNeededToLockUnLock)) {

				// needs a key, player doesn't have it
				if (Globals.CurrentGlobals.CurrentPlayer.Inv.HasItem("key")) {
					return "You have a key, but it's not the right one.";
				}
				return "You don't have the appropriate key.";
			}

			if (state == this.whereAmI.ExitsHere.ExitIsLocked(this.doorDirection)) {
				return "It's already " + (state ? "locked" : "unlocked") + ".";
			}

			// can unlock
			this.whereAmI.ExitsHere.UnlockExit(doorDirection);
			return Messages.RandomUnlockSuccess(English.Articalize(this.BaseDesc()));
		}

		public override string Unlock () {
			return this.setLockedState(false);
		}

		public override string Lock () {
			return this.setLockedState(true);
		}
	}
}
