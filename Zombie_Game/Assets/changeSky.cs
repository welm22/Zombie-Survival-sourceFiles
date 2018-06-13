using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSky : MonoBehaviour {
	public GameObject player;
	PlayerHealth playerHealth;
	public float step = 0;
	Color HighHealth=new Color (.5f, .5f, .5f, .5f);
	Color LowHealth=new Color (.31f, .03f, .03f, .5f);
	// Use this for initialization
	void Start () {
		
		RenderSettings.skybox.SetColor ("_Tint", HighHealth);

	}
	void OnApplicationQuit(){
		RenderSettings.skybox.SetColor ("_Tint", HighHealth);
	}
	// Update is called once per frame
	void Update () {
		RenderSettings.skybox.SetColor ("_Tint", Color.Lerp (HighHealth, LowHealth, step));
		playerHealth = player.GetComponent<PlayerHealth>();
		step = (100f - playerHealth.CurrentHealth)/100f;
	}
}
