using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class died : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(OVRInput.Button.Four))
        {
            //if player wants to restart
            SceneManager.LoadScene(1);
        }
        //if player wants to quit
        else if (OVRInput.Get(OVRInput.Button.Three))
        {
        #if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
        }
    }
}
