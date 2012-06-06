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

		public RoomKey ()
			: base (
				"room key",
				new List<string>() {
					"key",
					"small key",
					"small brass key",
					"brass key",
				}
			) {

			this.actionMessages.Add("look", "This is a small brass key.");
			this.actionMessages.Add("read", "\"Room 202.\"");
		}
	}
}

