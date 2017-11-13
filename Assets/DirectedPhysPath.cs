using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DirectedPhysPath : MonoBehaviour {

	public Vector2 targetPosition;		//path ends when object is within this distance of the target position or object
	public float targetRadius; 			

	public float lifetime;

	public Transform target;

	Rigidbody2D body;
	float timeAlive = 0;
	bool ready = false;

	void Awake() {

		body = GetComponent<Rigidbody2D> ();
	}

	void Start() {

		Seek (target.position, 1000f, 5f);
	
	}
		
	// Update is called once per frame
	void FixedUpdate () {

		if (!ready) {
			return;
		}

		timeAlive += Time.deltaTime;

		if (timeAlive > lifetime) {
			GameObject.Destroy (gameObject);
		}
	}

	public void Seek(Vector2 targetPosn, float force, float objLifetime) {

		Vector2 direction = targetPosn - new Vector2(transform.position.x, transform.position.y);

		Kick (direction, force, objLifetime);
	}

	public void Kick(Vector2 direction, float force, float objLifetime) {

		this.lifetime = objLifetime;
		ready = true;

		direction = direction.normalized;
		body.AddForce (force * direction);
	}
}
