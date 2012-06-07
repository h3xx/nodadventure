/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	class Player {
		public Inventory Inv = new Inventory(true);
		public Room CurrentRoom;
		public bool isDead = false;

		public Player ()
			: this (null) {
		}

		public Player (Room currentRoom) {
			this.CurrentRoom = currentRoom;
		}

		public void AddItem (Item i) {
			this.Inv.AddItem(i);
		}

		public string Look () {
			return "You see yourself.";
		}

		public string Inventory () {
			return this.Inv.ToString();
		}

		public string Kill () {
			this.isDead = true;
			return "You die.";
		}
	}
}

// vi: sw=4 sts=4