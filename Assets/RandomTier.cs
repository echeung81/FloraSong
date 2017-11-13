using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PctTier {

	public int[] pcts;

	public PctTier(int[] inputPcts) {
		pcts = inputPcts;
	}

	public int Roll() {

		if (pcts == null || pcts.Length < 0) {
			Debug.LogError ("Found pcts with 0 length");
			return -1;
		}
			
		int random = Random.Range(0, 100); // draw a number between 0 and 99
		int lowLim;    // lowLim and hiLim are automatically set for each enemy
		int hiLim = 0;
		for (int currTier = 0; currTier < pcts.Length; currTier++) {
			
			lowLim = hiLim;
			hiLim += pcts[currTier]; 
			if (random >= lowLim && random < hiLim) {
				return currTier;
			}
		}

		return -1; //if hit none of the tiers
	}
}
	