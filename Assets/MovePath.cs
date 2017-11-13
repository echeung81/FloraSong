using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePath : MonoBehaviour {


	/* TARGET SPECIFICATIONS */
	public SplineWalker[] paths;

	public Vector2 targetPosn;

	public GameObject targetObj;

	/* STOPPING CONDITIONS */
	public float targetRadius; //path ends when object is within this distance of the target position or object

	public float pathLifetime; //path ends when object has been moving for this number of seconds.

	public float xStop; //path ends when object reaches this X val;

	public float yStop; //path ends when object reaches this Y val;

	/*OTHER SPECS */
	public float repeatPath; //repeat the paths once the set of paths in paths has been walked?

	float timeElapsed = 0;
	int activePathIndex = 0; //of the set of path patterns in paths, which index are we currently on?

	public bool IsFinished { get; set; }

	// Update is called once per frame
	void FixedUpdate () {

		if (!IsFinished) {

			SplineWalker currPath = paths [activePathIndex];
			if (currPath.IsFinished) {
				

			}


		}
	}
}
