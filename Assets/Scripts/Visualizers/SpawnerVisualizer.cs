using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerVisualizer : MonoBehaviour {

	void OnDrawGizmos() {


		Gizmos.color = Color.green;

		Gizmos.DrawWireSphere (transform.position, 2);
		//Gizmos.DrawIcon (transform.position, "Spawner.png");

	}
}
