using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeTheMagiskSkog {
	[RequireComponent(typeof (ThirdPersonCharacter))]

	public class PowersColliderController : MonoBehaviour {

        private Collider m_Collider;
        private JumpPowerController _JumpPowerController;
        private SpeedPowerController _SpeedPowerController;
        private FogPowerController _FogPowerController;
        public const string redPowerAreaName = "RedPowerPlace";
        public const string bluePowerAreaName = "BluePowerPlace";
        public const string yellowPowerAreaName = "YellowPowerPlace";

        // UI part
        private GameObject RedPowerBadge; 
		private GameObject EmptyRedPowerBadge; 
		private GameObject RedPowerKey; 
		private GameObject BluePowerBadge; 
		private GameObject EmptyBluePowerBadge; 
		private GameObject BluePowerKey; 
		private GameObject YellowPowerBadge; 
		private GameObject EmptyYellowPowerBadge; 
		private GameObject YellowPowerKey; 

        private void Start() {
            m_Collider = GetComponent<Collider>();
            _JumpPowerController = GetComponent<JumpPowerController>();
            _SpeedPowerController = GetComponent<SpeedPowerController>();
            _FogPowerController = GetComponent<FogPowerController>();

            // UI init
            //  Get Red power UI part
            RedPowerBadge = GameObject.Find("RedPowerBadge"); 
            EmptyRedPowerBadge = GameObject.Find("EmptyRedPowerBadge"); 
			RedPowerKey = GameObject.Find("RedPowerKey");
            manageShowPower(RedPowerBadge, EmptyRedPowerBadge, RedPowerKey, false);

		    // Get Blue power UI part
 			BluePowerBadge = GameObject.Find("BluePowerBadge");  
			EmptyBluePowerBadge = GameObject.Find("EmptyBluePowerBadge"); 
			BluePowerKey = GameObject.Find("BluePowerKey");
            manageShowPower(BluePowerBadge, EmptyBluePowerBadge, BluePowerKey, false);

			// Get Yellow power UI part
 			YellowPowerBadge = GameObject.Find("YellowPowerBadge");  
			EmptyYellowPowerBadge = GameObject.Find("EmptyYellowPowerBadge"); 
			YellowPowerKey = GameObject.Find("YellowPowerKey");
            manageShowPower(YellowPowerBadge, EmptyYellowPowerBadge, YellowPowerKey, false);
        }
        
        void OnTriggerStay (Collider other) {
            var colliderName = other.name;
            switch (colliderName) {
                case redPowerAreaName:
                    _JumpPowerController.UnlockPower();
                    manageShowPower(RedPowerBadge, EmptyRedPowerBadge, RedPowerKey, true);
                break;
                case bluePowerAreaName:
                    _SpeedPowerController.UnlockPower();
                    manageShowPower(BluePowerBadge, EmptyBluePowerBadge, BluePowerKey, true);
                break;
                case yellowPowerAreaName:
                    _FogPowerController.UnlockPower();
                    manageShowPower(YellowPowerBadge, EmptyYellowPowerBadge, YellowPowerKey, true);
                break;
                default:
                break;
            }
            
	    }

        // if the power is unlocked (unlocked = true) this function will show the badge and the keyboard
        // otherwise show the empty circle
        public void manageShowPower (GameObject badge, GameObject emptyBadge, GameObject key, bool unlocked) {
			badge.SetActive(unlocked);
			emptyBadge.SetActive(!unlocked);
			key.SetActive(unlocked);
		}

        public void loosePowers () {
            _JumpPowerController.LockPower();
            manageShowPower(RedPowerBadge, EmptyRedPowerBadge, RedPowerKey, false);     
            _SpeedPowerController.LockPower();
            manageShowPower(BluePowerBadge, EmptyBluePowerBadge, BluePowerKey, false);
            _FogPowerController.LockPower();
            manageShowPower(YellowPowerBadge, EmptyYellowPowerBadge, YellowPowerKey, false);
        }
    }
}