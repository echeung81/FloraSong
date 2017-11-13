using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineCollection : MonoBehaviour {

	//Dictionary<string, SplineWalker> collection = new Dictionary<string, SplineWalker>();
	public SplineWalker[] splines;

	public BezierSpline splineTemplate;
	public SplineWalker splineWalkerTemplate;

	void Start() {
	}

	public void RunWalker(int index, bool runBackward, bool startFromObjectPos = false) {

		if (index < splines.Length && index >= 0) {
			
			RunWalker (splines [index], runBackward, startFromObjectPos);
		}
	}

	public void RunWalker(int index, float startProgress, bool runBackward, bool startFromObjectPos = false) {

		if (index < splines.Length && index >= 0) {
			
			RunWalker (splines [index], startProgress, runBackward, startFromObjectPos);
		}
	}

	public void RunWalker(SplineWalker walker, bool runBackward, bool startFromObjectPos = false) {

			Vector3 worldPos = gameObject.transform.position;
			if (runBackward) {

				if (startFromObjectPos)
					walker.RunBackward (worldPos);
				else
					walker.RunBackward ();
				
			} else {

				if (startFromObjectPos)
					walker.RunForward (worldPos);
				else
					walker.RunForward ();
			}  
	}

	public void RunWalker(SplineWalker walker, float startProgress, bool runBackward, bool startFromObjectPos = false) {

			if (startFromObjectPos) 
				walker.RunSpline (gameObject.transform.position, startProgress, runBackward);
			else 
				walker.RunSpline (startProgress, runBackward);		
	}
}
