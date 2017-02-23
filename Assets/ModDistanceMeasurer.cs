using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModDistanceMeasurer : MonoBehaviour {
	PointerClicker thePointer;

	Vector3 thisGModPos;

	public float distanceToCursor;
	// Use this for initialization
	void Start () {
		thePointer = GameObject.FindGameObjectWithTag ("CursorManager").GetComponent<PointerClicker> ();
		//thisGModPos = 	
	}
	
	// Update is called once per frame
	void Update () {
		//distanceToCursor = Vector3.Magnitude(thePointer.CursorToDistance - )
	}
}
