using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionBuildScript : MonoBehaviour {
	public string sceneName;
	Text PressI;
	GameObject Instruct;
	public bool InstructOnOff = false;



	// Use this for initialization
	void Start () {
		PressI = GameObject.Find ("PressI").GetComponent<Text> ();
		Instruct = GameObject.Find ("Instruct");
		Instruct.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (InstructOnOff == false) {
			if (Input.GetKeyDown (KeyCode.I)) {
				Instruct.SetActive (true);
				InstructOnOff = true;
				PressI.text = "Type \"I\" to disable Instructions for this build";
			}
		} else if (InstructOnOff == true) {
			if (Input.GetKeyDown (KeyCode.I)) {
				Instruct.SetActive (false);
				InstructOnOff = false;	
				PressI.text = "Type \"I\" to enable Instructions for this build";
			}
		
		}


		if (Input.GetKeyDown (KeyCode.X)) {
			SceneManager.LoadScene(sceneName);
		}
	}
}
