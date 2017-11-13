using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Throwable : MonoBehaviour {

	public Vector2 direction;
	public float force;

	Rigidbody2D body;

	public bool inFlight = false;

	void Awake() {

		body = GetComponent<Rigidbody2D> ();
		body.simulated = false;
		inFlight = false;
	}

	void Start() {
	}
		
	public void Kick() {

		Carrier carrier = gameObject.GetComponent<Pickupable> ().carrier;
		if (carrier != null) {

			carrier.DumpCurrentItem ();

			transform.parent = null;
			body.gravityScale = 1;
			body.simulated = true;
			Vector2 kickForce = direction.normalized * force;
			kickForce = new Vector2 (kickForce.x * Mathf.Sign (carrier.transform.localScale.x), kickForce.y);
			Debug.LogError ("force: " + kickForce);
			body.AddForce (kickForce); 
			inFlight = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
