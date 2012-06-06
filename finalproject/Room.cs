/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class Room {

		protected Inventory itemsHere;
		protected string roomName, roomDesc;
		protected bool playerHasVisited;
		public Exits ExitsHere;
		public string SpecialMessage;

		public Room ()
			: this (new Inventory()) {
		}

		public Room (string roomName)
			: this (roomName, new Inventory()) {
		}

		public Room (Inventory itemsHere)
			: this ("Unknown", itemsHere) {
			Console.Error.WriteLine("FIXME: Room:Room(): Unnamed room!");
		}

		public Room (string roomName, Inventory itemsHere)
			: this (roomName, null, itemsHere) {
			Console.Error.WriteLine("FIXME: Room:Room(): Undescribed room!");
		}

		public Room (string roomName, string roomDesc)
			: this (roomName, roomDesc, new Inventory()) {
		}

		public Room (string roomName, string roomDesc, Inventory itemsHere)
			: this (roomName, roomDesc, itemsHere, new Exits()) {
//			Console.Error.WriteLine("FIXME: Room:Room(): Unexitable room!");
		}

		public Room (string roomName, string roomDesc, Inventory itemsHere, Exits exits) {
			this.roomName = roomName;
			this.roomDesc = roomDesc;
			this.itemsHere = itemsHere;
			this.ExitsHere = exits;
		}

		/***** CONSTRUCTION METHODS *****/

		/***** INTERACTION METHODS *****/

		/**
		 * Objectives: Give the user all the information,
		 * Mark this room as visited.
		 */
		public string EnterRoom () {
			// condition 1: player has been here, just print important stuff
			// condition 2: player has not been here, describe the room
			string roomDesc = this.Look(!this.playerHasVisited);
			this.playerHasVisited = true;
			return roomDesc;
		}

		public Item GetItem (string itemdesc) {
			if (this.itemsHere == null) {
				return null;
			}

			return this.itemsHere.GetItem(itemdesc);
		}

		public string Look () {
			return this.Look(true);
		}

		public string Look (bool verbose) {
			string roomString;
			if (this.roomName != null) {
				roomString = this.roomName;
			} else {
				roomString = "Unnamed Room";
			}

			if (verbose) {
				if (this.roomDesc != null) {
					roomString += "\n" + this.roomDesc;
				}

				if (this.ExitsHere != null) {
					string exitsSentence = this.ExitsHere.ToString();
					if (exitsSentence != null) {
						roomString += "\n" + exitsSentence;
					}
				}
			}

			if (this.itemsHere != null) {
				roomString += "\n" + this.itemsHere;
			}

			if (this.SpecialMessage != null) {
				roomString += "\n" + this.SpecialMessage;
			}
			return roomString;
		}

		public virtual Room Go (string shortDir) {
			if (this.ExitsHere.HasExit(shortDir) && !this.ExitsHere.ExitIsLocked(shortDir)) {
				return this.ExitsHere.GetExit(shortDir);
			}
			return null;
		}

		public virtual string MsgFailGo (string shortDir) {
			if (this.ExitsHere.ExitIsLocked(shortDir)) {
				return Messages.RandomLocked();
			}
			return Messages.RandomCantExit();
		}

		public override string ToString () {
			return this.Look();
		}
	}
}

// vi: sw=4 sts=4