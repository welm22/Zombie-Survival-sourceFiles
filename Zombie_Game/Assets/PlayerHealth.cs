using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour {
	public int StartHealth=100;
	public int CurrentHealth=100;
	bool died=false;
	//private Color HighHealth=Color.blue;
	//private Color LowHealth=Color.red;
	public float step=0;


    //public GameObject displaygameover;
    //public GameObject zombies;
	// Use this for initialization
	void Start () {
		CurrentHealth = StartHealth=100;
        //displaygameover.SetActive(false);
        //zombies.SetActive(true);
	}
	public void DamagePlayer (){
        CurrentHealth -= 10;
        if (CurrentHealth <= 0)
        {
            Debug.Log("Player Died");
            //zombies.SetActive(false);
           // displaygameover.SetActive(true);
            died = true;
        }

        if (died) {
            
            SceneManager.LoadScene(2);

        }

	}
	// Update is called once per frame
	void Update () {
		//RenderSettings.skybox.SetColor ("_Tint", Color.Lerp (HighHealth, LowHealth, step));
		//step += (100 - CurrentHealth)/100;
        if (OVRInput.Get(OVRInput.Button.Three))
        {
            #if UNITY_EDITOR
		    UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}
