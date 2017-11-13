using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChargeBox : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {

		GameObject gObj = collider.gameObject;
		if (gObj.GetComponent<Player> () != null) {

			Debug.Log ("player in charge box");

			transform.parent.GetComponent<Boss> ().playerInChargeBox = true;	
		}
	}

	void OnTriggerExit2D(Collider2D collider) {

		GameObject gObj = collider.gameObject;
		if (gObj.GetComponent<Player> () != null) {

			Debug.Log ("player out of charge box");

			transform.parent.GetComponent<Boss> ().playerInChargeBox = false;	
		}
	}
}
