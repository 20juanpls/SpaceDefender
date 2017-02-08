using UnityEngine;
using System.Collections;

public class Camera_Script : MonoBehaviour {
	Camera cam;

	public float ZoomSpeed = 2.0f, TimeInterval = 1.0f;
	public float ZoomD_0, ZoomD_1, ZoomD_2, ZoomD_3, ZoomD_4, ZoomD_5;

	public int ZoomStep;

	//public float[] DistArr = new float[5];
	public ArrayList DistArr;

	float FinalZoom, CurrentZoom, OrigZoom;
	// Use this for initialization
	void Start () {
		if (DistArr == null) {
			DistArr = new ArrayList();
		}
			
		cam = this.GetComponent<Camera> ();
		OrigZoom = cam.orthographicSize;

		FinalZoom = OrigZoom;
		ZoomD_1 = OrigZoom;
		ZoomStep = 1;

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


		if (Input.GetKeyDown(KeyCode.O) && ZoomStep > 0){
			Debug.Log("ZoomIn!");

			//ZoomSpeed = ((float)DistArr [ZoomStep + 1] - (float)DistArr [ZoomStep]) / TimeInterval;

			ZoomStep--;
			FinalZoom = (float)DistArr[ZoomStep];
		}
		if (Input.GetKeyDown (KeyCode.P) && ZoomStep < 5) {
			Debug.Log ("ZoomOut");

			//ZoomSpeed = ((float)DistArr [ZoomStep] - (float)DistArr [ZoomStep+1]) / TimeInterval;

			ZoomStep++;
			FinalZoom = (float)DistArr [ZoomStep];

		}

		Debug.Log (FinalZoom);

		//FinalZoom = Mathf.Clamp (CamZoomNum + OrigSize, 2.0f, 20.0f);
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
}
