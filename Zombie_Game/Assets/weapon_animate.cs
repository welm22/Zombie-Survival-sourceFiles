using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_animate : MonoBehaviour
{

    // Use this for initialization
    //public Animation shoot;
    Animator anim;
    bool fire;
    bool right_hand_near;
    float right_pressed;
    bool is_first_gun;
    public int ammo;

    void Start()
    {
        string gun_name = name;
        char hold = gun_name[0];
        if (hold=='H') ammo = 10;
        if (hold == 'A') ammo = 30;
        if (hold == 'C') ammo = 20;
        //if (name=="AK-47")ammo=
        fire = false;
        right_hand_near = false;
        is_first_gun = false;
        anim = GetComponent<Animator>();
    }
    /*
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(4);
    }

    */

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ammo);

        ///////////////////////////////////////////
        right_pressed = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        float held = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);

        if (right_pressed > 0 && right_hand_near && ammo>0)
            fire = true;
        else
            fire = false;
        anim.SetBool("shoot", fire);

        //Debug.Log(right_pressed);
        if (held == 0)
        {

           // script check_magazine = transform.GetChild(0).GetComponent<reload>();

            //Debug.Log(transform.position.y);
            if (transform.position.y > 6.5)
            {
                this.GetComponent<Rigidbody>().isKinematic = false;
                this.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                
                this.GetComponent<Rigidbody>().useGravity = true;
               this.transform.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
            }

            else
            {
                this.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = true;
                this.GetComponent<Rigidbody>().isKinematic = true;


            }

            // Debug.Log(this.GetComponent<Rigidbody>().useGravity);

        }
        else if (right_hand_near)
        {
            // if (this.transform.GetChild(0).name == "AK_47_Magazine") 
            this.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
        }



        // if (fire==true) anim.SetTrigger(go);
        // Debug.Log(fire);




    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("right")) right_hand_near = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("right")) right_hand_near = false;
    }
}
