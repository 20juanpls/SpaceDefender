using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModDistanceMeasurer : MonoBehaviour {
	PointerClicker thePointer;

	Vector3 thisGModPos;
	public Vector3 thisPlanePos;

	public float distanceToCursor;
	// Use this for initialization
	void Start () {
		thePointer = GameObject.FindGameObjectWithTag ("CursorManager").GetComponent<PointerClicker> ();
		thisGModPos = this.gameObject.GetComponent<Transform> ().position;
		thisPlanePos = new Vector3 (thisGModPos.x, thisGModPos.y, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		distanceToCursor = Vector3.Magnitude (thePointer.CursorToDistance - thisPlanePos);
		/*if (distanceToCursor <= 1.0f) {
			this.GetComponent<MeshRenderer> ().enabled = true;
		} else {
			this.GetComponent<MeshRenderer> ().enabled = false;
		}*/
	}
}
