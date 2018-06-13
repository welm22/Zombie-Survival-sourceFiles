using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {


	public GameObject enemy;                //reference to zombie spawned
	public float spawnCooldown = 3f;            //amount of time between spawns
	public Transform[] spawnPoints;         //reference to point on map that can spawn enemies

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnCooldown, spawnCooldown);
	}
	
	// Update is called once per frame
	void Spawn ()
	{
		
		//pick a random spawner
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		//create a copy of the zombie to be spawned
		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
