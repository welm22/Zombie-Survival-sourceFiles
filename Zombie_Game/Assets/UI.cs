using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    // Use this for initialization
    //public Canvas hi;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Text text = GetComponent <Text> () ;
        GameObject thePlayer = GameObject.Find(transform.parent.parent.name);
        weapon_animate playerScript = thePlayer.GetComponent<weapon_animate>();
        
        text.text = playerScript.ammo+" ";
        //Text text = hi.guiText;
	}
}
