using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManager : MonoBehaviour {
	Transform MainSpaceSCTrans;

	public GameObject TheModule;


	Vector3 SpaceSCPos;
	Vector3 TestRayBae;
	// Use this for initialization
	void Start () {
		MainSpaceSCTrans = GameObject.FindGameObjectWithTag("MSSC_model").GetComponent<Transform>();
		SpaceSCPos = MainSpaceSCTrans.position;

		//First Set
		TestRayBae = Quaternion.EulerAngles(0.0f,0.0f,(60/Mathf.Rad2Deg))*Vector3.right*1.05f;
		PlaceProbe (TestRayBae, Quaternion.EulerAngles ((-120/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)));

		//Second Set
		PlaceProbe (Quaternion.EulerAngles (0.0f, 0.0f, (60 / Mathf.Rad2Deg)) * Vector3.right*2.7f, Quaternion.EulerAngles ((-120/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)));

		PlaceProbe (Quaternion.EulerAngles (0.0f, 0.0f, (120 / Mathf.Rad2Deg)) * Vector3.right*2.7f, Quaternion.EulerAngles ((-60/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)));

		//Third Set
		PlaceProbe (Quaternion.EulerAngles (0.0f, 0.0f, (60 / Mathf.Rad2Deg)) * Vector3.right*4.5f, Quaternion.EulerAngles ((-120/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)));

		PlaceProbe (Quaternion.EulerAngles (0.0f, 0.0f, (90 / Mathf.Rad2Deg)) * Vector3.right*4.8f, Quaternion.EulerAngles ((-90/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)));

		PlaceProbe (Quaternion.EulerAngles (0.0f, 0.0f, (120 / Mathf.Rad2Deg)) * Vector3.right*4.5f, Quaternion.EulerAngles ((-60/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)));

	}
	
	// Update is called once per frame
	void Update () {
		//TestRayBae = Quaternion.EulerAngles(0.0f,0.0f,(60/Mathf.Rad2Deg))*Vector3.right;
		Debug.DrawRay (Vector3.zero, TestRayBae, Color.red);
		Debug.Log (TestRayBae);

	}

	void PlaceProbe(Vector3 pos, Quaternion rot){
		GameObject _TheModule = (GameObject)Instantiate (TheModule);
		_TheModule.transform.position = pos;
		_TheModule.transform.rotation = rot;
	
	}
}
