using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleDone : StateMachineBehaviour {

	public static PctTier MOVE_PCTS = new PctTier(new int[] { 20, 60, 75, 100 });

	enum NextState {

		IDLE,
		THROW_STONE,
		SINE_CHARGE,
		STRAIGHT_CHARGE,
		UP_DOWN
	}

	string[] stateTriggers = {

		"Idle", "ThrowStone", "SineCharge", "StraightCharge", "UpDown"

	};

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		int trigIdx = UnityEngine.Random.Range(0, Enum.GetNames (typeof(NextState)).Length);

		//MOVE_PCTS.Roll (); TODO Set conditionals based on which state you're on  percentage of state transitions. infrastructure for good state transitions

		animator.SetTrigger (stateTriggers[trigIdx]);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {



	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
