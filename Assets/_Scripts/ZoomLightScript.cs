using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ZoomLightScript : MonoBehaviour {
	GameObject cam;
	GameObject thisZoomCanvas;
	Camera_Script CamScript;

	public GameObject LightContainer;
	public GameObject TheLight;

	public int CurrentI = 0;

	public ArrayList LEDs;

	public float LED_UIlenght;


	// Use this for initialization
	void Start () {
		if (LEDs == null)
			LEDs = new ArrayList ();

		cam = GameObject.Find ("Main Camera");
		CamScript = cam.GetComponent<Camera_Script> ();
		thisZoomCanvas = this.gameObject;
		AddLEDs();
		TheLight = Instantiate (TheLight);
		TheLight.transform.SetParent (thisZoomCanvas.transform);
		TheLight.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		CurrentI = CamScript.FieldOfView_LV+1;
	}
	
	// Update is called once per frame
	void Update () {
		UI_Updater ();
		RecenterGrid ();
		LED_LightPos ();
	}

	void AddLEDs(){
		for (int i = CurrentI; i < CamScript.FieldOfView_LV+1; i++) {
			GameObject _LED = (GameObject)Instantiate (LightContainer);
			_LED.transform.SetParent(thisZoomCanvas.transform);
			_LED.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
			_LED.GetComponent<RectTransform>().anchoredPosition = new Vector3((i * 25.0f),70.0f, 0.0f);
			//Space and sizes between LEDs are subject to change...
			LEDs.Add (_LED);
		}
	}

	void UI_Updater(){
		if (CamScript.ChangingLv == true) {
			AddLEDs ();
			CurrentI = CamScript.FieldOfView_LV+1;

			//Debug.Log (LEDs.Count);
			if (LEDs.Count > CurrentI) {
				GameObject _Led = (GameObject)LEDs [CurrentI];
				LEDs.RemoveAt (CurrentI);
				Destroy (_Led);

			}
		}
	}

	void RecenterGrid(){
		GameObject _Leroy = (GameObject)LEDs [0];
		GameObject _LeL = (GameObject)LEDs [CamScript.FieldOfView_LV];
		LED_UIlenght = (_LeL.GetComponent<RectTransform> ().anchoredPosition.x - _Leroy.GetComponent<RectTransform>().anchoredPosition.x)/2.0f;

		for (int j = 0; j < CamScript.FieldOfView_LV + 1; j++) {
			GameObject _LaL = (GameObject)LEDs [j];
			_LaL.GetComponent<RectTransform>().anchoredPosition = new Vector3((j * 25.0f) - LED_UIlenght,70.0f, 0.0f);
		}
	}
	void LED_LightPos(){
		GameObject _Jenkins = (GameObject)LEDs [CamScript.ZoomStep];
		TheLight.GetComponent<RectTransform>().anchoredPosition = _Jenkins.GetComponent<RectTransform>().anchoredPosition;
		TheLight.transform.SetSiblingIndex (thisZoomCanvas.transform.childCount);
	}
}
