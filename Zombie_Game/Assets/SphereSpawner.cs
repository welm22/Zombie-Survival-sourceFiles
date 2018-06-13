using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour {
	public GameObject SphereToSpawn;
	public Transform[] spawnPoints;
	// Use this for initialization
	void Start () {
		SpawnSphere ();
	}
	
	// Update is called once per frame
	void SpawnSphere() {
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (SphereToSpawn, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
