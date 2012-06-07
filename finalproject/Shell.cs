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
		public bool WantsQuit = false, WantsRestart = false;

		public Shell () {
		}

		public void FirstShell () {
			Print(Messages.GreetingMsg());
			// give a description of the room, if any
			if (Globals.CurrentGlobals.CurrentPlayer.CurrentRoom != null) {
				Print(Globals.CurrentGlobals.CurrentPlayer.CurrentRoom.EnterRoom());
			}
			this.DoShell();
		}

		private void runCommand (string cmd) {
			string[] cmd_words = cmd.Split(' ');
			string[] nonVerbParts;
			string[] verb = Commands.GetCommandVerb(cmd_words, out nonVerbParts);
			if (verb == null) {
				Print(Messages.RandomDontUnderstand());
				return;
			}

			if (verb[1] == "wait") {
				// do nothing
				return;
			}

			if (verb[1] == "look" &&
			    (nonVerbParts.Length < 1 || nonVerbParts[0] == "room")) {
				if (Globals.CurrentGlobals.CurrentPlayer.CurrentRoom == null) {
					Print(Messages.RandomNoRoom());
					return;
				}
				Print(Globals.CurrentGlobals.CurrentPlayer.CurrentRoom.Look(true));
				return;
			}

			if (verb[1] == "inventory") {
				Print(Globals.CurrentGlobals.CurrentPlayer.Inv.ToString());
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
				Room moveToRoom = Globals.CurrentGlobals.CurrentPlayer.CurrentRoom.Go(moveDir);
				if (moveToRoom == null) {
					Print(Globals.CurrentGlobals.CurrentPlayer.CurrentRoom.MsgFailGo(moveDir));
					return;
				}
				Globals.CurrentGlobals.CurrentPlayer.CurrentRoom = moveToRoom;
				Print(moveToRoom.EnterRoom());
				return;
			}

			// transitive verbs without an object
			if (Synonyms.TransitiveVerbs.Contains(verb[1]) &&
				cmd_words.Length < 2) {
				Print(Messages.RandomNoObjectForVerb(verb[1]));
				return;
			}

			List<Item> its = Commands.GetCommandItems(cmd, Globals.CurrentGlobals.CurrentPlayer.CurrentRoom, Globals.CurrentGlobals.CurrentPlayer.Inv);
			if (its.Count < 1) {
				Toolbox.ArrayShift(ref cmd_words);
				Print(Messages.RandomUnknownObject(Toolbox.Join(cmd_words)));
				return;
			}

			foreach (Item i in its) {
				Print(i.PerformCommand(cmd));
				if (verb[1] == "take") {
					// round about item collection
					if (i.PlayerHas) {
						Globals.CurrentGlobals.CurrentPlayer.CurrentRoom.RemoveItem(i);
						Globals.CurrentGlobals.CurrentPlayer.Inv.AddItem(i);
					}
				} else if (verb[1] == "drop") {
					// round about item loss
					if (!i.PlayerHas) {
						Globals.CurrentGlobals.CurrentPlayer.CurrentRoom.AddItem(i);
						Globals.CurrentGlobals.CurrentPlayer.Inv.RemoveItem(i);
					}
				}
			}

		}

		private bool checkEmptyCmd (string normCmd, out string response) { 
			// what if it's all spaces?
			if (normCmd.Length < 1) {
				++this.numEmptyCmds;
				if (this.numEmptyCmds > threshold_numempty) {
					response = "THAT'S IT! I WARNED YOU!\n" +
						Globals.CurrentGlobals.CurrentPlayer.Kill();
				} else if (this.numEmptyCmds > threshold_numempty_warn) {
					response = Messages.RandomNoCmdMad();
				} else {
					response = Messages.RandomNoCmd();
				}
				return true;
			}
			--this.numEmptyCmds;
			response = null;
			return false;
		}

		private bool checkQuit (string normCmd, out string response) {
			// caveat: return value is whether to stop processing commands (true = error)
			// what if we want to quit?
			if (normCmd.StartsWith("quit")) {
				response = "Quitter.";
				this.WantsQuit = true;
				this.WantsRestart = false;
				return true;
			}
			response = null;
			return false;
		}

		private bool checkRestart (string normCmd, out string response) {
			// caveat: return value is whether to stop processing commands (true = error)
			// what if we want to quit?
			if (normCmd.StartsWith("restart")) {
				response = "Quitter.";
				this.WantsQuit = true;
				this.WantsRestart = true;
				return true;
			}
			response = null;
			return false;
		}

		private bool checkRepeat (string normCmd, out string response, out string finalCmd) {
			// caveat: return value is whether to stop processing commands (true = error)
			// want a repeat of last command
			if (normCmd.StartsWith("again")) {
				if (this.lastCommand != null) {
					// want a repeat
					finalCmd = this.lastCommand;
					response = null;
					return false;
				} else {
					finalCmd = null;
					response = Messages.RandomNoCmd();
					// can't do anything
					return true;
				}
			}
			// does not want to repeat
			this.lastCommand = normCmd;
			finalCmd = normCmd;
			response = null;
			return false;
		}

		private void askRestart () {
			Print("\nDo you want to restart [y/N]? ");
			string inString = Console.ReadLine().ToLower();
			if (inString.StartsWith("y")) {
				this.WantsRestart = true;
			}
		}

		public void DoShell () {
			Console.Write("\n" + prompt);
			string inCmd = Console.ReadLine();

			Globals.CurrentGlobals.Tick();
			inCmd = Commands.NormalizeCommand(inCmd);

			// preliminary command check

			string response;
			if (this.checkEmptyCmd(inCmd, out response) ||
			    this.checkQuit(inCmd, out response) ||
			    this.checkRestart(inCmd, out response)) {
				Print(response);
				return;
			}
			string finalCmd;
			if (this.checkRepeat(inCmd, out response, out finalCmd)) {
				Print(response);
				return;
			}

			// user entered something, however untelligible
			this.runCommand(finalCmd);

			if (Globals.CurrentGlobals.CurrentPlayer.isDead) {
				this.askRestart();
			}
		}

		public static void Print (string msg) {
			Console.WriteLine(Toolbox.WrapString(msg));
		}
	}
}

