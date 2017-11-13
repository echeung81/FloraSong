using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO later turn this into a abstract class
public class BossAreaMarker : MonoBehaviour {

	public BossFightQuadrant quadrant;

	void OnTriggerEnter2D(Collider2D collider) {

		GameObject gObj = collider.gameObject;

		if (gObj.GetComponent<Player> () != null) {


			gObj.GetComponent<Player> ().currentQuadrants.Add (quadrant);

			LogQuadrants (gObj.GetComponent<Player> ().currentQuadrants);

		} else if (gObj.GetComponent<Boss> () != null) {

			gObj.GetComponent<Boss> ().currentQuadrants.Add (quadrant);

			LogQuadrants (gObj.GetComponent<Boss> ().currentQuadrants);
		}
	}

	void OnTriggerExit2D(Collider2D collider) {

		GameObject gObj = collider.gameObject;

		if (gObj.GetComponent<Player> () != null) {

			gObj.GetComponent<Player> ().currentQuadrants.Remove (quadrant);

			LogQuadrants (gObj.GetComponent<Player> ().currentQuadrants);


		} else if (gObj.GetComponent<Boss> () != null) {

			gObj.GetComponent<Boss> ().currentQuadrants.Remove (quadrant);

			LogQuadrants (gObj.GetComponent<Boss> ().currentQuadrants);
		}
	}

	public static void LogQuadrants(HashSet<BossFightQuadrant> quadrantCollection) {

		string quadrantString = "";
		foreach (BossFightQuadrant qd in quadrantCollection) {

			quadrantString += (qd + ", ");
		}

		Debug.Log (quadrantString);
	}
}
