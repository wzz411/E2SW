using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text4 : MonoBehaviour {

	List<string> fourthchoice = new List<string>() {"3", "None of the above", "Cannot be determined with current information", "3", "4 "};

	// Use this for initialization
	void Start () {
		//GetComponent<TextMesh> ().text = fourthchoice [0];
	}
	
	// Update is called once per frame
	void Update () {
		if (textcontrol.randQuestion > -1) {
			GetComponent<TextMesh> ().text = fourthchoice [textcontrol.randQuestion]; 
		}
	}
	void OnMouseDown()
	{
		textcontrol.selectedAnswer = gameObject.name;
		textcontrol.choiceSelected = "y";

	} 
}
