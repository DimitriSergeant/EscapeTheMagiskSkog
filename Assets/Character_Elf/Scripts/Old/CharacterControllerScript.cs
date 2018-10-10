using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour {

		[SerializeField] float m_MovingTurnSpeed = 360;
		[SerializeField] float m_StationaryTurnSpeed = 180;
		[SerializeField] float m_JumpPower = 12f;
		[Range(1f, 4f)][SerializeField] float m_GravityMultiplier = 2f;
		[SerializeField] float m_RunCycleLegOffset = 0.2f; 
		[SerializeField] float m_MoveSpeedMultiplier = 1f;
		[SerializeField] float m_AnimSpeedMultiplier = 1f;
		[SerializeField] float m_GroundCheckDistance = 0.1f;

		Rigidbody m_Rigidbody;
		Animator m_Animator;
		bool m_IsGrounded;
		float m_OrigGroundCheckDistance;
		const float k_Half = 0.5f;
		float m_TurnAmount;
		float m_ForwardAmount;
		Vector3 m_GroundNormal;
		float m_CapsuleHeight;
		Vector3 m_CapsuleCenter;
		CapsuleCollider m_Capsule;
		bool m_Crouching;
		private bool m_Jump;
	void Start () {
			m_Animator = GetComponent<Animator>();
			m_Rigidbody = GetComponent<Rigidbody>();
			m_Capsule = GetComponent<CapsuleCollider>();
			m_CapsuleHeight = m_Capsule.height;
			m_CapsuleCenter = m_Capsule.center;

			m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
			m_OrigGroundCheckDistance = m_GroundCheckDistance;
	}

	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 10f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);


		//Walk Animation
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
			walkAnimation("Walk", true);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
			walkAnimation("WalkBack", true);
        }

        //Stop Animation
        if (Input.GetKeyUp(KeyCode.UpArrow)) {
			walkAnimation("Walk", false);
        }
		if (Input.GetKeyUp(KeyCode.DownArrow)) {
			walkAnimation("WalkBack", false);
        }

        //Player Jump
        if (Input.GetKeyDown(KeyCode.Space)) {
			m_Animator.SetTrigger("Jump");
            m_Rigidbody.AddForce(new Vector3(0, 5, 0), ForceMode.VelocityChange);
        }
	}

	void walkAnimation(string walkType, bool isKeyDown) {
		m_Animator.SetBool(walkType, isKeyDown);
        m_Animator.SetBool("StopWalking", !isKeyDown);
	}
}
