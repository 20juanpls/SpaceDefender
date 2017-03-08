using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	public Vector3 rotation;
	public bool locked = true;

	Quaternion deflat;

	void Start(){
		deflat = this.transform.rotation;
	}

	// Update is called once per frame
	void Update () 
	{
		if (!locked) 
		{
			this.transform.Rotate (rotation);
		} 
		else 
		{
			this.transform.rotation = deflat;
		}
	}
}
