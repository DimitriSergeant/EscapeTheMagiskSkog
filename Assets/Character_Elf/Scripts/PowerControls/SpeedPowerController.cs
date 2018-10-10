using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeTheMagiskSkog {
	public class SpeedPowerController : PowerController {
		private JumpPowerController _JumpPowerController;
		private FogPowerController _FogPowerController;
		[SerializeField] float encreased_SpeedPower = 2f;
		[SerializeField] float normal_SpeedPower = 1f;
		[SerializeField] float encreased_AnimSpeed = 2f;
		[SerializeField] float normal_AnimSpeed = 1f;

		// Use this for initialization
		public override void Start () {
			base.Start();
			_JumpPowerController = GetComponent<JumpPowerController>();
			_FogPowerController = GetComponent<FogPowerController>();
			base.powerSmoke = GameObject.Find("BluePowerSmoke");
			base.powerSmoke.SetActive(false);
		}
		
		// Update is called once per frame
		void Update () {
			if ( Input.GetKeyDown(KeyCode.R) && base.IsPowerPossessed()) {
				if (base.IsPowerActivated()) {
					DeactivatePower();
				} else {
					ActivatePower();
					_JumpPowerController.DeactivatePower();
					_FogPowerController.DeactivatePower();
				}
			}
		}

		public SpeedPowerController() : base("SpeedPower") {}

		public override void ActivatePower () {
			base.ActivatePower();
			SpeedPower();
			base.powerSmoke.SetActive(true);
		}

		public override void DeactivatePower () {
			base.DeactivatePower();
			SpeedPower();
			base.powerSmoke.SetActive(false);
		}

		public void SpeedPower () {
			var speedPower = base.IsPowerActivated() ? encreased_SpeedPower : normal_SpeedPower;
			var animSpeed = base.IsPowerActivated() ? encreased_AnimSpeed : normal_AnimSpeed;
			base.m_Character.changeSpeedPower(speedPower);
			base.m_Character.changeAnimSpeed(animSpeed);
		}
	}
}
