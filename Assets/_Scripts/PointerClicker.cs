using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PointerClicker : MonoBehaviour {

	GameObject cam;
	Camera camera;
	//GameObject MainSpaceStationCenter;
	Transform MainSpaceSCTrans;

	Vector3 MSSCPos_Screen;
	Vector3 CursorDistFromMSSC;

	public float ExtensionDist;

	public float Z_RayAngle;

	// Use this for initialization
	void Start () {
		//MainSpaceStationCenter = GameObject.FindGameObjectWithTag ("");
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		camera = cam.GetComponent<Camera>();
		MainSpaceSCTrans = GameObject.FindGameObjectWithTag("MSSC_model").GetComponent<Transform>();
	
	}
	
	// Update is called once per frame
	void Update () {
		Z_RayAngle = Vector3.Angle (CursorDistFromMSSC,MSSCPos_Screen) * Mathf.Deg2Rad;

		CursorPosUpdater ();
		CursorIsClose ();


		//Debug.Log (Vector3.Angle (CursorDistFromMSSC,MSSCPos_Screen));
		Debug.DrawRay (Vector3.zero, Quaternion.EulerAngles(0.0f,0.0f,Z_RayAngle)*Vector3.right*100.0f, Color.green);
	}

	void CursorPosUpdater(){
		MSSCPos_Screen = camera.WorldToScreenPoint (new Vector3 (MainSpaceSCTrans.position.x,MainSpaceSCTrans.position.y,0.0f));
		CursorDistFromMSSC = new Vector3(Input.mousePosition.x,Input.mousePosition.y,0.0f) - MSSCPos_Screen;
	}
	void CursorIsClose(){
		if (CursorDistFromMSSC.magnitude <= ExtensionDist) {
			if (CursorDistFromMSSC.y >= 0.0f) {

				Debug.Log ("Es North!!");
			} else {
				//Z_RayAngle = -Z_RayAngle;
				Debug.Log("Ayy es south!!");
			
			}
		}
	
	}
}
