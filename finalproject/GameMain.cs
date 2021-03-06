/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
    using System;
    using System.Collections.Generic;

    class GameMain {
    	public static Random rng = new Random();
    	public static Player pl = new Player();

		static int Main() {
			runDemos();
			return 0;
		}

		private static void runDemos () {
			//roomDemo();
			//englishDemo();
			//cmdDemo();
			//pickupDemo();
			//actionDemo();
			//verboseRoomDemo();
			//verboseExitDemo();
			//movementDemo();
			//revealObjectDemo();
			Game foo = new Game();
			holdTerminal();
		}

		private static void revealObjectDemo () {
			Item rmk = new RoomKey();

			Console.WriteLine("> look");
			Console.WriteLine(rmk.Look());
			Console.WriteLine("> take");
			Console.WriteLine(rmk.Take());
			Console.WriteLine("> close");
			Console.WriteLine(rmk.Close());
			Console.WriteLine("> take");
			Console.WriteLine(rmk.Take());
			Console.WriteLine("> open");
			Console.WriteLine(rmk.Open());
			Console.WriteLine("> take");
			Console.WriteLine(rmk.Take());
			Console.WriteLine("> close");
			Console.WriteLine(rmk.Close());
			Console.WriteLine("> open");
			Console.WriteLine(rmk.Open());
			Console.WriteLine("> take");
			Console.WriteLine(rmk.Take());
			Console.WriteLine("> look");
			Console.WriteLine(rmk.Look());
		}

		private static void movementDemo () {
			Inventory plr = new Inventory(true, new List<Item>() {
				new Bucket(3),
				new Bucket(5),
			});

			RoomLayout rms = new RoomLayout();


			string[] cmds = new string[] {
				//"n",
				//"e",
				//"go n",
				//"look",
				//"search",
				//"pick",
				//"take",
				//"steal",
				"take small bucket",
			};
			Console.WriteLine(rms.StartingPoint.ToString());
			List<Item> it;
			string[] ve;
			foreach (string c in cmds) {
				ve = Commands.GetCommandVerb(c);
				it = Commands.GetCommandItems(c,rms.StartingPoint, plr);
				Console.WriteLine("in: {0}", c);
				if (ve != null) {
					Console.WriteLine("  verb: {0} ({1})", ve[0], ve[1]);
				} else {
					Console.WriteLine("  (unrecognized verb)");
				}
				if (it.Count > 0) {
					Console.WriteLine("  item: {0}", it[0]);
				} else {
					Console.WriteLine("  (unrecognized item)");
				}
			}
		}

		private static void verboseExitDemo () {
			Room myroom = new MyHotelRoom(); 
			Room myBathroom = new MyHotelRoomBathroom();

			// connect room to bathroom
			myroom.ExitsHere.AddExit("e", "doorway", "leading to a small bathroom", myBathroom);
			myBathroom.ExitsHere.AddExit("w", "doorway", "leading back into your hotel room", myroom);

			Room hallwayMid = new HallwayFloorTwoMid();

			// connect room to hallway
			myroom.ExitsHere.AddExit("n", "door", hallwayMid);
			hallwayMid.ExitsHere.AddExit("s", "door", myroom);

			Room hallwayWest = new HallwayFloorTwoWest();

			// connect mid <=> west hallways
			hallwayWest.ExitsHere.AddExit("e", null, "From here the hallway continues east.", hallwayMid);
			hallwayMid.ExitsHere.AddExit("w", null, "From here the hallway continues east and west.", hallwayWest);

			Console.WriteLine(hallwayMid.Look(true));

		}

		private static void verboseRoomDemo () {
			Room foo = new Room("Test Chamber",
				"This is a small chamber. In the dim light you can see the walls "+
				"expand and contract as if they were unstable. If you strain your "+
				"ears you can just barely hear someone typing furiously on a keyboard."
			);
			foo.ExitsHere.AddExit("ne", "doorway", foo);
			foo.ExitsHere.AddExit("nw", "doorway", foo);
			foo.ExitsHere.AddExit("se", "doorway", "leading to a small closet", foo);

			Console.WriteLine(foo.Look(true));
		}

		private static void actionDemo () {
			PhotoOfYou p = new PhotoOfYou();
			Console.WriteLine(Toolbox.UcFirst(p.ToString()));
			Console.WriteLine(p.Take());
			Console.WriteLine(p.Take());
			Console.WriteLine(p.Look());
		}

		private static void pickupDemo () {
			Bucket b = new Bucket(3);
			Console.WriteLine(b.ToString());
			Console.WriteLine(b.Take());
			b.PlayerHas = true;
			Console.WriteLine(b.Take());
		}

/*
		private static void commandDemo () {
			string cmd = "look at bucket";
			string verb = Commands.GetCommandVerb(cmd);
			//string obj = Commands.GetCommandObject(cmd);
			Console.WriteLine("command: '{0}', verb: '{1}', object: '{2}'", cmd, verb, obj);
		}
		 */

		private static void cmdDemo () {
			List<string[]> foo = Commands.GetCommandParts("toss the yellow ball at the wumpus");
			foreach (string[] bar in foo) {
				if (bar != null) {
					Console.WriteLine("word: {0} ({1})", bar[0], bar[1]);
				}
			}
		}

		private static void hintsDemo () {
			/* HINTS TEST */
			Hint foo = new Hint();
			Console.WriteLine(foo.RandomHint());
			Console.WriteLine(foo.RandomHint());
			Console.WriteLine(foo.RandomHint());
			Console.WriteLine(foo.RandomHint());
			Console.WriteLine(foo);
			Console.WriteLine(foo);
			Console.WriteLine(foo);
			Console.WriteLine(foo);
		}

		private static void englishDemo () {
			/* ENGLISH TEST */
			Bucket b = new Bucket(3);
			b.Fill = 5;
			Console.WriteLine("I am holding " + b.LongDesc(true));
			Console.WriteLine("I am holding " + b.ShortDesc(true));
			Console.WriteLine("I am holding " + b.BaseDesc(true));
			Console.WriteLine("emptying the " + b.TerseDesc() + "...");
			b.Fill = 0;
			Console.WriteLine("now I am holding " + b.LongDesc(true));
			Bucket a = new Bucket(8);
			a.Fillup();
			Console.WriteLine("now I am holding " + a.LongDesc(true));
			Console.WriteLine("now I am holding " + a.ShortDesc(true));
			Console.WriteLine("now I am holding " + a.BaseDesc(true));

			Console.WriteLine("looking at it...");
			Console.WriteLine(a.Look());
		}

		private static void gallonsPuzzleDemo () {
			/* GALLONS PUZZLE TEST */
			GallonPuzzle p = new GallonPuzzle();
			Bucket small = new Bucket(3);
			Bucket large = new Bucket(5);
			Console.WriteLine("I am holding:\n  " + small.LongDesc(true) + "\n  and " + large.LongDesc(true));
			// step 1
			Console.WriteLine(large.Fillup());
			// step 2
			Console.WriteLine(large.PourInto(small));
			Console.WriteLine("I am holding:\n  " + small.LongDesc(true) + "\n  and " + large.LongDesc(true));
			// step 3
			Console.WriteLine(small.PourOut());
			// step 4
			Console.WriteLine(large.PourInto(small));
			// step 5
			Console.WriteLine(large.Fillup());
			// step 6
			Console.WriteLine(large.PourInto(small));

			Console.WriteLine("I am holding:\n  " + small.LongDesc(true) + "\n  and " + large.LongDesc(true));
		}

		private static void inventoryDemo () {
			/* INVENTORY TEST */
			Inventory inv = new Inventory(true);
			Item s = new Item("sword", "shiny");
			s.AutoGenSynonyms();
			inv.AddItem(s);
			Bucket b = new Bucket(3);
			inv.AddItem(b);
			Console.WriteLine(inv);
		}

#if false
		private static void roomDemo () {

			/* ROOM TEST */
			Inventory inv = new Inventory(false);
			Item f;
			f = new Item("flask", "blue");
			inv.AddItem(f);
			f = new Item("eel", "electric");
			inv.AddItem(f);
			f = new Item("sword");
			inv.AddItem(f);

			Inventory invb = new Inventory(false);
			f = new Item("broom");
			invb.AddItem(f);
			f = new Item("bucket");
			invb.AddItem(f);

			Room foo = new Room("Test Chamber",
				"This is a small chamber. In the dim light you can see the walls "+
				"expand and contract as if they were unstable. If you strain your "+
				"ears you can just barely hear someone typing furiously on a keyboard.",
				inv
			);
			Closet bar = new Closet("Test Closet",
				"It is too dark to see.",
				"You are standing in a small broom closet.",
				invb
			);

			foo.Exits.AddExit("n", "doorway", bar);
			foo.Exits.AddExit("u", "ladder", foo);
			foo.Exits.AddExit("d", "ladder", foo);
			foo.Exits.AddExit("s", foo);

			Console.WriteLine("Entering room...");
			Console.WriteLine(foo.EnterRoom());
			Console.WriteLine("Entering room again...");
			Console.WriteLine(foo.EnterRoom());

			Console.WriteLine("Entering closet...");
			Console.WriteLine(bar.EnterRoom());

			Console.WriteLine("Let there be light...");
			Console.WriteLine(bar.TurnOnLight());
			Console.WriteLine(bar.Look());

		}
#endif

		private static void holdTerminal () {
			Console.WriteLine("Press any key...");
			Console.ReadLine();
		}
    }
}

// vi: sw=4 sts=4 ts=4
