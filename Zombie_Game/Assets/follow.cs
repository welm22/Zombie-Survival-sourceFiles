using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class follow : MonoBehaviour {
	public Transform target;
	public float speed;
	public Animator myAnimation;
	public Rigidbody rb;
	NavMeshAgent nav;
    Vector3 hold ;
   
	// Use this for initialization
	void Start(){
		nav = GetComponent<NavMeshAgent> ();
	}
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (target.position, transform.position);
        //rb.isKinematic = true;
        bool a = myAnimation.GetCurrentAnimatorStateInfo(0).IsName("fallingback");
        
		if (distance >= 6f && (!a)) {
			//myAnimation.SetBool ("Stop", false);

			/*float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
			transform.LookAt (target);*/
			nav.SetDestination (target.position);
            hold = transform.position;
            //rb.velocity = Vector3.zero;
        } else   {
            //myAnimation.SetBool ("Stop", true);
            //rb.isKinematic = false;
            //transform.position = Vector3.MoveTowards (transform.position, target.position, 0);
            
            //rb.velocity=Vector3.zero;
            //transform.LookAt (target);
            transform.position = hold;

        }
	}
}
