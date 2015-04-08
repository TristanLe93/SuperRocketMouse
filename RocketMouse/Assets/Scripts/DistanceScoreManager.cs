using UnityEngine;
using UnityEngine.UI;
using System;

public class DistanceScoreManager : MonoBehaviour {
	private static int distanceScore;
	private static Text text;
	
	void Awake () {
	 	text = GetComponent<Text>();
		text.text = "0m";
	}

	public static void UpdateDistanceScore(double distance) {
		// distance buffer as the player starts at xpos -3.5
		distanceScore = System.Convert.ToInt32(distance) + 3;

		text.text = String.Format("{0:n0}", distanceScore) + "m";
	}

	public static int GetDistanceScore() {
		return distanceScore;
	}
}
