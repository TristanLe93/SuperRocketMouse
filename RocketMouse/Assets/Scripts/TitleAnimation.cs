using UnityEngine;
using System.Collections;

public class TitleAnimation : MonoBehaviour {
	public ParticleSystem MouseJetpack;
	public AudioSource JetpackAudio;

	public void FireMouseJetpack() {
		MouseJetpack.emissionRate = 300f;
		MouseJetpack.enableEmission = true;
		JetpackAudio.Play();
	}

	public void FireMouseJetpackFloat() {
		MouseJetpack.emissionRate = 150f;
	}
}
