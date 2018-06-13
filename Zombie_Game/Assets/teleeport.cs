using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleeport : MonoBehaviour {

    // Use this for initialization
    Ray shootRay;
    RaycastHit shootHit;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.parent.parent.parent.parent.localPosition = new Vector3(0, 0, 0);
        
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        //Debug.Log(shootRay.direction);
        Debug.DrawRay(transform.position, transform.forward, Color.red);
        if (Physics.Raycast(shootRay, out shootHit))
        {

            // if (shootHit.collider.name == "grass 1") Debug.Log("YES!");
            //Debug.Log(shootHit.collider.name);
            if (shootHit.collider.name == "grass 1") DrawLine(shootRay.origin, shootHit.collider.transform.position, Color.red, .02f);
        }
        //DrawLine()
    }

    void DrawLine(Vector3 start, Vector3 end, Color color, float duration)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        //lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }
}
