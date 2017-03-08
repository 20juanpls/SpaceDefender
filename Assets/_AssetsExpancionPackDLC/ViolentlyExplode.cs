using UnityEngine;
using System.Collections;

public class ViolentlyExplode : MonoBehaviour {

	GameObject g;
	public bool exploded = false;
	public int explodoMans;

	// Use this for initialization
	void Start () {
		Debug.Log ("Exploded: "+  exploded);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && exploded == false){
			this.gameObject.AddComponent<Rigidbody>();
			this.gameObject.AddComponent<BoxCollider>();
			for (int x = 0; x < explodoMans; x++){
				g = GameObject.Instantiate(this.gameObject);
				g.GetComponent<ViolentlyExplode>().exploded = true;
			}
		}
	}
}
