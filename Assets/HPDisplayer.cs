using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplayer : MonoBehaviour {

	public HPStat stat;

	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = stat.currHP.ToString ();
	}
}
