using UnityEngine;
using System.Collections.Generic;

public class GenerateObjectsScript : MonoBehaviour {
	public GameObject[] Level1Objects;
	public GameObject[] Level2Objects;
	public GameObject[] Level3Objects;
	public GameObject[] Level4Objects;
	public GameObject[] Level5Objects;
	
	private List<GameObject[]> levelObjects;
	private GameObject[] availableObjects;    
	public List<GameObject> objects;

	private float objectsSpacing = 11.36f;
	private float bufferRate = 1.2f;

	void Start () {
		levelObjects = new List<GameObject[]>();
		levelObjects.Add(Level1Objects);
		levelObjects.Add(Level2Objects);
		levelObjects.Add(Level3Objects);
		levelObjects.Add(Level4Objects);
		levelObjects.Add(Level4Objects);

		availableObjects = levelObjects[0];
	}

	void FixedUpdate () {
		GenerateObjectsIfRequired();
	}

	// adds a random object to the screen
	void AddObject(float lastObjectX) {
		int randomIndex = Random.Range(0, availableObjects.Length);
		GameObject obj = (GameObject)Instantiate(availableObjects[randomIndex]);

		// determine next object position
		float objectPositionX = lastObjectX + (objectsSpacing * bufferRate);
		obj.transform.position = new Vector3(objectPositionX, obj.transform.position.y, 0); 

		objects.Add(obj);            
	}

	void GenerateObjectsIfRequired() {
		float playerX = transform.position.x;        
		float removeObjectsX = playerX - objectsSpacing;
		float addObjectX = playerX + objectsSpacing;
		float farthestObjectX = 0;

		List<GameObject> objectsToRemove = new List<GameObject>();

		// objects on far left screen are moved to objectsToRemove list
		foreach (var obj in objects) {
			float objX = obj.transform.position.x;
			farthestObjectX = objX;

			if (objX < removeObjectsX)            
				objectsToRemove.Add(obj);
		}
		
		// remove each object in objectsToRemove
		foreach (var obj in objectsToRemove) {
			objects.Remove(obj);
			Destroy(obj);
		}
		
		// add new object
		if (farthestObjectX < addObjectX)
			AddObject(farthestObjectX);
	}

	public void LoadNextLevelObjects(int level) {
		availableObjects = levelObjects[level];
		bufferRate += 0.2f;
	}

}
