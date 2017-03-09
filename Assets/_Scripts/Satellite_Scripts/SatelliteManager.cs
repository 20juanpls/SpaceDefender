using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteManager : MonoBehaviour {
	PointerClicker PClick;
	AreaHudManager AHudM;
	ModuleManager ModManGer;

	Transform MainSpaceSCTrans;
	GameObject AtkSatFolder;
	GameObject PasSatFolder;

	public ArrayList PasSatList;
	public ArrayList AtkSatList;
	public ArrayList AllSatelites;
	// Use this for initialization
	void Start () {
		if (AllSatelites == null) {
			AllSatelites = new ArrayList ();
		}
		if (PasSatList == null) {
			PasSatList = new ArrayList ();
		}
		if (AtkSatList == null) {
			AtkSatList = new ArrayList ();
		}





		//PasSatFolder = GameObject.Find ("PassiveSatellites"); -- not yeet
		AtkSatFolder = GameObject.Find ("AttackSatellites");


		PClick = GameObject.FindGameObjectWithTag ("CursorManager").GetComponent<PointerClicker> ();
		AHudM = GameObject.Find ("Sub_AreaSwitch Canvas").GetComponent<AreaHudManager> ();
		ModManGer = this.gameObject.GetComponent<ModuleManager> ();

		for (int i = 0; i < AtkSatFolder.transform.childCount; i ++){
			AtkSatList.Add (AtkSatFolder.transform.GetChild (i).gameObject);
			//PasSatList.Add (PasSatFolder.transform.GetChild (i).gameObject);
		}

		for (int i = 0; i < AtkSatList.Count; i++) {
			//GameObject PasTemp = (GameObject)PasSatList [i];
			GameObject AtkTemp = (GameObject)AtkSatList [i];
			//AllSatelites.Add (PasTemp);
			AllSatelites.Add (AtkTemp);
		}

		ResetAllSat ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		CheckSatAdder ();

		SatDestroyer ();

	}

	void CheckSatAdder(){
		if (AHudM.LockedIn == true) {
			if (PClick.ATTpos == true && CheckLatestMod (ModManGer.AtkModList) == true) {
				//Debug.Log("u can add Atk");
				ModManGer.EnablingModRenderer (AtkSatList);
			} else if (PClick.PASpos == true) {
				//Debug.Log("u can add Pas");
				ModManGer.EnablingModRenderer (PasSatList);
			}
		}
	}

	bool CheckLatestMod(ArrayList a_List){
		GameObject tee = (GameObject)a_List [a_List.Count-1];
		if (tee.activeSelf == true) {
			return true;
		} 
		else {
			return false;
		}
	}

	void SatDestroyer(){
		if (Input.GetKey(KeyCode.S)) {
			for (int i = 0; i < AllSatelites.Count; i++) {
				GameObject ModDes = (GameObject)AllSatelites [i];
				if (ModDes.GetComponent<ModDistanceMeasurer> ().ClickedD == true) {
					ModDes.SetActive(false);
				}
			}
		}
	}

	void ResetAllSat(){
		for (int i = 0; i < AtkSatList.Count; i++) {
			//GameObject PasTemp = (GameObject)PasSatList [i];
			GameObject AtkTemp = (GameObject)AtkSatList [i];
			//PasTemp.SetActive(false);
			AtkTemp.SetActive(false);

		}
	}
}
