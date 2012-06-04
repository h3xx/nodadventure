/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	class Closet : Room {
		private bool isLightOn = false;
		private string roomDesc_light,
					   roomDesc_dark;
		private Inventory items;

		public Closet (string roomName)
			: this (roomName, null, null) {
		}

		public Closet (string roomName, string roomDesc_dark, string roomDesc_light)
			: this (roomName, roomDesc_dark, roomDesc_light, new Inventory()) {
		}

		public Closet (string roomName, Inventory itemsHere)
			: this (roomName, null, null, itemsHere) {
		}

		public Closet (string roomName, string roomDesc_dark, string roomDesc_light, Inventory itemsHere) :
			base (roomName, roomDesc_dark, null) {
			this.roomDesc_dark = roomDesc_dark;
			this.roomDesc_light = roomDesc_light;
			// prevent items from being listed if we're in darkness
			this.items = itemsHere;
		}

		public string TurnOffLight () {
			if (this.isLightOn) {
				this.isLightOn = false;
				this.roomDesc = null;
				this.SpecialMessage = this.roomDesc_dark;

				// prevent items from being listed if we're in darkness
				this.items = this.itemsHere;
				this.itemsHere = null;
				return "You switch off the light.";
			} else {
				return "The light is already off.";
			}
		}

		public string TurnOnLight () {
			if (!this.isLightOn) {
				this.isLightOn = true;
				this.roomDesc = this.roomDesc_light;
				this.SpecialMessage = null;
				this.itemsHere = this.items;
				this.items = null;
				return "You switch on the light.";
			} else {
				return "The light is already on.";
			}
		}
	}
}

