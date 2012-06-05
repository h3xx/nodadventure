/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	class Globals {
		public static Globals CurrentGlobals = new Globals();

		public static void Reset () {
			CurrentGlobals = new Globals();
		}

		public DateTime Time = new DateTime(2012, 6, 5, 21, 20, 0);

		public Globals () {
		}

		public void Tick () {
			this.Time.AddSeconds(60);
		}
	}
}

