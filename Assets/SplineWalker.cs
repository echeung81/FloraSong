using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineWalker : MonoBehaviour {

	public const float SPLINE_OVERLONG_DURATION = 30.0f; //issue a warning (or destroy object?) when splinewalker has been running over this amount of time. could mean were stuck/running infinite condition

	public BezierSpline spline;

	public bool lookForward;

	public float duration;

	public SplineWalkerMode mode;
	public SplineWalkerStopMode stopMode; //can only have one active at a time for now

	public bool Active { 

		get { return _isActive; }
		set { _isActive = value; }
	}

	public bool IsFinished {

		get {
			return progress >= 1f;
		}
	}
		
	/* STOPPING CONDITIONS */
	public Vector2 targetPosition;		//path ends when object is within this distance of the target position or object
	public float targetRadius; 			

	public float xStop; 				//path ends when object's x value is within xThresh of xStop
	public float xThreshold; 		

	public float yStop; 				//path ends when object's y value is within yThresh of yStop
	public float yThreshold;		

	public float runForTime; //path ends when object has been moving for this number of seconds.

	float progress;

	bool goingForward = true;

	float timeElapsed = 0;

	[SerializeField]
	private bool _isActive;

	public Transform targetTransform;


	public void FitWithSpline(BezierSpline inputSpline, GameObject targetObj, float splineDuration, bool splineLookForward) {

		spline = inputSpline;

		lookForward = splineLookForward;

		duration = splineDuration;

		targetTransform = targetObj.transform;

		mode = SplineWalkerMode.Once;
	}


	void Update() {

		//if no target transform assumed this is attached as component to a game object which will walk the spline.
		if (targetTransform == null) {
			targetTransform = transform;
		}

		if (!Active) {
			return;
		}

		timeElapsed += Time.deltaTime;

		if (timeElapsed > SPLINE_OVERLONG_DURATION) {
			
			Debug.LogWarning ("Spline running overtime (> " + SPLINE_OVERLONG_DURATION + ")");
		}

		if (stopMode == SplineWalkerStopMode.TIME && timeElapsed > runForTime) {
			PathDone ();
			return;
		}

		if (goingForward) {
		
			progress += Time.deltaTime / duration;
			if (progress > 1f) {
				
				if (mode == SplineWalkerMode.Once) {

					progress = 1f;
					Active = false;
				
				} else if (mode == SplineWalkerMode.Loop) {
					progress -= 1f;
				
				} else {
					progress = 2f - progress;
					goingForward = false;
				}
			}
		
		} else {
		
			progress -= Time.deltaTime / duration;
			if (progress < 0f) {

				if (mode == SplineWalkerMode.Once) {

					progress = 0f;
					PathDone ();

				} else {

					progress = -progress;
					goingForward = true;
				}
			}
		
		}

		Vector3 position = spline.GetPoint (progress);
		targetTransform.position = position;
		if (lookForward) {
			targetTransform.LookAt (position + spline.GetDirection (progress));
		}


		//POSITION stopping conditions
		Vector2 world = targetTransform.TransformPoint (targetTransform.position);

		if (stopMode == SplineWalkerStopMode.POSITION && Vector2.Distance (world, targetPosition) <= targetRadius) {

			//MIGHT HAVE TO PUT THIS INTO A DIFFERENT SEEKER CLASS. These spline smight be for drawing out world positions and paths
			Debug.Log ("Spline Walker target position reached: " + targetPosition);
			PathDone ();
		
		} else if (stopMode == SplineWalkerStopMode.XVAL && Mathf.Abs (xStop - world.x) <= xThreshold) {

			Debug.Log ("Spline Walker X line reached: " + xStop);
			PathDone ();

		} else if (stopMode == SplineWalkerStopMode.YVAL && Mathf.Abs (yStop - world.y) <= yThreshold) {

			Debug.Log ("Spline Walker Y line reached: " + yStop);
			PathDone ();
		}

	}
				
	void PathDone() {

		//signal path is done. event whatever
		Active = false;
	}

	public void RunForward(Vector3 worldPos) {
		RunSpline (worldPos, 0f, true);
	}

	public void RunBackward(Vector3 worldPos) {

		//in this case the worldPos starts at the last control point such that 
		RunSpline (worldPos, 1f, false);
	}

	public void RunSpline(Vector3 worldPos, float startProgress, bool forward) {

		worldPos = worldPos - spline.GetPoint(startProgress, true); 

		spline.transform.position = worldPos;
		progress = Mathf.Clamp01 (startProgress);
		goingForward = forward;

		Active = true;
	}

	public void RunForward() {
		RunSpline (0f, true);
	}

	public void RunBackward() {
		RunSpline (1f, false);
	}

	public void RunSpline(float startProgress, bool forward) {

		progress = Mathf.Clamp01 (startProgress);
		goingForward = forward;

		Active = true;
	}
}
