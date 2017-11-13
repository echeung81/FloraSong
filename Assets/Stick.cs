using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : Pickupable {


	public override void OnPickup () {

		StickSpawner.NumSticksInField--;
	}
}
