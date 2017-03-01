using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class AreaHudManager : MonoBehaviour {
	GameObject cam;
	Camera camera;

	GameObject _ATT;
	GameObject _PAS;
	GameObject _GEN;

	RawImage ATTHud;
	RawImage PASHud;
	RawImage GENHud;

	PointerClicker PClick;

	Vector3 OrigImgPos, OrigScale, SmallerScale;

	public float HudSpeed = 10.0f;

	public bool LockedIn = false;
	bool IsSet, ClickedStasis;

	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		camera = cam.GetComponent<Camera>();

		PClick = GameObject.FindGameObjectWithTag ("CursorManager").GetComponent<PointerClicker> ();

		_ATT = GameObject.Find ("AttackHud");
		_PAS = GameObject.Find ("PassiveHud");
		_GEN = GameObject.Find ("GeneratorHud");

		ATTHud = _ATT.GetComponent<RawImage>();
		PASHud = _PAS.GetComponent<RawImage>();
		GENHud = _GEN.GetComponent<RawImage>();

		//ATTHud.enabled = false;
		//PASHud.enabled = false;
		//GENHud.enabled = false;

		OrigImgPos = new Vector3(-500.0f, 0.0f, 0.0f);

		_ATT.GetComponent<RectTransform> ().anchoredPosition = OrigImgPos;
		_PAS.GetComponent<RectTransform> ().anchoredPosition = OrigImgPos;
		_GEN.GetComponent<RectTransform> ().anchoredPosition = OrigImgPos;

		OrigScale = _ATT.GetComponent<RectTransform> ().localScale;
		SmallerScale = OrigScale * 0.7f;

		_ATT.GetComponent<RectTransform> ().localScale = SmallerScale;
		_PAS.GetComponent<RectTransform> ().localScale = SmallerScale;
		_GEN.GetComponent<RectTransform> ().localScale = SmallerScale;

	}
	
	// Update is called once per frame
	void Update () {

		ClickToLock ();

		//Change Later ...
		ScaleChanger ();

		if (ClickedStasis == true && IsSet == true) {
			LockedIn = true;
		} else {
			LockedIn = false;
		}


		if (LockedIn == false) {
			if (PClick.GENpos == true) {
				//GENHud.enabled = true;
				_GEN.GetComponent<RectTransform> ().anchoredPosition = Vector3.MoveTowards (_GEN.GetComponent<RectTransform> ().anchoredPosition, Vector3.zero, HudSpeed);
			} else {
				_GEN.GetComponent<RectTransform> ().anchoredPosition = Vector3.MoveTowards (_GEN.GetComponent<RectTransform> ().anchoredPosition, OrigImgPos, HudSpeed);
				//GENHud.enabled = false;
			}

			if (PClick.ATTpos == true) {
				_ATT.GetComponent<RectTransform> ().anchoredPosition = Vector3.MoveTowards (_ATT.GetComponent<RectTransform> ().anchoredPosition, Vector3.zero, HudSpeed);
			} else {
				_ATT.GetComponent<RectTransform> ().anchoredPosition = Vector3.MoveTowards (_ATT.GetComponent<RectTransform> ().anchoredPosition, OrigImgPos, HudSpeed);
			}

			if (PClick.PASpos == true) {
				_PAS.GetComponent<RectTransform> ().anchoredPosition = Vector3.MoveTowards (_PAS.GetComponent<RectTransform> ().anchoredPosition, Vector3.zero, HudSpeed);
			} else {
				//PASHud.enabled = false;
				_PAS.GetComponent<RectTransform> ().anchoredPosition = Vector3.MoveTowards (_PAS.GetComponent<RectTransform> ().anchoredPosition, OrigImgPos, HudSpeed);
			}
		}

		if (_GEN.GetComponent<RectTransform> ().anchoredPosition == Vector2.zero||_ATT.GetComponent<RectTransform> ().anchoredPosition == Vector2.zero||_PAS.GetComponent<RectTransform> ().anchoredPosition == Vector2.zero) {
			IsSet = true;
			//Debug.Log ("Is it set?");
		} else {
			IsSet = false;
		}
	
	}

	void ScaleChanger(){
		if (LockedIn == true) {
			if (PClick.GENpos == true) {
				_GEN.GetComponent<RectTransform> ().localScale = OrigScale;
				//Debug.Log("gen is locked");
			} else if (PClick.ATTpos == true) {
				_ATT.GetComponent<RectTransform> ().localScale = OrigScale;
				//Debug.Log ("Att is locked");
			} else if (PClick.PASpos == true) {
				//Debug.Log ("Pas is locked");
				_PAS.GetComponent<RectTransform> ().localScale = OrigScale;
			} 
		} else {
			_ATT.GetComponent<RectTransform> ().localScale = SmallerScale;
			_PAS.GetComponent<RectTransform> ().localScale = SmallerScale;
			_GEN.GetComponent<RectTransform> ().localScale = SmallerScale;
		}
	}
	void ClickToLock(){
		if (ClickedStasis == false) {
			if (Input.GetMouseButtonDown (0)) {
				ClickedStasis = true;
			}
		} else if (ClickedStasis == true) {
			if (Input.GetMouseButtonDown (0)) {
				ClickedStasis = false;
			}
		}				
	}
}
