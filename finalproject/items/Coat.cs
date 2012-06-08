/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class Coat
		: Item {

		private RoomKey keyInPockey = new RoomKey();

		public Coat ()
			: base (
				"coat",
				new List<string>() {
					"my coat",
					"overcoat",
					"trenchcoat",
					"overcoat",
					// things on the coat
					"pocket",
					"key",
					"brass key",
					"room key",
				}
			) {

			this.actionMessages.Add("look", "This is your coat. You don't know how you recognize it, but it's the most familiar thing you've seen so far. There is a pocket on the inner left side.");
			this.actionMessages.Add("read", "\"Burlington.\"");
		}

		public override string PerformCommand (string cmd) {
			if (cmd.Contains("pocket") || cmd.Contains("key")) {
				// HACK! perform it on the pocket
				return this.keyInPockey.PerformCommand(cmd);
			}
			return base.PerformCommand(cmd);
		}
	}
}

// vi: sw=4 sts=4 ts=4
