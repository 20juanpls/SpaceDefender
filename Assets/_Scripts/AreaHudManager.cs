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

	Vector3 OrigImgPos, OrigScale, ChangeScale;

	public float HudSpeed = 10.0f;

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


	}
	
	// Update is called once per frame
	void Update () {

		//Change Later ...
		//ScaleChanger ();

		if (PClick.GENpos == true) {
			//GENHud.enabled = true;
			_GEN.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(_GEN.GetComponent<RectTransform>().anchoredPosition, Vector3.zero, HudSpeed);
		} else {
			_GEN.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(_GEN.GetComponent<RectTransform>().anchoredPosition,OrigImgPos , HudSpeed);
			//GENHud.enabled = false;
		}

		if (PClick.ATTpos == true) {
			_ATT.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(_ATT.GetComponent<RectTransform>().anchoredPosition, Vector3.zero, HudSpeed);
		} else {
			_ATT.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(_ATT.GetComponent<RectTransform>().anchoredPosition, OrigImgPos, HudSpeed);
		}

		if (PClick.PASpos == true) {
			_PAS.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(_PAS.GetComponent<RectTransform>().anchoredPosition, Vector3.zero, HudSpeed);
		} else {
			//PASHud.enabled = false;
			_PAS.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(_PAS.GetComponent<RectTransform>().anchoredPosition,OrigImgPos , HudSpeed);
		}
	
	}

	void ScaleChanger(){
		float height = Camera.main.orthographicSize * 2.0f;
		float width = height * Screen.width / Screen.height;
		//OrigScale = new Vector3(width, height, 0.0f);
		OrigScale = new Vector3(camera.orthographicSize/2* (Screen.width/Screen.height),camera.orthographicSize/2,0.0f);
		//Debug.Log (width);

		_ATT.GetComponent<RectTransform> ().localScale = OrigScale;
		_PAS.GetComponent<RectTransform> ().localScale = OrigScale;
		_GEN.GetComponent<RectTransform> ().localScale = OrigScale;
	}
}
