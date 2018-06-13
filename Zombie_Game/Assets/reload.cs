using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reload : MonoBehaviour {

    // Use this for initialization
    public bool attached_to_gun = true;
    float held;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (attached_to_gun == false && held == 0)
        {
            transform.parent = null;

        }

    }
    
    private void OnTriggerStay(Collider other)
    {
       // Debug.Log("HELDHSJKFHSKD");
     /*    held = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.Touch);
        if (other.tag.Equals("left") && held > 0)
        {
            
            transform.parent = other.transform;
            transform.localPosition= new Vector3((float)0.0, (float).049, (float).136);
            attached_to_gun = false;
        }
        //Debug.Log(attached_to_gun);
      */
    } 
}