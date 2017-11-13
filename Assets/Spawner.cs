using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//spawners manage the creational aspects of spawning an object
//i.e. interval of spawning, like if we give them some initial kick force, additional particle effects on spawn, etc.
public abstract class Spawner : MonoBehaviour {


	public FloatRange timeBetweenSpawns; 

	[SerializeField]
	bool _active = false;

	public bool Active {

		get { return _active; }
		set { _active = value; }
	}
	//scale, randomVelocity, angularVelocity;

	//public Stuff[] stuffPrefabs;

	//public float velocity;

	//public Material stuffMaterial;

	float timeSinceLastSpawn;

	float currentSpawnDelay;

	public GameObject[] thingToSpawn;

	public abstract void SpawnStuff ();

	// Update is called once per frame
	void FixedUpdate () {

		if (_active) {

			timeSinceLastSpawn += Time.deltaTime;
			if (timeSinceLastSpawn > currentSpawnDelay) {

				timeSinceLastSpawn -= currentSpawnDelay;
				currentSpawnDelay = timeBetweenSpawns.RandomInRange;
				SpawnStuff ();
			}
		}
	} 



}
