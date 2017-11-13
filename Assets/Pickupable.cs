using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public abstract class Pickupable : MonoBehaviour {


	Collider2D coll;

	public Carrier carrier;

	void Awake() {

		coll = GetComponent<Collider2D> ();
	}

	public void MakePickupable() {
		
		coll.enabled = true;
	}
		
	void OnTriggerEnter2D(Collider2D collider) {

		if (collider == null) {
			return;
		}

		if (collider.gameObject.GetComponent<Carrier> () != null) {

			Carrier carrier = collider.gameObject.GetComponent<Carrier> ();
			carrier.AttemptPickup (this);
		}
	}

	public abstract void OnPickup ();
}