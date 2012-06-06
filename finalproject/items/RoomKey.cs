/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class RoomKey
		: Item {

		private static List<string> synonyms_beforeSearch = new List<string>() {
			"pocket",
			"coat pocket",
			"trenchcoat pocket",
		};

		private static List<string> synonyms_afterSearch = new List<string>() {
			// after
			"key",
			"room key",
		};

		private static string type_beforeSearch = "pocket",
							  type_afterSearch = "room key",

							  lookstring_beforeSearch = "It's a small pocket.",
							  lookstring_afterSearch = "You see a small brass key.",

						      readstring_beforeSearch = "There's nothing to read on it.",
							  readstring_afterSearch = "\"Room 202.\"",

							  openstring_beforeSearch = "Opening the pocket reveals a small key.",
							  openstring_afterSearch = "You can't open that!",

							  closestring_beforeSearch = "You close the pocket.",
							  closestring_afterSearch = "You can't close that!";

		private bool isRevealed = false;

		public RoomKey ()
			: base (
				type_beforeSearch,
				synonyms_beforeSearch
			) {

			this.CanPickUp = false;

			this.actionMessages.Add("look", lookstring_beforeSearch);
			this.actionMessages.Add("read", readstring_afterSearch);
			this.actionMessages.Add("open", openstring_beforeSearch);
			this.actionMessages.Add("search", openstring_beforeSearch);
			this.actionMessages.Add("close", closestring_beforeSearch);
		}

		private void setActMsg (string act, string msg) {
			this.actionMessages.Remove(act);
			this.actionMessages.Add(act, msg);
		}

		private void setRevealed (bool revealed) {
			if (this.isRevealed = revealed) { // [sic]
				this.CanPickUp = true;
				this.type = type_afterSearch;
				this.synonyms = synonyms_afterSearch;
				this.setActMsg("look", lookstring_afterSearch);
				this.setActMsg("read", readstring_afterSearch);
				this.setActMsg("open", openstring_afterSearch);
				this.setActMsg("search", openstring_afterSearch);
				this.setActMsg("close", closestring_afterSearch);
			} else {
				this.CanPickUp = false;
				this.type = type_beforeSearch;
				this.synonyms = synonyms_beforeSearch;
				this.setActMsg("look", lookstring_beforeSearch);
				this.setActMsg("read", readstring_beforeSearch);
				this.setActMsg("open", openstring_beforeSearch);
				this.setActMsg("close", closestring_beforeSearch);
			}
		}

		public override string Open () {
			if (this.PlayerHas) {
				return base.Open();
			}
			if (!this.isRevealed) {
				// just use the action message
				// note: must occur before setRevealed happens to get the message right
				string openMsg = base.Open();
				this.setRevealed(true);
				return openMsg;
			}
			return "The pocket is already open.";
		}

		public override string Close () {
			if (this.PlayerHas) {
				return base.Close();
			}
			if (this.isRevealed) {
				// just use the action message
				// note: must occur before setRevealed happens to get the message right
				string closeMsg = base.Close();
				this.setRevealed(false);
				return closeMsg;
			}
			return "The pocket is already closed.";
		}

		public override string MsgFailPickup () {
			return "The pocket is much happier on the coat.";
		}
	}
}

