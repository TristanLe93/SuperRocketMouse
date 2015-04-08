using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform targetObjectTransform;
	private float distanceToTarget;

	void Start () {
		// calculate distance from camera to targetObject
		float cameraPosX = transform.position.x;
		float targetObjectPosX = targetObjectTransform.position.x;
		distanceToTarget = cameraPosX - targetObjectPosX;
	}
	

	void Update () {
		// change camera x pos with the mouse, following it
		float targetObjectX = targetObjectTransform.position.x;
		
		Vector3 newCameraPosition = transform.position;
		newCameraPosition.x = targetObjectX + distanceToTarget;
		transform.position = newCameraPosition;
	}
}
