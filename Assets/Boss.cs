using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	public HashSet<BossFightQuadrant> currentQuadrants = new HashSet<BossFightQuadrant>();

	public bool playerInChargeBox = false;

	public StickSpawner[] sineSpawners;

	public PctTier movePcts; //syncs with percentage something might happen

	public FloatRange yExtents;

	public float upMetersPerSecond;

	void OnTriggerEnter2D(Collider2D collider) {

		GameObject gObj = collider.gameObject;
		if (gObj.GetComponent<Throwable> () != null) {

			if (gObj.GetComponent<Throwable> ().inFlight) {
				GetComponent<HPStat> ().DecrementHP ();
			} 

			if (gObj.GetComponent<Pickupable> ().carrier == null) {

				GameObject.Destroy (gObj);
			}

		} else if (gObj.GetComponent<Player> () != null) {

			gObj.GetComponent<HPStat> ().DecrementHP ();
		
		}
	}

	public void ActivateSpawners() {

		for (int i = 0; i < sineSpawners.Length; i++) {
			sineSpawners [i].Active = true;
		}
	}

	public void DeactivateSpawners() {

		for (int i = 0; i < sineSpawners.Length; i++) {
			sineSpawners [i].Active = false;
		}

	}

}
