/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
    using System;
    using System.Collections.Generic;
	class GallonPuzzle {
		private bool isSolved = false;
		/**
		 * @return the text description of the action.
		 */

		public bool CheckBuckets (Bucket A, Bucket B) {
			return A.Fill == 4 || B.Fill == 4;
		}

		public bool CheckSolved () {
			return this.isSolved;
		}
	}
}

// vi: sw=4 sts=4 ts=4
