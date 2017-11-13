using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickSpawner : Spawner {

	public static int NumSticksInField = 0;

	public static int MaxNumSticksInField = 2;

	public const string STICK_FALL_TIME_ANIM_DURATION_NAME = "StickFallTime";

	public Vector2 spawnMaxDist; //max x and y distances from center of spawner for random positioning of stick
		
	public FloatRange stickFallTime;

	public bool ignoreMaxSticks = false;

	public override void SpawnStuff () {

		Transform stickTransform = Instantiate<GameObject> (thingToSpawn[0]).transform;
		if (stickTransform != null && (ignoreMaxSticks || NumSticksInField < MaxNumSticksInField)) {

			Vector3 offset = new Vector3 (Random.Range (-spawnMaxDist.x, spawnMaxDist.x), Random.Range (-spawnMaxDist.y, spawnMaxDist.y), 0 );
			stickTransform.position = transform.position + offset;

			float scaledFallAnimTime = 1 / stickFallTime.RandomInRange;

			stickTransform.gameObject.GetComponent<Animator> ().SetFloat (STICK_FALL_TIME_ANIM_DURATION_NAME, scaledFallAnimTime);

			stickTransform.transform.SetParent (transform, true);

			StickSpawner.NumSticksInField++;
		}
	}
}
