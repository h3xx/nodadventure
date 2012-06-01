/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	class Toolbox {
		// all this just get Perl functionality?
		public static void ArrayShift<T> (ref T[] ary) {
			ArrayShift<T>(ref ary, 1);
		}

		public static void ArrayShift<T> (ref T[] ary, int length) {
			// note: this is terribly inefficient, but so's C#
			int newSize = ary.Length - length;
			Array.ConstrainedCopy(ary, length, ary, 0, newSize);
			Array.Resize<T>(ref ary, newSize);
		}

		/* TODO : is this stupid? */
		public static void ArrayPop<T> (ref T[] ary) {
			ArrayPop<T>(ref ary, 1);
		}

		public static void ArrayPop<T> (ref T[] ary, int length) {
			int newSize = ary.Length - length;
			Array.Resize<T>(ref ary, newSize);
		}
	}
}

