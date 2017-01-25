using UnityEngine;
using System.Collections;

public class Camera_Script : MonoBehaviour {
	Camera cam;

	float CamZoomNum, FinalZoom, OrigSize;
	// Use this for initialization
	void Start () {
		cam = this.GetComponent<Camera> ();
		OrigSize = cam.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		CamZoomNum = Input.GetAxis ("Vertical") * 5;

		FinalZoom = Mathf.Clamp (CamZoomNum + OrigSize, 2.0f, 20.0f);
	
		cam.orthographicSize = FinalZoom;
	}
}
