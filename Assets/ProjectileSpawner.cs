using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : Spawner {

	public GameObject player;

	public override void SpawnStuff() {

		Rigidbody2D cloneBody = Instantiate<GameObject> (thingToSpawn[0]).GetComponent<Rigidbody2D>();
		if (cloneBody != null) {

			cloneBody.transform.position = transform.position;

			DirectedPhysPath path = cloneBody.gameObject.AddComponent<DirectedPhysPath> ();

			path.Seek (player.transform.position, 3000, 5.0f);
		}
	}

		/*
		Stuff prefab = stuffPrefabs [Random.Range (0, stuffPrefabs.Length)];
		Stuff newStuff = prefab.GetPooledInstance<Stuff> ();

		newStuff.transform.localPosition = transform.position;
		newStuff.transform.localScale = Vector3.one * scale.RandomInRange;
		newStuff.transform.localRotation = Random.rotation;
		newStuff.Body.velocity = transform.up * velocity + Random.onUnitSphere * randomVelocity.RandomInRange;
		newStuff.Body.angularVelocity = Random.onUnitSphere * angularVelocity.RandomInRange;

		newStuff.SetMaterial (stuffMaterial); */
	} 
