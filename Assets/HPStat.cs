using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPStat : MonoBehaviour {

	public int maxHP;

	public int currHP;

	// Use this for initialization
	void Start () {
		currHP = maxHP;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DecrementHP() {

		currHP--;

		if (currHP <= 0) {
			SignalDeath ();
		}
	}

	void SignalDeath() {

	}
}
