using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeTheMagiskSkog {
	public class FogPowerController : PowerController {
			
			[SerializeField] float normal_JumpPower = 12f;
			[SerializeField] float encreased_JumpPower = 25f;
			private SpeedPowerController _SpeedPowerController;
			private JumpPowerController _JumpPowerController;

			// Use this for initialization
			public override void Start () {
				base.Start();
				_SpeedPowerController = GetComponent<SpeedPowerController>();
				_JumpPowerController = GetComponent<JumpPowerController>();
				base.powerSmoke = GameObject.Find("YellowPowerSmoke");
				base.powerSmoke.SetActive(false);
			}
			
			// Update is called once per frame
			void Update () {
				if ( Input.GetKeyDown(KeyCode.F) && base.IsPowerPossessed()) {
					if (base.IsPowerActivated()) {
						DeactivatePower();
					} else {
						ActivatePower();
						_SpeedPowerController.DeactivatePower();
						_JumpPowerController.DeactivatePower();
					}
				} 
			}

		public FogPowerController() : base("FogPower") {}

		public override void ActivatePower () {
			base.ActivatePower();
			FogPower(); 
			base.powerSmoke.SetActive(true);
		}

		public override void DeactivatePower () {
			base.DeactivatePower();
			FogPower();
			base.powerSmoke.SetActive(false);
		}

		public void FogPower () {
			// var jumpPower = base.IsPowerActivated() ? encreased_JumpPower : normal_JumpPower;
			// base.m_Character.changeJumpPower(jumpPower);
		}
	}
}