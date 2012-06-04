/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
    using System;
    using System.Collections.Generic;
	class Inventory {
		private List<Item> items;
		private bool isPlayerInventory;

		public Inventory ()
			: this (false) {}

		public Inventory (bool isPlayerInventory)
			: this (isPlayerInventory, new List<Item>()) {}

		public Inventory (List<Item> items)
			: this (false, items) {
		}

		public Inventory (bool isPlayerInventory, List<Item> items) {
			this.isPlayerInventory = isPlayerInventory;
			this.items = items;
		}

		public bool IsEmpty () {
			return this.items != null && this.items.Count == 0;
		}

		public bool HasItem (string itemdesc) {
			return this.GetItem(itemdesc) != null;
		}

		/**
		 *
		 */
		public Item GetItem (string itemdesc) {
			if (this.IsEmpty()) {
				return null;
			}

			foreach (Item i in this.items) {
				if (i == itemdesc) {
					return i;
				}
			}
			return null;
		}

		public bool RemoveItem (Item i) {
			return this.items.Remove(i);
		}

		public void AddItem (Item i) {
			this.items.Add(i);
		}

		public override string ToString () {
			string invdesc;
			if (this.isPlayerInventory) {
				if (this.IsEmpty()) {
					return "You aren't holding anything.";
				}
				invdesc = "You are carrying:\n";
				// note: at this point, this.items won't be null OR empty
				foreach (Item i in this.items) {
					invdesc += "  " + i.LongDesc(true) + "\n";
				}
			} else {
				// room's inventory, nothing here, so don't print anything
				if (this.IsEmpty()) {
					return "";
				}

				string youSeeHere = "";
				foreach (Item i in this.items) {
					if (i.CanPickUp || i.IsImportant) {
						youSeeHere += "  " + i.LongDesc(true) + "\n";
					}
				}

				if (youSeeHere.Length > 0) {
					invdesc = "You see here:\n" + youSeeHere;
				}
			}

			return null;
		}
	}
}

// vi: sw=4 sts=4