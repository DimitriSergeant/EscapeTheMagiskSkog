using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeTheMagiskSkog {
	[RequireComponent(typeof (ThirdPersonCharacter))]
	public class KeysController : MonoBehaviour {
		protected ThirdPersonCharacter m_Character;
		protected string keysColor; 
		public GameObject key1;
		public GameObject key2;
		protected GameObject key1UI;
		protected GameObject key2UI;
		protected GameObject emptyKey1UI;
		protected GameObject emptyKey2UI;
		public bool hasKey1;
		public bool hasKey2;
		public GameObject keySlab1;
		public GameObject keySlab2;
		public bool canTakeKey1;
		public bool canTakeKey2;
		public Vector3 targetActivatedSlab1;
		public Vector3 targetActivatedSlab2;
		public Vector3 targetStartSlab1;
		public Vector3 targetStartSlab2;
		public float smoothTime = 0.3F;
    	private Vector3 velocity = new Vector3(0, -10, 0);

        public KeysController () {
			keysColor = "None";  
		}
		public KeysController (string newKeysColor) {
			keysColor = newKeysColor;  
		}

		public virtual void Start () {
			hasKey1 = false;
			hasKey2 = false;
			canTakeKey1 = false; 
			canTakeKey2 = false;
			m_Character = GetComponent<ThirdPersonCharacter>();
		}

		public void freeKey1 () {
			canTakeKey1 = true;
		}

		public void freeKey2 () {
			canTakeKey2 = true;
		}

		public void slabActivationAnimation (GameObject slab, Vector3 target) {   
			slab.transform.position = Vector3.SmoothDamp(slab.transform.position, target, ref velocity, smoothTime);
		}

		public void showEmptyKeysUI () {
			emptyKey1UI.SetActive(true);
			emptyKey2UI.SetActive(true);
		}
		public void showKey1UI () {
			if (hasKey1) {
				emptyKey1UI.SetActive(false);
				key1UI.SetActive(true);
			}
		}

		public void showKey2UI () {
			if (hasKey2) {
				emptyKey2UI.SetActive(false);
				key2UI.SetActive(true);
			}
		}

		public	void getKey1 () {
			hasKey1 = true;
			key1.SetActive(false);
			showKey1UI();
		}

		public void getKey2 () {
			hasKey2 = true;
			key2.SetActive(false);
			showKey2UI();
		}

		public void activateSlab1 () {
			canTakeKey1 = true; 
            slabActivationAnimation(keySlab1, targetActivatedSlab1);
		}
		
		public virtual void activateSlab2 () {
			canTakeKey2 = true; 
            slabActivationAnimation(keySlab2, targetActivatedSlab2);
		}

		public void looseKeys () {
			hasKey1 = false;
			hasKey2 = false;
			canTakeKey1 = false; 
			canTakeKey2 = false;
			slabActivationAnimation(keySlab1, targetStartSlab1);
			slabActivationAnimation(keySlab2, targetStartSlab1);
			hideAllKeysUI();
		}

		protected void hideAllKeysUI () {
			emptyKey1UI.SetActive(false);
			emptyKey2UI.SetActive(false);
			key1UI.SetActive(false);
			key2UI.SetActive(false);
		}
	}
}
