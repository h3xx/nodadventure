/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	class AlarmClock
		: Item {
		public AlarmClock ()
			: base("alarm clock", "small red",
			      new List<string>() {"clock", "watch", "alarm"}) {
			this.CanPickUp = false;
		}
	}
}

