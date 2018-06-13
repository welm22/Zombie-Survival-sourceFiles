using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
	public float firerate=.15f;
	float timer;
	Ray shootRay;
	RaycastHit shootHit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (OVRInput.Get (OVRInput.Axis1D.SecondaryIndexTrigger) >= .9) {
			//Shoot ();
		}
	}

	void Shoot(){
		//timer = 0f;
		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;
        //Debug.Log(shootHit);
		if(Physics.Raycast(shootRay, out shootHit)){
			EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth> ();
			if (enemyHealth != null) {
				enemyHealth.Damage ();
			}
		}
	}
}
