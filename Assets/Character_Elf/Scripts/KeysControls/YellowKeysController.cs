	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeTheMagiskSkog {
	public class YellowKeysController : KeysController {
		public YellowKeysController () : base("Yellow") {}

		public override void Start () {
			base.Start();
			base.key1 = GameObject.Find("YellowKey1");
			base.key2 = GameObject.Find("YellowKey2");
			base.keySlab1 = GameObject.Find("YellowKey1 Slab");
			base.keySlab2 = GameObject.Find("YellowKey2 Slab");
			base.key1UI = GameObject.Find("YellowKey1UI");
			base.key2UI = GameObject.Find("YellowKey2UI");
			base.key1UI.SetActive(false);
			base.key2UI.SetActive(false);
			base.emptyKey1UI = GameObject.Find("EmptyYellowKey1UI");
			base.emptyKey2UI = GameObject.Find("EmptyYellowKey2UI");
			base.emptyKey1UI.SetActive(false);
			base.emptyKey2UI.SetActive(false);
			// base.targetSlab1 = new Vector3(base.keySlab1.transform.position.x, 42F, base.keySlab1.transform.position.z);
			// base.targetSlab2 = new Vector3(base.keySlab1.transform.position.x, -3F, base.keySlab1.transform.position.z);
		}
	}
}
