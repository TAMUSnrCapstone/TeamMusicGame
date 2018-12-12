using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game {

    public static Game current;
		public static float score;
		public static int threshold;

		public static void updateScore(float s) {
			score = s;
		}

		public static void updateThreshold(int t) {
			threshold = t;
		}

		public Game() {
			
		}
	}
