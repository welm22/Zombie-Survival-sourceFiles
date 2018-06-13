using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereGrab : MonoBehaviour {

	// Use this for initialization
	public Transform righthand;
	public Transform chest;
    public AudioSource myaudio;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float distanceHand = Vector3.Distance (righthand.position, transform.position);
		float distanceChest = Vector3.Distance (chest.position, transform.position);
		if ((OVRInput.Get (OVRInput.Axis1D.PrimaryHandTrigger) > 0) && (distanceHand <= 3f)) {
            //	transform.position = righthand.position;
            //this.parent
            this.transform.parent = righthand;
            this.transform.localPosition = new Vector3(0, 0, 0);
            myaudio.Stop();
		}
        else this.transform.parent = null;


        if (distanceChest <= 8f) {
			Debug.Log ("you win");
            SceneManager.LoadScene(3);

        }

        
    }


    private void OnTriggerStay(Collider other)
    {
        this.transform.parent = other.gameObject.transform;
    }
    private void OnTriggerExit(Collider other)
    {
        this.transform.parent = null;
    }
}
