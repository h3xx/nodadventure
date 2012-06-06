/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class Item {
	
		protected Dictionary<string, string> actionMessages = new Dictionary<string, string>() {
			{"take", "Taken."},
			{"drop", "Dropped."},
		};
		public bool PlayerHas = false,
					CanPickUp = true,
					IsImportant = false;

		protected string type,
					     attributes,
					     temp_attr_pre,
					     temp_attr_post;

		protected List<string> synonyms;

		public Item (string type)
			: this (type, null, null, null, null) {
		}

		public Item (string type, List<string> synonyms)
			: this (type, null, null, null, synonyms) {
		}

		public Item (string type, string attributes)
			: this (type, attributes, null, null, null) {
		}

		public Item (string type, string attributes, List<string> synonyms)
			: this (type, attributes, null, null, synonyms) {
		}

		public Item (string type, string attributes, string temp_attr_pre, string temp_attr_post)
			: this (type, attributes, temp_attr_pre, temp_attr_post, null) {
		}

		public Item (string type, string attributes, string temp_attr_pre, string temp_attr_post, List<string> synonyms) {
			this.type = type;
			this.attributes = attributes;
			this.temp_attr_pre = temp_attr_pre;
			this.temp_attr_post = temp_attr_post;
			this.synonyms = synonyms;

		}

		/***** CONSTRUCTION METHODS *****/

		public void AutoGenSynonyms () {
			if (this.synonyms == null) {
				this.synonyms = new List<string>();
			}

			if (this.type != null) {
				if (this.attributes != null) {
					this.synonyms.Add(this.attributes + " " + this.type);
				} else {
					this.synonyms.Add(this.type);
				}
			}
		}

		/**
		 * Gives the long description of the item.
		 *
		 * For example, "shiny 3 gallon bucket with 2 gallons of water in it".
		 */
		public string LongDesc () {
			return this.LongDesc(false);
		}

		public string LongDesc (bool includeArticle) {
			if (this.temp_attr_post != null) {
				string longdesc = this.ShortDesc() + " " + this.temp_attr_post;
				if (includeArticle) {
					return English.Articalize(longdesc);
				}
				return longdesc;
			}
			return this.ShortDesc(includeArticle);
		}

		/**
		 * Gives the short description of the item.
		 *
		 * For example, "shiny 3 gallon bucket".
		 */
		public string ShortDesc () {
			return this.ShortDesc(false);
		}

		public string ShortDesc (bool includeArticle) {
			if (this.temp_attr_pre != null) {
				string shortdesc = this.temp_attr_pre + " " + this.BaseDesc();
				if (includeArticle) {
					return English.Articalize(shortdesc);
				}
				return shortdesc;
			}
			return this.BaseDesc(includeArticle);
		}

		/**
		 * Gives the base description of the item, for use as a noun in a sentence.
		 *
		 * For example, "3 gallon bucket".
		 *
		 */
		public string BaseDesc () {
			return this.BaseDesc(false);
		}

		public string BaseDesc (bool includeArticle) {
			if (this.attributes != null) {
				string basedesc = this.attributes + " " + this.TerseDesc();
				if (includeArticle) {
					return English.Articalize(basedesc);
				}
				return basedesc;
			}
			return this.TerseDesc(includeArticle);
		}

		/**
		 * Gives the very terse description of the item.
		 *
		 * For example, "bucket" or "a bucket".
 		 */
		public string TerseDesc () {
			return this.TerseDesc(false);
		}

		public string TerseDesc (bool includeArticle) {
			if (includeArticle) {
				return English.Articalize(this.type);
			}
			return this.type;
		}

		public virtual string PerformCommand (string cmd) {
			string act = Synonyms.GetVerbBaseSynonym(cmd);
			return this.PerformAction(act);
		}

		public virtual string PerformAction (string act) {
			// FIXME : implement this
			switch (act) {
				case "look":
					return this.Look();
				case "take":
					return this.Take();
				case "drop":
					return this.Drop();
				case "read":
					return this.Read();
				case "use":
					return this.UseIntransitive();
				case "turn on":
					return this.TurnOn();
				case "turn off":
					return this.TurnOff();
				case "lock":
					return this.Lock();
				case "unlock":
					return this.Unlock();
				default:
					return Messages.RandomSilly(this.TerseDesc());
			}
		}

		public virtual string TurnOn () {
			// FIXME : implement this
			string turnOnMsg;
			if (this.actionMessages.TryGetValue("turn on", out turnOnMsg)) {
				return turnOnMsg;
			}
			return Messages.RandomSillyVerb("turn on");
		}

		public virtual string TurnOff () {
			// FIXME : implement this
			string turnOffMsg;
			if (this.actionMessages.TryGetValue("turn off", out turnOffMsg)) {
				return turnOffMsg;
			}
			return Messages.RandomSillyVerb("turn off");
		}

		public virtual string Lock () {
			// FIXME : implement this
			string lockMsg;
			if (this.actionMessages.TryGetValue("lock", out lockMsg)) {
				return lockMsg;
			}
			return Messages.RandomSillyVerb("lock");
		}

		public virtual string Unlock () {
			// FIXME : implement this
			string lockMsg;
			if (this.actionMessages.TryGetValue("unlock", out lockMsg)) {
				return lockMsg;
			}
			return Messages.RandomSillyVerb("unlock");
		}

		public virtual string Read () {
			// FIXME : implement this
			string readMsg;
			if (this.actionMessages.TryGetValue("read", out readMsg)) {
				return readMsg;
			}
			return Messages.RandomSillyVerb("read");
		}

		public virtual string UseIntransitive () {
			// FIXME : implement this
			string useMsg;
			if (this.actionMessages.TryGetValue("use", out useMsg)) {
				return useMsg;
			}
			return Messages.RandomSillyVerb("use");
		}

		public virtual string Take () {
			if (this.PlayerHas) {
				return Messages.RandomAlreadyHave(this.TerseDesc());
			}
			if (this.CanPickUp) {
				this.PlayerHas = true;
				string pickupMsg;
				if (this.actionMessages.TryGetValue("take", out pickupMsg)) {
					return pickupMsg;
				}
				return "Taken.";
			}
			// can't pick up
			return this.MsgFailPickup();
		}

		public virtual string Drop () {
			if (!this.PlayerHas) {
				return Messages.RandomDontHave(this.TerseDesc());
			}
			this.PlayerHas = false;
			string dropMsg;
			if (this.actionMessages.TryGetValue("drop", out dropMsg)) {
				return dropMsg;
			}
			return "Dropped.";
		}

		public virtual string MsgFailPickup () {
			// FIXME : implement this
			return Messages.RandomFailure();
		}

		public virtual string MsgFailDrop () {
			// FIXME : implement this
			return Messages.RandomFailure();
		}

		public virtual string Look () {
			// FIXME : implement this
			string lookMsg;
			if (this.actionMessages.TryGetValue("look", out lookMsg)) {
				return lookMsg;
			}
			return Messages.RandomThingDeclarativeSinglular(this.TerseDesc());
		}

		public bool MatchesSynonym (string syn) {
			if (syn == null) return false;

			return this.synonyms.Contains(syn);
		}


		/* (this is a bad idea)
		public static bool operator == (string a, Item b) {
			return b == a; }
		public static bool operator != (string a, Item b) {
			return !(b == a); }
		public static bool operator != (Item a, string b) {
			return !(a == b); }
		public static bool operator == (Item a, string b) {
			return b != null && a.synonyms.Contains(b.ToLower());
		}
		*/

		public override string ToString () {
			return this.LongDesc();
		}
	}
}

// vi: sw=4 sts=4