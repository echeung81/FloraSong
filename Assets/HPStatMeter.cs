using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPStatMeter : MonoBehaviour {

	public HPStat hpStat;


	public Image tickPrefab;

	public Image frame;
	Image[] tickMarks;

	void Awake() {

	}

	// Use this for initialization
	void Start () {

		tickMarks = new Image[hpStat.maxHP];

		MakeTickMarks ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void MakeTickMarks() {

		for (int i = 0; i < tickMarks.Length; i++) {

			tickMarks[i] = Instantiate<Image> (tickPrefab);
			tickMarks[i].transform.SetParent (frame.transform, false);
		}
	}
}
