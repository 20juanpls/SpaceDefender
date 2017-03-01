using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManager : MonoBehaviour {
	Transform MainSpaceSCTrans;
	GameObject GenModFolder;
	GameObject PasModFolder;
	GameObject AtkModFolder;


	public ArrayList AllModules;
	//public GameObject GeneratorModule;
	//public GameObject PassiveModule;
	//public GameObject AttackModule;


	Vector3 SpaceSCPos;
	GameObject [] GenModHidList;
	GameObject [] PasModHidList;
	GameObject [] AtkModHidList;
	// Use this for initialization
	void Start () {
		if (AllModules == null) {
			AllModules = new ArrayList ();
		}

		GenModFolder = GameObject.Find ("GeneratorModules");
		PasModFolder = GameObject.Find ("PassiveModules");
		AtkModFolder = GameObject.Find ("AttackModules");


		MainSpaceSCTrans = GameObject.FindGameObjectWithTag("MSSC_model").GetComponent<Transform>();
		SpaceSCPos = MainSpaceSCTrans.position;

		//FindingModules
		GenModHidList = GameObject.FindGameObjectsWithTag("GeneratorMod");
		PasModHidList = GameObject.FindGameObjectsWithTag("PassiveMod");
		AtkModHidList = GameObject.FindGameObjectsWithTag("AttackMod");

		for (int i = 0; i < GenModHidList.Length; i++) {
			GameObject GenTemp = (GameObject)GenModHidList [i].gameObject;
			GameObject PasTemp = (GameObject)PasModHidList [i].gameObject;
			GameObject AtkTemp = (GameObject)AtkModHidList [i].gameObject;
			AllModules.Add (GenTemp);
			AllModules.Add (PasTemp);
			AllModules.Add (AtkTemp);
		}
		//FindingModules
		//HideAllModules
		ResetAllModules();
		//HidesMod
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < AllModules.Count; i++){
			GameObject TempMod = (GameObject)AllModules [i];
			if (TempMod.GetComponent<MeshRenderer> ().enabled == true ) {
				//Debug.Log ("This module is a "+TempMod.tag+" and its Mod number: "+i);
			}
		}
	}

	void ResetAllModules(){
		for (int i = 0; i < GenModHidList.Length; i++) {
			GenModHidList [i].GetComponent<MeshRenderer>().enabled = false;
			PasModHidList [i].GetComponent<MeshRenderer>().enabled = false;
			AtkModHidList [i].GetComponent<MeshRenderer>().enabled = false;
		}
	}

	void FindDistanceToCursor(){
		
	}

	void HighlightClosest(GameObject[] ModList){

	}
}
