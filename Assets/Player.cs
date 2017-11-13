using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {

	public HashSet<BossFightQuadrant> currentQuadrants = new HashSet<BossFightQuadrant>();

	public float movementMultiplier = 1.0f;

	Throwable throwable;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 direction = Vector2.zero;


		if (Input.GetKey ("up")) {
			direction += Vector2.up;
		}

		if (Input.GetKey ("down")) {
			direction += Vector2.down;
		} 


		if (Input.GetKey ("left")) {
			direction += Vector2.left;
		}


		if (Input.GetKey("right")) {
			direction += Vector2.right;
		}

		if (Input.GetButtonDown("Fire1")) {
			FireProjectile ();
		}

		if (Input.GetButtonDown ("Fire2")) {
			ToggleDirection ();
		}
			
		transform.localPosition += new Vector3(direction.x * movementMultiplier, direction.y * movementMultiplier);
	}

	public void ToggleDirection() {

		transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

	void FireProjectile() {

		throwable = GetComponent<Carrier> ().currItem.GetComponent<Throwable> ();

		if (throwable != null) {
			throwable.Kick ();
		}
	}
}
