using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeTheMagiskSkog {
	public class PowersPlaceController : MonoBehaviour {
		Collider powerPlaceCollider;
		public const string redPowerAreaName = "RedPowerPlace";
        public const string bluePowerAreaName = "BluePowerPlace";
        public const string yellowPowerAreaName = "YellowPowerPlace";
		private GameObject door;
		public const string redDoorName = "Red Door 1";
		public const string blueDoorName = "Blue Door 1";
		public const string yellowDoorName = "Yellow Door 1";
		
		private float floorY = 0.4f;
		public float smoothTime = 10F;
    	private Vector3 velocity = new Vector3(0, 20, 0);

		void Start () {
			powerPlaceCollider = GetComponent<Collider>();
			// Get the door corresponding to each place to close when get the power
			switch(powerPlaceCollider.name) {
                case redPowerAreaName:
					door = GameObject.Find(redDoorName);
                break;
                case bluePowerAreaName:
					door = GameObject.Find(blueDoorName);
                break;
                case yellowPowerAreaName:
					door = GameObject.Find(yellowDoorName);
                break;
                default:
                break;
			}
			// open the door 
			door.SetActive(false);
		}
		
		void OnTriggerEnter (Collider other) {
			doorAppearAnimation();
		}

		void OnTriggerStay (Collider other) {
			doorAppearAnimation();
		}
		void OnTriggerExit (Collider other) {
			doorAppearAnimation();
		}

		void doorAppearAnimation () {
			door.SetActive(true);    
			Vector3 target = new Vector3(door.transform.position.x, floorY, door.transform.position.z);			
			door.transform.position = Vector3.SmoothDamp(door.transform.position, target, ref velocity, smoothTime);
		}
	}
}