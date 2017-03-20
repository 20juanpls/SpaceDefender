using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModDistanceMeasurer : MonoBehaviour {
	PointerClicker thePointer;

	Vector3 thisGModPos;
	public Vector3 thisPlanePos;

	public float distanceToCursor;

	public bool ClickedD;
	// Use this for initialization
	void Start () {
		thePointer = GameObject.FindGameObjectWithTag ("CursorManager").GetComponent<PointerClicker> ();
	}
	
	// Update is called once per frame
	void Update () {
        thisGModPos = this.gameObject.GetComponent<Transform>().position;
        thisPlanePos = new Vector3(thisGModPos.x, thisGModPos.y, 0.0f);

        distanceToCursor = Vector3.Magnitude (thePointer.CursorToDistance - thisPlanePos);

		if (distanceToCursor <= 0.5f && Input.GetMouseButtonDown (0)) {
			ClickedD = true;
		} else {
			ClickedD = false;
		}
	}
}
