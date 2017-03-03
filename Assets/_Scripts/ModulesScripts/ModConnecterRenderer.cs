using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModConnecterRenderer : MonoBehaviour {
	GameObject thisConnector;
	ModuleManager ModMan;

	public bool Activate = false;

	public bool IsItSingle  = false;
	public bool IsItDouble = false;

	public char Mod_1_Class;
	public int Mod_1_num;
	public char Mod_2_Class;
	public int Mod_2_num;
	public char Mod_3_Class;
	public int Mod_3_num;


	public ArrayList theModList;
	// Use this for initialization
	void Start () {
		thisConnector = this.gameObject;
		ModMan = GameObject.Find ("SpaceStationComponents").GetComponent<ModuleManager> ();
		thisConnector.transform.GetChild (0).GetComponent<MeshRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Activate == true) {
			if (IsItDouble == true) {
				if (IsThingTrue (Mod_1_Class, Mod_1_num) == true && IsThingTrue (Mod_2_Class, Mod_2_num) == true) {
					thisConnector.transform.GetChild (0).GetComponent<MeshRenderer> ().enabled = true;
				} else {
					thisConnector.transform.GetChild (0).GetComponent<MeshRenderer> ().enabled = false;
				}
			} else if (IsItSingle == true) {
				if (IsThingTrue (Mod_1_Class, Mod_1_num) == true) {
					thisConnector.transform.GetChild (0).GetComponent<MeshRenderer> ().enabled = true;
				} else {
					thisConnector.transform.GetChild (0).GetComponent<MeshRenderer> ().enabled = false;
				}
			} else {
				if (IsThingTrue (Mod_1_Class, Mod_1_num) == true && IsThingTrue (Mod_2_Class, Mod_2_num) == true && IsThingTrue (Mod_3_Class, Mod_3_num) == true) {
					thisConnector.transform.GetChild (0).GetComponent<MeshRenderer> ().enabled = true;
				} else {
					thisConnector.transform.GetChild (0).GetComponent<MeshRenderer> ().enabled = false;
				}	
			}
		}
	}

	bool IsThingTrue(char Class, int IDnum){
		if (Class == 'G') {
			theModList = ModMan.GenModList;
		} else if (Class == 'P') {
			theModList = ModMan.PasModList;
		} else if (Class == 'A') {
			theModList = ModMan.AtkModList;
		} else {
			Debug.Log ("No such ID!");
		}

		GameObject tempMod = (GameObject)theModList [IDnum];
		if (tempMod.GetComponent<MeshRenderer> ().enabled == true) {
			return true;
		} else {
			return false;
		}
	}
}
