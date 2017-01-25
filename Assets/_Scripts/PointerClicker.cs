using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PointerClicker : MonoBehaviour {

	GameObject cam;
	Camera camera;
	//GameObject MainSpaceStationCenter;
	Transform MainSpaceSCTrans;

	Vector3 MSSCOrigPos;
	Vector3 CursorToWorld, CursorToDistance;

	public float ExtensionDist;

	public float Z_Angle;

	public bool GENpos,ATTpos,PASpos;

	// Use this for initialization
	void Start () {
		//MainSpaceStationCenter = GameObject.FindGameObjectWithTag ("");
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		camera = cam.GetComponent<Camera>();
		MainSpaceSCTrans = GameObject.FindGameObjectWithTag("MSSC_model").GetComponent<Transform>();
	
	}
	
	// Update is called once per frame
	void Update () {
		AngleUpdater ();

		CursorPosUpdater ();
		CursorIsClose ();

	}

	void CursorPosUpdater(){
		MSSCOrigPos = new Vector3 (MainSpaceSCTrans.position.x,MainSpaceSCTrans.position.y,0.0f);
		CursorToWorld = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y,0.0f));
		CursorToDistance = new Vector3(CursorToWorld.x,CursorToWorld.y,0.0f) - MSSCOrigPos;
	}

	void CursorIsClose(){
		
		if (CursorToDistance.magnitude <= ExtensionDist) {
			if (Z_Angle >= 30 && Z_Angle < 150) {
				//Debug.Log ("I_H8_My_Generation Faction");
				GENpos = true;
			} else {
				GENpos = false;
			}
			if (Z_Angle >= 150 && Z_Angle < 270) {
				//Debug.Log("TRIGGERED Faction");
				ATTpos = true;
			} else {
				ATTpos = false;
			}
			if (Z_Angle >= 270 || Z_Angle < 30) {
				//Debug.Log ("pASSive Faction");
				PASpos = true;
			} else {
				PASpos = false;
			}
		} else {
			GENpos = false;
			ATTpos = false;
			PASpos = false;
		}
	}

	void AngleUpdater(){
		float angleRad = Mathf.Atan2 (CursorToDistance.y, CursorToDistance.x);

		//TheDrawRay
		Debug.DrawRay (Vector3.zero, Quaternion.EulerAngles(0.0f,0.0f,angleRad)*Vector3.right*100.0f, Color.green);

		Z_Angle = angleRad * Mathf.Rad2Deg;
		if (Z_Angle < 0) {
			Z_Angle += 360;
		}
		//float angleDegrees 
	
	
	
	}
}
