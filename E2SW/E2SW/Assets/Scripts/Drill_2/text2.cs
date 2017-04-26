using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text2 : MonoBehaviour {

	List<string> secondchoice = new List<string>() {"1", "AND", "No", "1", "2"};

	// Use this for initialization
	void Start () {
		//GetComponent<TextMesh> ().text = secondchoice [0]; 
	}
	
	// Update is called once per frame
	void Update () {
		if (textcontrol.randQuestion > -1) {
			GetComponent<TextMesh> ().text = secondchoice [textcontrol.randQuestion]; 
		}
	}
	void OnMouseDown()
	{
		textcontrol.selectedAnswer = gameObject.name;
		textcontrol.choiceSelected = "y";

	}
}
