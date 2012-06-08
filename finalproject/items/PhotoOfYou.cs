/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class PhotoOfYou
		: Item {

		private static readonly string
			lookString = "You see a picture of yourself at a recent fishing trip. You are holding a red herring and smiling.",
			readString = "As you examine the picture looking for something to read on it, you notice that your hat reads \"5 - (3 - 2) = 4\" which you find very strange.";

		public PhotoOfYou ()
			: base(
				"photo",
				new List<string>() {
					"photograph",
					"picture",
					"herring",
				}
			) {

			this.CanPickUp = false;
			this.actionMessages.Add("look", lookString);
			this.actionMessages.Add("read", readString);
		}
	}
}

// vi: sw=4 sts=4 ts=4
