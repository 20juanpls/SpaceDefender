using UnityEngine;
using System.Collections;

public class AreaSpriteControler : MonoBehaviour {
	PointerClicker PClick;
	Transform ThisArea;
	Vector3 OrigScale;

	float extensionDist;
	// Use this for initialization
	void Start () {
		PClick = GameObject.FindGameObjectWithTag ("CursorManager").GetComponent<PointerClicker> ();
		ThisArea = this.GetComponent<Transform> ();
		OrigScale = ThisArea.localScale;

	}
	
	// Update is called once per frame
	void Update () {
		extensionDist = PClick.ExtensionDist;

		ThisArea.localScale = OrigScale *(extensionDist/ (Camera.main.orthographicSize * 2.0f));

	}
}
