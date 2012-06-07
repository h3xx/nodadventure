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

		public DateTime Time;

		public Globals () {
			 this.Time = new DateTime(2012, 6, 5, 23, 20, 0);
		}

		public void Tick () {
			this.Time = this.Time.AddSeconds(20);
		}
	}
}

