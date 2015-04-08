using UnityEngine;
using System.Collections;

public class LaserSpinScript : MonoBehaviour {
	public float rotationSpeed = 30.0f;
	public bool rotateClockwise = true;
	public bool isSpinning = false;

	// Update is called once per frame
	void FixedUpdate () {
		if (isSpinning) {
			if (rotateClockwise)
				transform.RotateAround(
					transform.position, Vector3.back, rotationSpeed * Time. fixedDeltaTime);
			else 
				transform.RotateAround(
					transform.position, Vector3.forward, rotationSpeed * Time. fixedDeltaTime);

		}
	}
}
