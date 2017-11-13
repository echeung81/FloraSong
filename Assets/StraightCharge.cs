using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightCharge : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		Boss boss = animator.gameObject.GetComponent<Boss> ();

		if (boss.playerInChargeBox) { 

			if (boss.currentQuadrants.Contains (BossFightQuadrant.QUADRANT_SE) || boss.currentQuadrants.Contains (BossFightQuadrant.QUADRANT_NE)) {
				boss.GetComponent<SplineCollection> ().RunWalker (1, false, true);

			} else {
				boss.GetComponent<SplineCollection> ().RunWalker (1, true, true);
			}
		} else {

			//jump to next decision point
			animator.SetTrigger ("BackToDecision");
		}

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
