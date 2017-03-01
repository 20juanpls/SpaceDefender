using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManager : MonoBehaviour {
	PointerClicker PClick;
	AreaHudManager AHudM;

	Transform MainSpaceSCTrans;
	GameObject GenModFolder;
	GameObject PasModFolder;
	GameObject AtkModFolder;


	public ArrayList AllModules;
	public ArrayList GenModList;
	public ArrayList PasModList;
	public ArrayList AtkModList;

	Vector3 SpaceSCPos;
	//GameObject [] GenModHidList;
	//GameObject [] PasModHidList;
	//GameObject [] AtkModHidList;

	int modNum;
	// Use this for initialization
	void Start () {
		if (AllModules == null) {
			AllModules = new ArrayList ();
		}
		if (GenModList == null) {
			GenModList = new ArrayList ();
		}
		if (PasModList == null) {
			PasModList = new ArrayList ();
		}
		if (AtkModList == null) {
			AtkModList = new ArrayList ();
		}

		GenModFolder = GameObject.Find ("GeneratorModules");
		PasModFolder = GameObject.Find ("PassiveModules");
		AtkModFolder = GameObject.Find ("AttackModules");

		//FindScripts
		PClick = GameObject.FindGameObjectWithTag ("CursorManager").GetComponent<PointerClicker> ();
		AHudM = GameObject.Find ("Sub_AreaSwitch Canvas").GetComponent<AreaHudManager> ();

		MainSpaceSCTrans = GameObject.FindGameObjectWithTag("MSSC_model").GetComponent<Transform>();
		SpaceSCPos = MainSpaceSCTrans.position;

		//FindingModules
		for (int i = 0; i < GenModFolder.transform.childCount; i ++){
			GenModList.Add (GenModFolder.transform.GetChild (i).gameObject);
			PasModList.Add (PasModFolder.transform.GetChild (i).gameObject);
			AtkModList.Add (AtkModFolder.transform.GetChild (i).gameObject);
		}
			
		//GenModHidList = GameObject.FindGameObjectsWithTag("GeneratorMod");
		//PasModHidList = GameObject.FindGameObjectsWithTag("PassiveMod");
		//AtkModHidList = GameObject.FindGameObjectsWithTag("AttackMod");

		for (int i = 0; i < GenModList.Count; i++) {
			GameObject GenTemp = (GameObject)GenModList [i];
			GameObject PasTemp = (GameObject)PasModList [i];
			GameObject AtkTemp = (GameObject)AtkModList [i];
			AllModules.Add (GenTemp);
			AllModules.Add (PasTemp);
			AllModules.Add (AtkTemp);
		}

		//for debug
		/*for (int k = 0; k< GenModList.Count; k++){
			GameObject ahh = (GameObject)GenModList [k];
			Debug.Log ("Genmod "+k+" is in position "+ahh.transform.position);
		}*/
		//for debug

		//HideAllModules
		ResetAllModules();
		//HidesMod
	}
	
	// Update is called once per frame
	void Update () {

		CheckingModAdder ();

		//ModIdentifier ();


	}

	public int CompareModToList(ArrayList Lester, GameObject ModT){
		for (int j = 0; j < Lester.Count; j++) {
			GameObject theTemp = (GameObject)Lester [j];
			if (ModT == theTemp) {
				return j;
			}
		}
		return-1;
	}

	void CheckingModAdder(){
		if (AHudM.LockedIn == true) {
			if (PClick.GENpos == true) {
				//Debug.Log("u can add Gen");
				EnablingModRenderer (GenModList);
			} else
			if (PClick.ATTpos == true) {
				//Debug.Log("u can add Atk");
				EnablingModRenderer (AtkModList);
			} else
			if (PClick.PASpos == true) {
				//Debug.Log("u can add Pas");
				EnablingModRenderer (PasModList);
			}
		}

	}

	void EnablingModRenderer(ArrayList tehList){
		if (Input.GetKeyDown (KeyCode.A)) {
			for(int i = 0; i < tehList.Count; i ++){
				GameObject tee = (GameObject)tehList [i];
				if (tee.GetComponent<MeshRenderer> ().enabled == false) {
					tee.GetComponent<MeshRenderer> ().enabled = true;
					break;
				}
			}
		}
	}

	void ModIdentifier(){
		for (int i = 0; i < AllModules.Count; i++){
			GameObject TempMod = (GameObject)AllModules [i];
			if (TempMod.GetComponent<MeshRenderer> ().enabled == true ) {
				if (TempMod.tag == "GeneratorMod") {
					modNum = CompareModToList (GenModList, TempMod);
				} else if (TempMod.tag == "PassiveMod") {
					modNum = CompareModToList (PasModList, TempMod);
				} else if (TempMod.tag == "AttackMod") {
					modNum = CompareModToList (AtkModList, TempMod);	
				}
				Debug.Log ("This module is a "+TempMod.tag+" and its Mod number: "+modNum);
			}
		}
	}

	void ResetAllModules(){
		for (int i = 0; i < GenModList.Count; i++) {
			GameObject GenTemp = (GameObject)GenModList [i];
			GameObject PasTemp = (GameObject)PasModList [i];
			GameObject AtkTemp = (GameObject)AtkModList [i];
			GenTemp.GetComponent<MeshRenderer>().enabled = false;
			PasTemp.GetComponent<MeshRenderer>().enabled = false;
			AtkTemp.GetComponent<MeshRenderer>().enabled = false;
		}
	}
}
