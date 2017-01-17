using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class AreaHudManager : MonoBehaviour {
	GameObject _ATT;
	GameObject _PAS;
	GameObject _GEN;

	RawImage ATTHud;
	RawImage PASHud;
	RawImage GENHud;

	PointerClicker PClick;

	Vector3 OrigImgPos;

	// Use this for initialization
	void Start () {
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
		_GEN.GetComponent<RectTransform> ().anchoredPosition = OrigImgPos;
	}
	
	// Update is called once per frame
	void Update () {
		if (PClick.GENpos == true) {
			//GENHud.enabled = true;
			_GEN.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(_GEN.GetComponent<RectTransform>().anchoredPosition, Vector3.zero, 50.0f);
		} else {
			_GEN.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(_GEN.GetComponent<RectTransform>().anchoredPosition,OrigImgPos , 50.0f);
			//GENHud.enabled = false;
		}

		if (PClick.ATTpos == true) {
			_ATT.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(_ATT.GetComponent<RectTransform>().anchoredPosition, Vector3.zero, 50.0f);
		} else {
			_ATT.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(_ATT.GetComponent<RectTransform>().anchoredPosition, OrigImgPos, 50.0f);
		}

		if (PClick.PASpos == true) {
			_PAS.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(_PAS.GetComponent<RectTransform>().anchoredPosition, Vector3.zero, 50.0f);
		} else {
			//PASHud.enabled = false;
			_PAS.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(_PAS.GetComponent<RectTransform>().anchoredPosition,OrigImgPos , 50.0f);
		}
	
	}
}
