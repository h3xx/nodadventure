/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class Toothbrush
		: Item {
		public Toothbrush ()
			: base (
				"toothbrush",
				new List<string>() {
					"brush",
				}
			) {

			this.actionMessages.Add("look", "You see your toothbrush.");
		}
	}
}

