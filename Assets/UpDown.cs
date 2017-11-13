using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : StateMachineBehaviour {



	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		float bossY = animator.gameObject.transform.position.y;

		Boss boss = animator.gameObject.GetComponent<Boss> ();

		int upPctChance = (int) (((boss.yExtents.max - bossY) / (boss.yExtents.Range())) * 100);
		//int downPctChance = (int) (((bossY - boss.yExtents.min) / (boss.yExtents.Range)) * 100);

		PctTier tierChance = new PctTier (new int[] { upPctChance, 100 });

		int roll = tierChance.Roll ();

		int distance;
		float duration;
		float animMultiplier;
		bool goUp;
		if (roll == 0) {

			//go up.
			distance = (int)Random.Range(0, (boss.yExtents.max - bossY));
			goUp = true;
		} else {

			//go down.
			distance = (int)Random.Range (0, bossY - boss.yExtents.min);
			goUp = false;
		}

		duration = distance / boss.upMetersPerSecond;
		//set duration in spline
		animMultiplier = 1 / duration;
		animator.SetFloat ("UpDownDurationMultiplier", animMultiplier);

		distance = (goUp ? distance : -distance);

		BezierSpline spline = Instantiate<BezierSpline>(animator.gameObject.GetComponent<SplineCollection> ().splineTemplate);
		spline.Reset ();

		spline.SetControlPoint(0, Vector3.zero);
		spline.SetControlPoint(1, new Vector3(0, distance / 3f, 0));
		spline.SetControlPoint (2, new Vector3(0, (2 / 3f) * distance, 0));
		spline.SetControlPoint (3, new Vector3 (0, distance, 0)); 

		SplineWalker splineWalker = Instantiate<SplineWalker>(animator.gameObject.GetComponent<SplineCollection> ().splineWalkerTemplate);
		splineWalker.FitWithSpline (spline, animator.gameObject, duration, false);

		SplineCollection splineCollection = animator.gameObject.GetComponent<SplineCollection> ();
		splineCollection.RunWalker (splineWalker, false, true);


	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
