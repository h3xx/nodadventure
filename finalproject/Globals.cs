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
			Reset(new Player());
		}

		public static void Reset (Player currentPlayer) {
			CurrentGlobals = new Globals(currentPlayer);
		}

		public DateTime Time;
		public Player CurrentPlayer;

		public Globals () : this(new Player()) {}

		public Globals (Player currentPlayer) {
			this.CurrentPlayer = currentPlayer;
			this.Time = new DateTime(2012, 6, 5, 23, 20, 0);
		}

		/**
		 * <summary>
		 * Execute a tick, i.e. a game turn.
		 * </summary>
		 */
		public void Tick () {
			this.Time = this.Time.AddSeconds(20);
		}
	}
}

// vi: sw=4 sts=4 ts=4
