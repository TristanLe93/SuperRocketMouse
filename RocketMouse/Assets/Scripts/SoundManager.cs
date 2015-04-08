using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {
	public AudioSource JetpackAudio;
	public AudioSource NextLevelAudio;
	public Toggle SoundMuteToggle;


	void Start () {
		InitialiseSoundSettings();
	}

	void ChangeAudioMuteState(AudioSource audio, bool muteSound) {
		if (audio != null)
			audio.mute = muteSound;
	}

	void InitialiseSoundSettings() {
		bool muteSetting = PersistentData.GetMuteSound();

		SoundMuteToggle.isOn = muteSetting;
		ChangeAudioMuteState(JetpackAudio, muteSetting);
		ChangeAudioMuteState(NextLevelAudio, muteSetting);
	}

	public void ChangeSoundSetting() {
		bool muteSetting = SoundMuteToggle.isOn;
		PersistentData.SetMuteSound(muteSetting);
	}
}
