/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class Bucket
		: Item {

		// Can you tell I'm a Perl programmer?
		// hack! allow magical synonym generation for the two different buckets in the game.
		private static Dictionary<int, List<string>> names = new Dictionary<int, List<string>>() {
			{3, new List<string>() {
				"small bucket",
				"tiny bucket",
				"miniscule bucket"
			}},
			{5, new List<string>() {
				"large bucket",
				"big bucket",
				"giant bucket"
			}},
		};

		private static string liquid = "fuel";

		private int capacity, fill = 0;
		public int Fill {
			get {
				return this.fill;
			}
			set {
				if (value > this.capacity) {
					this.fill = this.capacity;
				} else if (value < 0) {
					this.fill = 0;
				} else {
					this.fill = value;
				}
				// English
				if (this.fill == 0) {
					this.temp_attr_pre = "empty";
					this.temp_attr_post = null;
				} else if (this.fill == this.capacity) {
					this.temp_attr_pre = "full";
					this.temp_attr_post = null;
				} else {
					this.temp_attr_pre = null;
					this.temp_attr_post = "with " + this.fill + " gallons of " + liquid;
				}
			}
		}

		public int Capacity {
			get {
				return this.capacity;
			}
		}

		public Bucket (int capacity)
			: base (
				"bucket",
				capacity + " gallon"
			) {

			this.capacity = capacity;

			//this.Fill = 0;
			// (this is simpler)
			this.temp_attr_pre = "empty";

			// English
			this.synonyms = new List<string>() {
				capacity + "g bucket",
				capacity + " g bucket",
				capacity + " gal bucket",
				capacity + " gallon bucket",
			};

			// hack! allow magical synonym generation for the two different buckets in the game.
			List<string> magicName;
			if (Bucket.names.TryGetValue(this.capacity, out magicName)) {
				this.synonyms.AddRange(magicName);
			}
		}

		/***** INTERACTION METHODS *****/

		public string Fillup () {
			this.fill = this.capacity;
			return "You fill up your " + this.BaseDesc() + ".";
		}

		public string PourOut () {
			this.fill = 0;
			return "You your " + this.BaseDesc() + " out onto the floor.";
		}

		public string PourInto (Bucket toB) {
			if (this.fill == 0) {
				return "You hold your empty " + this.BaseDesc() + " over the other bucket, but nothing comes out.";
			}
			int emptySpaceInB = toB.Capacity - toB.Fill;
			if (emptySpaceInB == 0) {
				return "Your " + toB.ShortDesc() + " is already filled to the brim.";
			}
			// end of shortcuts

			string statString;
			if (emptySpaceInB > this.fill) {
				statString = "You pour the entire contents of your " + this.ShortDesc() + " into the other bucket.";
			} else if (emptySpaceInB == this.fill) {
				statString = "Dumping your " + this.ShortDesc() + " into the other bucket fills it to the brim.";
			} else {
				statString = "You top off your " + toB.BaseDesc() + ", leaving " + this.fill + " gallons in your " + this.ShortDesc() + ".";
			}

			toB.Fill += this.fill;
			this.Fill -= emptySpaceInB;
			return statString;
		}

		public override string PerformAction (string act) {
			switch (act) {
				case "kick":
					// kill player
					return "You kick the bucket. " + Globals.CurrentGlobals.CurrentPlayer.Kill();
				case "drink":
					return "You don't want to drink that.";
				default:
					return base.PerformAction(act);
			}
		}
	}
}

// vi: sw=4 sts=4 ts=4
