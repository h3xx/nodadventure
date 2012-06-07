/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class Shell {
		private static readonly string prompt = "> ";

		private static int threshold_numempty = 10,
						   threshold_numempty_warn = 8;
		private int _numEmptyCmds;
		private int numEmptyCmds {
			get {
				return this._numEmptyCmds;
			}
			set {
				if (value < 0) {
					this._numEmptyCmds = 0;
				} else {
					this._numEmptyCmds = value;
				}
			}
		}

		private string lastCommand;
		private Player player;
		public bool wantsExit = false;

		public Shell (Player player) {
			this.player = player;
		}

		public void RunCommand (string cmd) {
			if (cmd == "look" || cmd == "look room") {
				if (this.player.CurrentRoom == null) {
					Print(Messages.RandomNoRoom());
					return;
				}
				Print(this.player.CurrentRoom.Look(true));
				return;
			}

			string[] verb = Commands.GetCommandVerb(cmd);

			if (verb == null) {
				Print(Messages.RandomDontUnderstand());
			}

			if (verb != null) {
				Print("verb: " + verb[1]);
			}

			List<Item> its = Commands.GetCommandItems(cmd, player.CurrentRoom, player.Inv);
			foreach (Item i in its) {
				Print("you mentioned: " + i.ToString());
			}
		}

		public void FirstShell () {
			Print(Messages.GreetingMsg());
			// give a description of the room, if any
			if (this.player.CurrentRoom != null) {
				Print(this.player.CurrentRoom.EnterRoom());
			}
			this.DoShell();
		}

		public void DoShell () {
			Console.Write("\n" + prompt);
			string inCmd = Console.ReadLine();

			Globals.CurrentGlobals.Tick();
			inCmd = Commands.NormalizeCommand(inCmd);

			// preliminary command check

			// what if it's all spaces?
			if (inCmd.Length < 1) {
				++this.numEmptyCmds;
				if (this.numEmptyCmds > threshold_numempty) {
					Print("THAT'S IT! I WARNED YOU!");
					Print(this.player.Kill());
				} else if (this.numEmptyCmds > threshold_numempty_warn) {
					Print(Messages.RandomNoCmdMad());
				} else {
					Print(Messages.RandomNoCmd());
				}
				return;
			}
			--this.numEmptyCmds;

			// what if we want to quit?
			if (inCmd.StartsWith("quit")) {
				Print("Quitter.");
				this.wantsExit = true;
				return;
			}

			// user entered something, however untelligible
			if (inCmd.StartsWith("again")) {
				if (this.lastCommand != null) {
					// want a repeat
					inCmd = this.lastCommand;
				} else {
					Print(Messages.RandomNoCmd());
					// can't do anything
					return;
				}
			} else {
				this.lastCommand = inCmd;
			}

			this.RunCommand(inCmd);
		}

		public static void Print (string msg) {
			Console.WriteLine(Toolbox.WrapString(msg));
		}
	}
}

