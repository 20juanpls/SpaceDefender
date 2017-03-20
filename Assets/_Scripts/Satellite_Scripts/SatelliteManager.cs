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

    GameObject leadingSat_L1;
    float leadAngle_L1;

    bool canEnableP, canEnableA;

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

		PasSatFolder = GameObject.Find ("PassiveSatellites");
		AtkSatFolder = GameObject.Find ("AttackSatellites");


		PClick = GameObject.FindGameObjectWithTag ("CursorManager").GetComponent<PointerClicker> ();
		AHudM = GameObject.Find ("Sub_AreaSwitch Canvas").GetComponent<AreaHudManager> ();
		ModManGer = this.gameObject.GetComponent<ModuleManager> ();

		for (int i = 0; i < AtkSatFolder.transform.childCount; i ++){
			AtkSatList.Add (AtkSatFolder.transform.GetChild (i).gameObject);
			PasSatList.Add (PasSatFolder.transform.GetChild (i).gameObject);
		}

		for (int i = 0; i < AtkSatList.Count; i++) {
			GameObject PasTemp = (GameObject)PasSatList [i];
			GameObject AtkTemp = (GameObject)AtkSatList [i];
			AllSatelites.Add (PasTemp);
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
            if (canEnableP == true) {
                SatRendEnabler(PasSatList);
            }
            if (canEnableA == true) {
                SatRendEnabler(AtkSatList);
            }

            if (PClick.ATTpos == true && CheckLatestMod(ModManGer.AtkModList) == true)
            {
                //Debug.Log("u can add Atk");
                canEnableA = true;
            }
            else {
                canEnableA = false;
            }

            if (PClick.PASpos == true && CheckLatestMod(ModManGer.PasModList) == true)
            {
                //Debug.Log("u can add Pas");
                canEnableP = true;
            }
            else {
                canEnableP = false;
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

    void SatRendEnabler(ArrayList tehList) {
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < tehList.Count; i++)
            {
                GameObject tee = (GameObject)tehList[i];
                if (tee.GetComponent<MeshRenderer>().enabled == false)
                {
                    tee.GetComponent<MeshRenderer>().enabled = true;
                    OrderItsChildren(tee, true);
                    break;
                }
            }
        }

    }

    void SatDestroyer(){
		if (Input.GetKey(KeyCode.S)) {
			for (int i = 0; i < AllSatelites.Count; i++) {
				GameObject ModDes = (GameObject)AllSatelites [i];
				if (ModDes.GetComponent<ModDistanceMeasurer> ().ClickedD == true) {
                    ModDes.GetComponent<MeshRenderer>().enabled = false;
                    OrderItsChildren(ModDes, false);
                }
			}
		}
	}

	void ResetAllSat(){
		for (int i = 0; i < AtkSatList.Count; i++) {
			GameObject PasTemp = (GameObject)PasSatList [i];
			GameObject AtkTemp = (GameObject)AtkSatList [i];
            PasTemp.GetComponent<MeshRenderer>().enabled = false;
            OrderItsChildren(PasTemp, false);
            AtkTemp.GetComponent<MeshRenderer>().enabled = false;
            OrderItsChildren(AtkTemp, false);

        }
	}

    void OrderItsChildren( GameObject tehParent, bool OnorOff) {
        for (int i = 0; i < tehParent.transform.childCount; i++) {
            tehParent.transform.GetChild(i).gameObject.SetActive(OnorOff);
        }

    }

}
