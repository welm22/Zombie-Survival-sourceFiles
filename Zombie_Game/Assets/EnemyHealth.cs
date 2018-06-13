using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	public int StartHealth=100;
	public int CurrentHealth=100;
	bool died=false;
	public Transform target;
	public Animator myAnimation;
	public GameObject player;
	PlayerHealth playerHealth;
	float timer;
	//public float timeBetweenAttacks=0.5f;
	// Use this for initialization
	void Start () {
		CurrentHealth = StartHealth;
		playerHealth = player.GetComponent<PlayerHealth>();
	}

	public void Damage() {
		if (died) {
			return;
		}
		CurrentHealth -= 100;
        //Debug.Log("hit");
        if (CurrentHealth <= 0) {
            myAnimation.SetBool("Died", true);
            Die ();
		}
	}
	void Die(){
		died = true;
        //Debug.Log("zombie died");
        myAnimation.SetBool ("Died", true);
        Collider tes= this.GetComponent<BoxCollider>();
        tes.enabled = false;
		Destroy (gameObject, 2f);
               
	}

	void Attack(){
		timer = 0f;
		playerHealth.DamagePlayer();
	}
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		float distance = Vector3.Distance (target.position, transform.position);
		if (distance <= 12f && (!died)) {
			myAnimation.SetBool ("Attack", true);
			//remove playerhealth
			if (timer >= 0.5f) {
				Attack ();
			}
		} else {
			myAnimation.SetBool ("Attack", false);
		}
	}
}
