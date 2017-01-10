using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PointerClicker : MonoBehaviour {

	Rigidbody thisModule;
	public float DeFORCE;
	bool mouseHover;

	// Use this for initialization
	void Start () {
		thisModule = this.GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {
		float Horatio = Input.GetAxis ("Horizontal");
		float Tito = Input.GetAxis ("Vertical");

		Vector3 DICKMAN = new Vector3 (Horatio, Tito, 0.0f);

		thisModule.AddForce (DICKMAN*DeFORCE);
	}
}
