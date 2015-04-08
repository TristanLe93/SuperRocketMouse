using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneratorRoomScript : MonoBehaviour {
	public GameObject[] availableRooms;
	public List<GameObject> currentRooms;

	private List<GameObject> roomPool;

	private float firstRoomEndX;
	private float lastRoomStartX;
	private float roomWidth;
	private float playerPosX;


	void Start() {
		playerPosX = transform.position.x;
		roomWidth = availableRooms[0].transform.FindChild("floor").localScale.x;
		firstRoomEndX = GetFirstRoomEndX();
		lastRoomStartX = GetLastRoomStartX();

		// initialise objectpool
		roomPool = new List<GameObject>();
		foreach (GameObject room in availableRooms) {
			GameObject initRoom = (GameObject)Instantiate(room);
			initRoom.SetActive(false);
			roomPool.Add(initRoom);
		}
	}

	void FixedUpdate () {   
		playerPosX = transform.position.x;

		// if the player has passed the first room, delete it
		if (FirstRoomHasPassed()) {
			RemoveRoom();
		}

		// if the player has entered the last room, add a new room
		if (LastRoomHasEntered()) {
			AddRoom();
		}
	}

	float GetFirstRoomEndX() {
		return currentRooms[0].transform.position.x + roomWidth;
	}

	float GetLastRoomStartX() {
		int lastRoomIndex = currentRooms.Count - 1;
		return currentRooms[lastRoomIndex].transform.position.x - roomWidth;
	}

	float GetNewRoomPosition() {
		int lastRoomIndex = currentRooms.Count - 1;
		return currentRooms[lastRoomIndex].transform.position.x + roomWidth;
	}

	// return whether the first room in currentRooms has passed the player
	bool FirstRoomHasPassed() {
		return firstRoomEndX < playerPosX;
	}

	bool LastRoomHasEntered() {
		return playerPosX > lastRoomStartX;
	}

	// remove the first room in the currentRooms list
	void RemoveRoom() {
		GameObject firstRoom = currentRooms[0];
		currentRooms.Remove(firstRoom);
		roomPool.Add(firstRoom);
		firstRoom.SetActive(false);

		// update the first room x position
		firstRoomEndX = GetFirstRoomEndX();
	}

	void AddRoom() {
		// get a mew room from the room pool
		int randomRoomIndex = Random.Range(0, roomPool.Count);
		GameObject newRoom = roomPool[randomRoomIndex];
		roomPool.Remove(newRoom);
		newRoom.SetActive(true);

		// calculate room x position
		float newRoomPosX = GetNewRoomPosition();
		newRoom.transform.position = new Vector3(newRoomPosX, 0, 0);

		currentRooms.Add(newRoom);

		// update the last room x position
		lastRoomStartX = GetLastRoomStartX();
	}
}
