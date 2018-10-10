using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeTheMagiskSkog {
	[RequireComponent(typeof (ThirdPersonCharacter))]
	public class PowerController : MonoBehaviour {
		protected ThirdPersonCharacter m_Character;
		protected string powerType;
        protected bool powerPossessed;
        protected bool powerActivated;
		protected GameObject powerSmoke;

        public PowerController() {
			powerType = "None";  
		}
		public PowerController(string newPowerType) {
			powerType = newPowerType;  
		}

		public virtual void Start () {
			powerPossessed = false;
			powerActivated = false;
			m_Character = GetComponent<ThirdPersonCharacter>();
		}
		public bool IsPowerActivated () {
			return powerActivated;
		}
		public bool IsPowerPossessed () {
			return powerPossessed;
		}
		public void UnlockPower () {
			if ( !IsPowerPossessed() ) {
				powerPossessed = true;
			}
		}

		public void LockPower () {
			powerActivated = false;
			powerPossessed = false;			
		}

		public virtual void ActivatePower () {
			if ( IsPowerPossessed() ) { powerActivated = true; }
		}
		public virtual void DeactivatePower () {
			if ( IsPowerPossessed() ) { powerActivated = false; }
		}

	}
}
