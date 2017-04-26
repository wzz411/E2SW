using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text3 : MonoBehaviour {

	List<string> thirdchoice = new List<string>() {"2", "OR", "None  of the above", "2", "3"};

	// Use this for initialization
	void Start () {
		//GetComponent<TextMesh> ().text = thirdchoice [0];
	}
	
	// Update is called once per frame
	void Update () {
		if (textcontrol.randQuestion > -1) {
			GetComponent<TextMesh> ().text = thirdchoice [textcontrol.randQuestion]; 
		}
	}
	void OnMouseDown()
	{
		textcontrol.selectedAnswer = gameObject.name;
		textcontrol.choiceSelected = "y";

	}
}
