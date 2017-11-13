using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct FloatRange {

	public float min, max;

	public float Range() {
		
		return Mathf.Abs (max - min);
	}

	public float RandomInRange
	{
		get { return Random.Range (min, max); } 
	}

}