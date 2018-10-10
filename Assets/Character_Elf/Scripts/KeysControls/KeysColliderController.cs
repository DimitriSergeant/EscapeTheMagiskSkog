using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeTheMagiskSkog {
	public class KeysColliderController : MonoBehaviour {
        private Collider m_Collider;       
        public const string redPowerAreaName = "RedPowerPlace";
        public const string bluePowerAreaName = "BluePowerPlace";
        public const string yellowPowerAreaName = "YellowPowerPlace";

        public string colorPath;
        public const string redPath = "Red";
        public const string bluePath = "Blue";
        public const string yellowPath = "Yellow";
            
        public RedKeysController _RedKeysController;
		public BlueKeysController _BlueKeysController;
		public YellowKeysController _YellowKeysController;
        // public KeysController _KeysController;
        private void Start() {
            m_Collider = GetComponent<Collider>();
            _RedKeysController = GetComponent<RedKeysController>();
			_BlueKeysController = GetComponent<BlueKeysController>();
			_YellowKeysController = GetComponent<YellowKeysController>();
        }

        void OnTriggerEnter (Collider other) {
            var colliderName = other.name;
            switch (colliderName) {
                case redPowerAreaName:
                    colorPath = redPath;
                    _RedKeysController.showEmptyKeysUI();               
                break;
                case bluePowerAreaName:
                    colorPath = bluePath;
                    _BlueKeysController.showEmptyKeysUI();                
                break;
                case yellowPowerAreaName:                        
                    colorPath = yellowPath;
                    _YellowKeysController.showEmptyKeysUI();                
                break;
                default:
                break;
            }
            switch (colorPath) {
                case redPath:
                    TriggerConditions(_RedKeysController, colliderName);
                break;
                case bluePath:
                    TriggerConditions(_BlueKeysController, colliderName);
                break;
                case yellowPath:
                    TriggerConditions(_YellowKeysController, colliderName);
                break;
                default:
                break;
            }
               

	    }

        protected void TriggerConditions (KeysController kc, string colliderName) {
            if (colliderName == kc.key1.name && kc.canTakeKey1) {
				kc.getKey1();
			} 
            if (colliderName == kc.key2.name && kc.canTakeKey2) {
				kc.getKey2();
            } 
            if (colliderName == kc.keySlab1.name && !kc.canTakeKey1) {
				kc.activateSlab1();
			} 
            if (colliderName == kc.keySlab2.name && !kc.canTakeKey2) {
				kc.activateSlab2();
			} 
        }

        void LooseAllKeys () {
            _RedKeysController.looseKeys();   
            _BlueKeysController.looseKeys();
            _YellowKeysController.looseKeys();
        }
    }
}