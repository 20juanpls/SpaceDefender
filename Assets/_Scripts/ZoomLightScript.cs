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

	public ArrayList LEDs;


	// Use this for initialization
	void Start () {
		if (LEDs == null)
			LEDs = new ArrayList ();

		cam = GameObject.Find ("Main Camera");
		CamScript = cam.GetComponent<Camera_Script> ();
		thisZoomCanvas = this.gameObject;

		AddLEDs();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void AddLEDs(){
		for (int i = 0; i < CamScript.FieldOfView_LV; i++) {
			GameObject _LED = (GameObject)Instantiate (LightContainer);
			_LED.transform.SetParent(thisZoomCanvas.transform);
			_LED.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			_LED.GetComponent<RectTransform>().anchoredPosition = new Vector3(88.0f + (i * 100), -60.0f, 0.0f);
			LEDs.Add (_LED);
		}
	}
}
