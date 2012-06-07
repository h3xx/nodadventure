/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	class Game {
		private Shell shell;
		private Player player;
		private RoomLayout layout;

		public Game () {
			this.startGame();
			this.layout = new RoomLayout();
			this.player = new Player(this.layout.StartingPoint);
			this.shell = new Shell(this.player);
			this.player = new Player();
			this.shell.FirstShell();
			while (!this.player.isDead && !this.shell.wantsExit) {
				this.shell.DoShell();
			}
		}

		private void startGame () {
			Globals.Reset();
		}
	}
}

