/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	class PhotoOfYou : Item {
		public PhotoOfYou ()
			: base("photo") {
		}
		
		public override string Look () {
			return "You see a picture of yourself at a recent fishing trip. You are holding a red herring and smiling.";
		}
		
		public override string PerformAction (string act) {
			// FIXME
			return null;
		}
	}
}

// vi: sw=4 sts=4