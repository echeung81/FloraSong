using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Thing {

	void OnCollisionEnter2D(Collision2D coll) {



		Player player = coll.gameObject.GetComponent<Player> ();
		if (player != null) {

			Debug.Log ("Hit Player");

			player.GetComponent<HPStat> ().DecrementHP ();

		}
	}
}
