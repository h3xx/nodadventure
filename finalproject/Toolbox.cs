/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
	using System;
	using System.Text;
	using System.Linq;

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

		public static string UcFirst (string str) {
			return str.Substring(0,1).ToUpper() + str.Substring(1);
		}

		public static string Join (string[] words) {
			return Join(words, " ");
		}

		public static string Join (string[] words, string glue) {
			StringBuilder acc = new StringBuilder();
			foreach (string word in words) {
				acc.Append(word).Append(glue);
			}
			// remove trailing space
			acc.Remove(acc.Length - glue.Length, glue.Length);

			return acc.ToString();
		}

		public static string WrapString (string text) {
			return WrapString(text, "");
		}

		public static string WrapString (string text, string prefix) {
			return WrapString(text, Console.BufferWidth - 1, prefix);
		}

		public static string WrapString (string text, int width) {
			return WrapString(text, width, "");
		}

		public static string WrapString (string text, int width, string prefix) {
			prefix = "\n" + prefix;

			var lines = text.Split('\n').ToList();
			var result = new StringBuilder(prefix);
			foreach (var line in lines) {
				// (this removes indents)
				//var words = line.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();
				var words = line.Split(' ').ToList();
	
				int lineSize = 0;
				foreach (var word in words) {
					int wordLen = word.Length;
	
					// do we need to start a new line?
					if ((lineSize + wordLen) > width) {
						result.Remove(result.Length - 1, 1); // remove trailing space
						lineSize = 0;
						result.Append(prefix);
					}
	
					result.Append(word).Append(' ');
					lineSize += wordLen + 1;
				}
				result.Remove(result.Length - 1, 1); // remove trailing space
				result.Append('\n');
			}

			result.Remove(result.Length - 1, 1); // remove trailing space

			return result.ToString();
		}
	}
}

