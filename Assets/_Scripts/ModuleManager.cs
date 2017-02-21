using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManager : MonoBehaviour {
	Transform MainSpaceSCTrans;
	GameObject GenModFolder;
	GameObject PasModFolder;
	GameObject AtkModFolder;

	public GameObject GeneratorModule;
	public GameObject PassiveModule;
	public GameObject AttackModule;


	Vector3 SpaceSCPos;

	public ArrayList GenModList;
	public ArrayList PasModList;
	public ArrayList AtkModList;
	// Use this for initialization
	void Start () {
		if (GenModList == null) {
			GenModList = new ArrayList();
		}
		if (PasModList == null) {
			PasModList = new ArrayList();
		}
		if (AtkModList == null) {
			AtkModList = new ArrayList ();
		}

		GenModFolder = GameObject.Find ("GeneratorModules");
		PasModFolder = GameObject.Find ("PassiveModules");
		AtkModFolder = GameObject.Find ("AttackModules");


		MainSpaceSCTrans = GameObject.FindGameObjectWithTag("MSSC_model").GetComponent<Transform>();
		SpaceSCPos = MainSpaceSCTrans.position;

		//Placing Modules
		PlaceGenModules ();
		PlacePasModules ();
		PlaceAtkModules ();
	}
	
	// Update is called once per frame
	void Update () {
		//TestRayBae = Quaternion.EulerAngles(0.0f,0.0f,(60/Mathf.Rad2Deg))*Vector3.right;
		//Debug.Log(GenModList.Count);
		Debug.Log (PasModList.Count);

	}

	void PlaceMod(Vector3 pos, Quaternion rot, GameObject TheModule){
		GameObject _TheModule = (GameObject)Instantiate (TheModule);
		_TheModule.transform.position = pos;
		_TheModule.transform.rotation = rot;
		if (TheModule == GeneratorModule) {
			GenModList.Add (_TheModule);
			_TheModule.transform.SetParent (GenModFolder.transform);
		}
		if (TheModule == PassiveModule) {
			PasModList.Add (_TheModule);
			_TheModule.transform.SetParent (PasModFolder.transform);
		}
		if (TheModule == AttackModule) {
			AtkModList.Add (_TheModule);
			_TheModule.transform.SetParent (AtkModFolder.transform);
		}
	
	}

	void PlaceGenModules(){
		//First Set
		/*0*/PlaceMod (Quaternion.EulerAngles(0.0f,0.0f,(60/Mathf.Rad2Deg))*Vector3.right*1.05f, Quaternion.EulerAngles ((-120/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)), GeneratorModule);
		//Second Set
		/*1*/PlaceMod (Quaternion.EulerAngles (0.0f, 0.0f, (60 / Mathf.Rad2Deg)) * Vector3.right*2.7f, Quaternion.EulerAngles ((-120/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)),GeneratorModule);
		/*2*/PlaceMod (Quaternion.EulerAngles (0.0f, 0.0f, (120 / Mathf.Rad2Deg)) * Vector3.right*2.7f, Quaternion.EulerAngles ((-60/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)),GeneratorModule);
		//Third Set
		/*3*/PlaceMod (Quaternion.EulerAngles (0.0f, 0.0f, (60 / Mathf.Rad2Deg)) * Vector3.right*4.5f, Quaternion.EulerAngles ((-120/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)),GeneratorModule);
		/*4*/PlaceMod (Quaternion.EulerAngles (0.0f, 0.0f, (90 / Mathf.Rad2Deg)) * Vector3.right*4.8f, Quaternion.EulerAngles ((-90/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)),GeneratorModule);
		/*5*/PlaceMod (Quaternion.EulerAngles (0.0f, 0.0f, (120 / Mathf.Rad2Deg)) * Vector3.right*4.5f, Quaternion.EulerAngles ((-60/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)),GeneratorModule);

	}

	void PlacePasModules(){
		//First Set
		/*0*/PlaceMod (Quaternion.EulerAngles(0.0f,0.0f,(-60/Mathf.Rad2Deg))*Vector3.right*1.05f, Quaternion.EulerAngles ((-60/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)), PassiveModule);
		//Second Set
		/*1*/PlaceMod (Quaternion.EulerAngles (0.0f, 0.0f, (-60/ Mathf.Rad2Deg)) * Vector3.right*2.7f, Quaternion.EulerAngles ((-60/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)),PassiveModule);
		/*2*/PlaceMod (Quaternion.EulerAngles (0.0f, 0.0f, (0 / Mathf.Rad2Deg)) * Vector3.right*2.7f, Quaternion.EulerAngles ((0/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)),PassiveModule);
		//Third Set
		/*3*/PlaceMod (Quaternion.EulerAngles (0.0f, 0.0f, (-60 / Mathf.Rad2Deg)) * Vector3.right*4.5f, Quaternion.EulerAngles ((-60/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)),PassiveModule);
		/*4*/PlaceMod (Quaternion.EulerAngles (0.0f, 0.0f, (-30/ Mathf.Rad2Deg)) * Vector3.right*4.8f, Quaternion.EulerAngles ((-30/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)),PassiveModule);
		/*5*/PlaceMod (Quaternion.EulerAngles (0.0f, 0.0f, (0/ Mathf.Rad2Deg)) * Vector3.right*4.5f, Quaternion.EulerAngles ((0/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)),PassiveModule);
	}

	void PlaceAtkModules(){
		//First Set
		/*0*/PlaceMod (Quaternion.EulerAngles(0.0f,0.0f,(-180/Mathf.Rad2Deg))*Vector3.right*1.05f, Quaternion.EulerAngles ((0/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)), AttackModule);
		//Second Set
		/*1*/PlaceMod (Quaternion.EulerAngles (0.0f, 0.0f, (-180/ Mathf.Rad2Deg)) * Vector3.right*2.7f, Quaternion.EulerAngles ((0/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)),AttackModule);
		/*2*/PlaceMod (Quaternion.EulerAngles (0.0f, 0.0f, (-120 / Mathf.Rad2Deg)) * Vector3.right*2.7f, Quaternion.EulerAngles ((60/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)),AttackModule);
		//Third Set
		/*3*/PlaceMod (Quaternion.EulerAngles (0.0f, 0.0f, (-180 / Mathf.Rad2Deg)) * Vector3.right*4.5f, Quaternion.EulerAngles ((0/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)),AttackModule);
		/*4*/PlaceMod (Quaternion.EulerAngles (0.0f, 0.0f, (-150/ Mathf.Rad2Deg)) * Vector3.right*4.8f, Quaternion.EulerAngles ((30/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)),AttackModule);
		/*5*/PlaceMod (Quaternion.EulerAngles (0.0f, 0.0f, (-120/ Mathf.Rad2Deg)) * Vector3.right*4.5f, Quaternion.EulerAngles ((60/Mathf.Rad2Deg),(-90/Mathf.Rad2Deg),(90/Mathf.Rad2Deg)),AttackModule);
	}
}
