using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiraUserControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	void moveForward () {
		Vector3 playerPosition = transform.position;
		playerPosition.z += 0.1f;
		transform.position = playerPosition;
	}

	void moveBackward () {
		Vector3 playerPosition = transform.position;
		playerPosition.z -= 0.1f;
		transform.position = playerPosition;
	}	
	void moveRight () {
		Vector3 playerPosition = transform.position;
		playerPosition.x += 0.1f;
		transform.position = playerPosition;
	}

	void moveLeft () {
		Vector3 playerPosition = transform.position;
		playerPosition.x -= 0.1f;
		transform.position = playerPosition;
	}

	void updatePosition() {
		if (Input.GetKey(KeyCode.Z)) {
			moveForward();
		} 
		if (Input.GetKey(KeyCode.S)) {
			moveBackward();
		}
		if (Input.GetKey(KeyCode.D)) {
			moveRight();
		}
		if (Input.GetKey(KeyCode.Q)) {
			moveLeft();
		}
	}

	// Update is called once per frame
	void Update () {
		updatePosition();
		// updateViewAndCharacterAngle();
	}
}
