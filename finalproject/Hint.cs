/*
Copyright (C) 2012 Dan Church.
License GPLv3+: GNU GPL version 3 or later (http://gnu.org/licenses/gpl.html).
This is free software: you are free to change and redistribute it. There is NO
WARRANTY, to the extent permitted by law.
*/
namespace finalproject {
    using System;
    using System.Collections.Generic;

	class Hint {
		private static Random rng = new Random();

		private static Dictionary<int, string> hints = new Dictionary<int, string>() {
			{1, "one"},
			{3, "three"},
			{7, "seven"},
		};

		private static string noMoreHints = "No more hints.";

		private List<int> availableHints = new List<int>();

		public Hint () {
			this.resetUsedHints();
		}

		private void resetUsedHints () {
			this.availableHints.Clear();
			this.availableHints.AddRange(hints.Keys);
		}

		/**
		 * @param hintIdx The index of the available hint we're going to use.
		 * @return The index of the used hint.
		 */
		private int markHintUsed (int hintIdx) {
			if (this.availableHints.Count == 0) {
				return -1;
			}

			int hId = this.availableHints[hintIdx];
			this.availableHints.RemoveAt(hintIdx);
			return hId;
		}

		public string RandomHint () {
			int hintIdx = rng.Next(this.availableHints.Count);
			int hId = this.markHintUsed(hintIdx);

			if (hId == -1) {
				return noMoreHints;
			}

			string hint;
			if (hints.TryGetValue(hId, out hint)) {
				return hint;
			}

			return null;
		}

		public override string ToString () {
			return this.RandomHint();
		}
	}
}

// vi: sw=4 sts=4 ts=4
