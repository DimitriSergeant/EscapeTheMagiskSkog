using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeTheMagiskSkog {

	public class JumpPowerController : PowerController {
		
		[SerializeField] float normal_JumpPower = 12f;
		[SerializeField] float encreased_JumpPower = 25f;
		private SpeedPowerController _SpeedPowerController;
		private FogPowerController _FogPowerController;

		// Use this for initialization
		public override void Start () {
			base.Start();
			_SpeedPowerController = GetComponent<SpeedPowerController>();
			_FogPowerController = GetComponent<FogPowerController>();
			base.powerSmoke = GameObject.Find("RedPowerSmoke");
			base.powerSmoke.SetActive(false);
		}
		
		// Update is called once per frame
		void Update () {
			if ( Input.GetKeyDown(KeyCode.J) && base.IsPowerPossessed()) {
				if (base.IsPowerActivated() ) {
					DeactivatePower();
				} else {
					ActivatePower();
					_SpeedPowerController.DeactivatePower();
					_FogPowerController.DeactivatePower();
				}
			} 
		}

		public JumpPowerController() : base("JumpPower") {}

		public override void ActivatePower () {
			base.ActivatePower();
			JumpPower(); 
			base.powerSmoke.SetActive(true);
		}

		public override void DeactivatePower () {
			base.DeactivatePower();
			JumpPower();
			base.powerSmoke.SetActive(false);
		}

		public void JumpPower () {
			var jumpPower = base.IsPowerActivated() ? encreased_JumpPower : normal_JumpPower;
			base.m_Character.changeJumpPower(jumpPower);
		}
	}

}
