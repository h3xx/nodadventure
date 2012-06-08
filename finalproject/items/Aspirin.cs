/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Collections.Generic;
	class Aspirin
		: Item {

		public Aspirin ()
			: base (
				"bottle of pills",
				new List<string>() {
					"aspirin",
					"acetaminophen",
					"pain killers",
					"painkillers",
					"painpills",
					"medication",
					"pills",
					"bottle",
				}
			) {

			this.actionMessages.Add("look", "A bottle of pills labelled \"Acetaminophen.\"");
			this.actionMessages.Add("read", "\"Acetaminophen.\"");
		}
	}
}

// vi: sw=4 sts=4 ts=4
