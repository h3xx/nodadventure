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
		public bool WantsQuit = false;

		public Shell (Player player) {
			this.player = player;
		}

		public void RunCommand (string cmd) {
			string[] verb = Commands.GetCommandVerb(cmd);
			if (verb == null) {
				Print(Messages.RandomDontUnderstand());
				return;
			}

			string[] cmd_words = cmd.Split(' ');

			if (verb[1] == "wait") {
				// do nothing
				return;
			}

			if (verb[1] == "look" &&
			    (cmd_words.Length < 2 || cmd_words[1] == "room")) {
				if (this.player.CurrentRoom == null) {
					Print(Messages.RandomNoRoom());
					return;
				}
				Print(this.player.CurrentRoom.Look(true));
				return;
			}

			// unrecognized direction
			if (verb[1] == "go") {
				Print("I don't know how to go in that direction.");
				return;
			}

			// movement commands
			if (verb[1].StartsWith("go ")) {
				string moveDir = verb[1].Split(' ')[1];
				Room moveToRoom = this.player.CurrentRoom.Go(moveDir);
				if (moveToRoom == null) {
					Print(this.player.CurrentRoom.MsgFailGo(moveDir));
					return;
				}
				this.player.CurrentRoom = moveToRoom;
				Print(moveToRoom.EnterRoom());
				return;
			}

			// transitive verbs without an object
			if (Synonyms.TransitiveVerbs.Contains(verb[1])) {
				if (cmd_words.Length < 2) {
					Print("transitive verb `" + verb[1] + "' w/o object");
					return;
				}

				List<Item> its = Commands.GetCommandItems(cmd, player.CurrentRoom, player.Inv);
				if (its.Count < 1) {
					Print(Messages.RandomUnknownObject(cmd_words.ToString()));
					return;
				}
				foreach (Item i in its) {
					Print(i.PerformCommand(cmd));
				}
			}

			Print(Messages.RandomDontUnderstand());

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
				this.WantsQuit = true;
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

