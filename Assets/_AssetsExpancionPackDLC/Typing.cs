using UnityEngine;
using System.Collections;

public class Typing : MonoBehaviour
{
	private int clicks;
	private bool clicked;

	// Use this for initialization
	void Start () 
	{
		clicks = 0;
		clicked = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Fire1") && !clicked)
		{
			clicks++;
			clicked = true;

			Debug.Log("You moron, nothing happens when you click. This project is just for visual stuff.");
		}
		else if(Input.GetButtonDown("Fire1") && clicked && clicks <= 100)
		{
			clicks++;

			Debug.Log("Seriously, you've clicked " + clicks + " times. You need to stop. It really doesn't do anything.");
		}
		else{
			clicks++;
			Debug.Log ("Congrats you've clicked 100 times. You super suck you big smelly looser. you are an equivilent of maya d");
		}
	}
}
