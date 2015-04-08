using UnityEngine;
using UnityEngine.UI;

public class LowSystemPerformance : MonoBehaviour {
	public Toggle LowSystemToggle;


	void Start () {
		bool lowSystemSetting = PersistentData.GetLowSystemSetting();
		LowSystemToggle.isOn = lowSystemSetting;
		ChangeTargetFrameRate();
	}

	public void ChangeTargetFrameRate() {
		if (LowSystemToggle.isOn)
			Application.targetFrameRate = 30;	//FPS
		else 
			Application.targetFrameRate = 60;	//FPS
	}

	public void ChangeFramesSettings() {
		bool lowSystemSetting = LowSystemToggle.isOn;
		PersistentData.SetLowSystemSetting(lowSystemSetting);
	}
}
