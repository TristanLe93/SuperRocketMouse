using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeController : MonoBehaviour {
	public AudioSource MusicSource;
	public Slider VolumeSlider;
	
	void Awake () {
		float volume = PersistentData.GetMusicVolume();
		MusicSource.volume = volume;
		VolumeSlider.value = volume;
	}

	public void SaveMusicVolumeData() {
		PersistentData.SetMusicVolume(MusicSource.volume);
	}
}
