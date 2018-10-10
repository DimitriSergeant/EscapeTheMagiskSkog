using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawnScript : MonoBehaviour {

	string redKeySpawnName = "RedKeySpawn";
	string defaultTag = "Untagged";
	

	void OnTriggerStay (Collider other) {
		if (transform.gameObject.tag != defaultTag)
			transform.gameObject.tag = defaultTag;
		
	}

	void OnTriggerExit (Collider other) {
		if (transform.gameObject.tag == defaultTag)
			transform.gameObject.tag = redKeySpawnName;
	}
}
