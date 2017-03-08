using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_FollowScript : MonoBehaviour {
	PointerClicker PClick;
	Transform ThisFleet;

	Vector3 ToPosition, ToPosToDist;

	Quaternion LookingToRotation;

	public float FleetSpeed, RotSpeed, Z_Ang;

	// Use this for initialization
	void Start () {
		PClick = GameObject.FindGameObjectWithTag ("CursorManager").GetComponent<PointerClicker> ();
		ThisFleet = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		ToPosition = PClick.CursorToWorld;

		//Debug.DrawRay (Vector3.zero, ToPosition, Color.green);

		MovingTo ();
	}

	void MovingTo(){

		ToPosToDist = new Vector3(ToPosition.x,ToPosition.y,0.0f) - new Vector3(ThisFleet.position.x, ThisFleet.position.y, 0.0f);

		//creates angle in rads
		AngleUpdater();

		ThisFleet.rotation = Quaternion.Slerp(ThisFleet.rotation,LookingToRotation, Time.deltaTime * RotSpeed);

		ThisFleet.transform.Translate (Vector3.up * FleetSpeed * Time.deltaTime, Space.Self);
	}


	void AngleUpdater(){
		float angleRad = Mathf.Atan2 (ToPosToDist.y, ToPosToDist.x);

		//TheDrawRay
		//Debug.DrawRay (Vector3.zero, Quaternion.EulerAngles(0.0f,0.0f,angleRad)*Vector3.right*100.0f, Color.green);

		Z_Ang = angleRad * Mathf.Rad2Deg;
		if (Z_Ang < 0) {
			Z_Ang += 360;
		}
		//float angleDegrees 

		LookingToRotation = Quaternion.Euler (0.0f, 0.0f, Z_Ang-90.0f);
	}
}