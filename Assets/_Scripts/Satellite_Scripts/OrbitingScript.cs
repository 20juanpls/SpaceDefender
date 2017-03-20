using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingScript : MonoBehaviour {

    public float Z_Angle, angleRad;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(Vector3.zero, Vector3.forward, 20 * Time.deltaTime);

        Debug.DrawRay(Vector3.zero,new Vector3(transform.position.x, transform.position.y, 0.0f), Color.green);


        angleRad = Mathf.Atan2(transform.position.y, transform.position.x);

        Z_Angle = angleRad * Mathf.Rad2Deg;
        if (Z_Angle < 0)
        {
            Z_Angle += 360;
        }
    }
}
