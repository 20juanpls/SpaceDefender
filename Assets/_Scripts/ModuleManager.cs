using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManager : MonoBehaviour {
	Transform MainSpaceSCTrans;
	GameObject GenModFolder;
	GameObject PasModFolder;
	GameObject AtkModFolder;



	//public GameObject GeneratorModule;
	//public GameObject PassiveModule;
	//public GameObject AttackModule;


	Vector3 SpaceSCPos;

	GameObject [] GenModHidList;
	GameObject [] PasModHidList;
	GameObject [] AtkModHidList;
	// Use this for initialization
	void Start () {
		GenModFolder = GameObject.Find ("GeneratorModules");
		PasModFolder = GameObject.Find ("PassiveModules");
		AtkModFolder = GameObject.Find ("AttackModules");


		MainSpaceSCTrans = GameObject.FindGameObjectWithTag("MSSC_model").GetComponent<Transform>();
		SpaceSCPos = MainSpaceSCTrans.position;

		//FindingModules
		GenModHidList = GameObject.FindGameObjectsWithTag("GeneratorMod");
		PasModHidList = GameObject.FindGameObjectsWithTag("PassiveMod");
		AtkModHidList = GameObject.FindGameObjectsWithTag("AttackMod");
		//FindingModules
		//HideAllModules
		ResetAllModules();
		//HidesMod
	}
	
	// Update is called once per frame
	void Update () {

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
