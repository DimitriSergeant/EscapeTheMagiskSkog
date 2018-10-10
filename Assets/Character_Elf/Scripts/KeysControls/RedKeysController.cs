using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeTheMagiskSkog {
	public class RedKeysController : KeysController {

		GameObject[] redKeySpawns;
		GameObject[] redBridges;
		private Vector3 keyVelocity = new Vector3(1000, 0, 1000);
		private Vector3 bridgeVelocity = new Vector3(0, -100, 0);
		public RedKeysController () : base("Red") {}

		public override void Start () {
			base.Start();
			base.key1 = GameObject.Find("RedKey1");
			base.key2 = GameObject.Find("RedKey2");
			base.keySlab1 = GameObject.Find("RedKey1 Slab");
			base.keySlab2 = GameObject.Find("RedKey2 Slab");
			base.key1UI = GameObject.Find("RedKey1UI");
			base.key2UI = GameObject.Find("RedKey2UI");
			base.key1UI.SetActive(false);
			base.key2UI.SetActive(false);
			base.emptyKey1UI = GameObject.Find("EmptyRedKey1UI");
			base.emptyKey2UI = GameObject.Find("EmptyRedKey2UI");
			base.emptyKey1UI.SetActive(false);
			base.emptyKey2UI.SetActive(false);
			
			base.targetStartSlab1 = keySlab1.transform.position;
			base.targetStartSlab2 = keySlab2.transform.position;
			base.targetActivatedSlab1 = new Vector3(keySlab1.transform.position.x, 39.5F, keySlab1.transform.position.z);
			base.targetActivatedSlab2 = new Vector3(keySlab2.transform.position.x, -3F, keySlab2.transform.position.z);
		}

		public void Update () {
			redKeySpawns = GameObject.FindGameObjectsWithTag("RedKeySpawn");
		}

		public override void activateSlab2 () {
			base.activateSlab2();
			redBridgesAnimation();
			StartCoroutine(RedKeyAnimation(5));
		}

		IEnumerator RedKeyAnimation (int seconds) {
			int spawnIndex;
			Vector3 spawnTarget;
			
			spawnIndex = Mathf.RoundToInt(Random.value * (redKeySpawns.Length - 1));
			spawnTarget = redKeySpawns[spawnIndex].transform.position;
			Debug.Log("Passé ici");
			base.key2.transform.position = spawnTarget;	
			//not good because continue to stay in while, while waitforseconds
			yield return new WaitForSeconds(seconds);
			
		}

		void redBridgesAnimation () {
			if (redBridges == null) {
				redBridges = GameObject.FindGameObjectsWithTag("RedBridge");
			}
			foreach (GameObject bridge in redBridges) {
				Vector3 bridgeTarget = new Vector3(bridge.transform.position.x, -100F, bridge.transform.position.z);
				bridge.transform.position = Vector3.SmoothDamp(bridge.transform.position, bridgeTarget, ref bridgeVelocity, base.smoothTime);
			}
		}
	}
}
