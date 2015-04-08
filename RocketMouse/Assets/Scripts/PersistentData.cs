using UnityEngine;
using System.Collections;

public class PersistentData: MonoBehaviour {
	// default values
	private static string HIGHSCORE = "Highscore";
	private static string MUSIC_VOLUME = "Volume";
	private static string MUTESOUND = "MuteSounds"; 
	private static string LOWSYSTEM = "LowSystem";

	private static int highscore = 0;
	private static float musicVolume = 0.15f;
	private static int TRUE = 1;
	private static int FALSE = 0;

	public static int GetHighscore() {
		return PlayerPrefs.GetInt(HIGHSCORE, highscore);
	}
	
	public static void SetHighscore(int value) {
		PlayerPrefs.SetInt(HIGHSCORE, value);
	}

	public static float GetMusicVolume() {
		return PlayerPrefs.GetFloat(MUSIC_VOLUME, musicVolume);
	}

	public static void SetMusicVolume(float value) {
		PlayerPrefs.SetFloat(MUSIC_VOLUME, value);
	}


	public static bool GetMuteSound() {
		return PlayerPrefs.GetInt(MUTESOUND, FALSE) == TRUE;
	}

	public static void SetMuteSound(bool muteSound) {
		if (muteSound)
			PlayerPrefs.SetInt(MUTESOUND, TRUE);
		else 
			PlayerPrefs.SetInt(MUTESOUND, FALSE);
	}

	public static bool GetLowSystemSetting() {
		return PlayerPrefs.GetInt(LOWSYSTEM, FALSE) == TRUE;
	}

	public static void SetLowSystemSetting(bool lowSystem) {
		if (lowSystem)
			PlayerPrefs.SetInt(LOWSYSTEM, TRUE);
		else 
			PlayerPrefs.SetInt(LOWSYSTEM, FALSE);
	}
}
