using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeTheMagiskSkog
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
	public class DeathScript : MonoBehaviour {
		private ThirdPersonCharacter m_Character;
		private ThirdPersonUserControl m_UserControl;
		private Rigidbody m_Rigidbody;
		private PowersColliderController powersManager;
		private GameObject spawn1;
		private string deathWaterName = "RedWater";
		private GameObject deathPanel;
		

		void Start () {
			m_Character = GetComponent<ThirdPersonCharacter>();
			m_UserControl = GetComponent<ThirdPersonUserControl>();
			powersManager = GetComponent<PowersColliderController>();
			m_Rigidbody = GetComponent<Rigidbody>();
			deathPanel = GameObject.Find("DeathPanel");
			spawn1 = GameObject.Find("Spawn1");

			deathPanel.SetActive(false);
		}

		void OnTriggerEnter(Collider other) {
			if (other.name == deathWaterName) {
				// StartCoroutine(manageDeath(3));
			}
			
		}

		IEnumerator manageDeath(int seconds) {
			deathPanel.SetActive(true);
			powersManager.loosePowers();
			
			m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY |  RigidbodyConstraints.FreezePositionZ 
				| RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |  RigidbodyConstraints.FreezeRotationZ;
			yield return new WaitForSeconds(seconds);
			deathPanel.SetActive(false);
			spawnTo(spawn1);
			m_Rigidbody.constraints = RigidbodyConstraints.None;
		}
		
		public void spawnTo (GameObject spawn) {
			m_Rigidbody.velocity = Vector3.zero;
    		m_Rigidbody.angularVelocity = Vector3.zero; 
			// transform.position = spawn.transform.position; 
			// transform.rotation = spawn.transform.rotation;

			// m_Rigidbody.MovePosition(transform.position + spawn.transform.forward * Time.deltaTime);

		}
	}
}