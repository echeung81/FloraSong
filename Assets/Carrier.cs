using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrier : MonoBehaviour {

	public Pickupable currItem;

	public void AttemptPickup (Pickupable item) {

		if (currItem == null) {

			currItem = item;
			item.carrier = this;
			item.OnPickup ();

			currItem.transform.SetParent (gameObject.transform);
			currItem.transform.localPosition = Vector2.zero;
		}
	}

	public void DumpCurrentItem() {

		currItem.carrier = null;
		currItem = null;
	}
}
