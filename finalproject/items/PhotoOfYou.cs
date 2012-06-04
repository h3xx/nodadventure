/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class PhotoOfYou : Item {

		private static string lookstring = "You see a picture of yourself at a recent fishing trip. You are holding a red herring and smiling.";

		public PhotoOfYou ()
			: base("photo") {
			this.actionMessages.Add("look", lookstring);
		}
		
		public override string PerformAction (string act) {
			// FIXME
			return null;
		}
	}
}

// vi: sw=4 sts=4