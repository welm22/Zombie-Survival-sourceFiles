using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour {

    // Use this for initialization
    float held = 0;
    bool attach = false;
    Collider gun = null;
    int guns_held = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        held = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch);

        if (attach == true && held >0)
        {
            gun.gameObject.transform.parent = transform;
            string gun_name = gun.gameObject.name;
            char hold = gun_name[0];
            

            gun.gameObject.transform.localPosition = new Vector3((float).038, (float).049, (float).136);
            if  (hold == 'H')  gun.gameObject.transform.localPosition = new Vector3((float).028, (float).039, (float).056);
            if (gun.gameObject.name.Equals("ColtM4")) gun.gameObject.transform.localPosition = new Vector3((float).039, (float).039, (float)0.161);
            if (gun.gameObject.name.Equals("Uzi")) gun.gameObject.transform.localPosition = new Vector3((float).03, (float)-.054, (float)-.02);
            gun.gameObject.transform.localRotation = Quaternion.identity;
        }
        else 
        {
            if (gun != null) gun.gameObject.transform.parent = null;
            attach = false;
            guns_held = 0;
           // Debug.Log("HELLO");
        }
    }
   
    private void OnTriggerStay(Collider other)
    {

        //Debug.Log(held);
        held = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch);//added 

        if (other.gameObject.tag.Equals("ak") && held > 0 && guns_held==0)
        {
            gun = other;
            attach = true;
            guns_held = 1;

        }
        //else attach = false;
      //  else transform.DetachChildren();





    }
    private void OnTriggerExit(Collider other)
    {
        if (gun != null)
        {
            string h = gun.gameObject.name;
            if (other.gameObject.name.Equals(h))
            {
                guns_held = 0;
                gun = null;
            }
        }
    }
}
