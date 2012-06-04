/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Media;
	using System.Collections.Generic;
	using System.IO;
	class MediaPlayer {
		private static readonly string mediaDir = "../media";
		private static Dictionary<string, string> sounds =
		new Dictionary<string, string>() {
			{"creepy",	"creepy.wav"},
			{"creepy1",	"creepy1.wav"},
			{"creepy2",	"creepy2.wav"},
		};
		private static readonly SoundPlayer sp = new SoundPlayer();
		static bool PlaySound (string soundName) {
			sp.Stop();
			string wavLocation;
			if (sounds.TryGetValue(soundName, out wavLocation)) {
				string wavPath = mediaDir + "/" + wavLocation;
				try {
					sp.SoundLocation = wavPath;
					sp.PlayLooping();
				} catch (FileNotFoundException e) {
					Console.Error.WriteLine("Failed to load sound {0}: {1}", wavPath, e.ToString());
					return false;
				}
			} else {
				Console.Error.WriteLine("FIXME: Failed to find sound named `{0}'", soundName);
				return false;
			}
			return true;
		}

		static void StopSound () {
			sp.Stop();
		}
	}
}

// vi: sw=4 sts=4