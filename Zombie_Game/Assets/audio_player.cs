using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_player : StateMachineBehaviour
{
    public GameObject bullet_prefab;

    // public var gun;
    //public GameObject gun;
   
   
    Ray shootRay;
    RaycastHit shootHit;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // Debug.Log("hello");
       animator.gameObject.GetComponent<AudioSource>().Play();
        //Debug.Log("audio played");
        fire(animator);

    }
    private void fire(Animator gun)
    {
         Quaternion rotation = gun.gameObject.transform.rotation;
        rotation *= Quaternion.Euler(90, 0, 0);
        var bullet = (GameObject)Instantiate(
            bullet_prefab,
            gun.gameObject.transform.position,
             rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * 1000;
        

        //////////////////////////////////////////////////getting ammo
       


         //GameObject thePlayer = GameObject.Find(gun.gameObject.name);
        //Debug.Log(this.name);
         weapon_animate playerScript = gun.gameObject.GetComponent<weapon_animate>();
        playerScript.ammo -= 1;



        //////////////////////////////////////

        /////////////////////////////////////////////////raycasting
       

    //timer = 0f;
    shootRay.origin = gun.gameObject.transform.position;
            shootRay.direction = gun.gameObject.transform.forward;
        //Debug.Log(shootHit);

       // Debug.DrawRay(gun.gameObject.transform.position,shootRay.direction, Color.red, 2, false);
        if (Physics.Raycast(shootRay, out shootHit))
            {
            
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                //Debug.Log("hit");
                enemyHealth.Damage();
                }
            }
        












        ///////////////////////////////////

        Destroy(bullet, 4f);
    }

}

