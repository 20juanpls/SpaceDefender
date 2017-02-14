using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Camera_Script : MonoBehaviour {
	Camera cam;
	public GameObject ZoomHud;

	public int FieldOfView_LV,ZoomStep;

	public float ZoomSpeed = 2.0f, TimeInterval = 1.0f;
	public float ZoomD_0, ZoomD_1, ZoomD_2, ZoomD_3, ZoomD_4, ZoomD_5;

	//public float[] DistArr = new float[5];
	public ArrayList DistArr;

	float FinalZoom, CurrentZoom, OrigZoom;

	public bool ChangingLv;

	private bool ZoomIn, ZoomOut;
	// Use this for initialization
	void Start () {
		if (DistArr == null) {
			DistArr = new ArrayList();
		}

		ZoomHud = GameObject.Find("ZoomButtonsCanvas");
		AssignZoomButtons ();
			
		cam = this.GetComponent<Camera> ();
		OrigZoom = cam.orthographicSize;

		FinalZoom = OrigZoom;
		ZoomD_1 = OrigZoom;
		ZoomStep = 1;
		FieldOfView_LV = 1;

		DistArr.Add (ZoomD_0);
		DistArr.Add (ZoomD_1);
		DistArr.Add (ZoomD_2);
		DistArr.Add (ZoomD_3);
		DistArr.Add (ZoomD_4);
		DistArr.Add (ZoomD_5);
	}
	
	// Update is called once per frame
	void Update () {
		CurrentZoom = cam.orthographicSize;

		ZoomUpgrade ();

		ZoomActivator ();
		CamZoomSetter ();

		//Debug.Log ("Changing?: "+ChangingLv);

	}

	void ZoomActivator(){
		if (ZoomIn == true/*Input.GetKeyDown(KeyCode.O)*/ && ZoomStep > 0){
			//Debug.Log("ZoomIn!");

			ZoomSpeed = ((float)DistArr [ZoomStep] - (float)DistArr [ZoomStep - 1]) / TimeInterval;

			ZoomStep--;
			FinalZoom = (float)DistArr[ZoomStep];
		}
		if (ZoomOut == true/*Input.GetKeyDown (KeyCode.P)*/ && ZoomStep < FieldOfView_LV) {
			//Debug.Log ("ZoomOut");

			ZoomSpeed = ((float)DistArr [ZoomStep + 1] - (float)DistArr [ZoomStep]) / TimeInterval;

			ZoomStep++;
			FinalZoom = (float)DistArr [ZoomStep];

		}
		ZoomIn = false;
		ZoomOut = false;
	}

	void CamZoomSetter(){
		if (CurrentZoom != FinalZoom){
			if (CurrentZoom < FinalZoom) {
				CurrentZoom += (ZoomSpeed * Time.deltaTime);
			}
			if (CurrentZoom > FinalZoom) {
				CurrentZoom -= (ZoomSpeed * Time.deltaTime);
			}
		}

		cam.orthographicSize = CurrentZoom;
	}

	void ZoomUpgrade(){
		if (Input.GetKeyDown (KeyCode.L) && FieldOfView_LV < DistArr.Count - 1) {
			FieldOfView_LV++;
			ChangingLv = true;
		} else if (Input.GetKeyDown (KeyCode.K) && FieldOfView_LV > 1) {
			FieldOfView_LV--;
			ChangingLv = true;
		} else {
			ChangingLv = false;
		}

		if (ZoomStep > FieldOfView_LV) {
			ZoomStep = FieldOfView_LV;
			FinalZoom = (float)DistArr [ZoomStep];
		}
	}

	void AssignZoomButtons(){
		Button ZoomIn = ZoomHud.transform.GetChild (0).GetComponent<Button> ();
		Button ZoomOut = ZoomHud.transform.GetChild (1).GetComponent<Button> ();

		ZoomIn.onClick.AddListener (delegate {
			TheZoomIn();
		});
		ZoomOut.onClick.AddListener (delegate {
			TheZoomOut();
		});
	}

	public void TheZoomIn(){
		ZoomIn = true;
	}
	public void TheZoomOut(){
		ZoomOut = true;
	}
}
