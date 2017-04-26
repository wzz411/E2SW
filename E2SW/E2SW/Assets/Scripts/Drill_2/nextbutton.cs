using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextbutton : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){

		textcontrol.randQuestion = -1;
		//GameObject.FindWithTag ("resultObj").GetComponentInParent<TextMesh> ().text = "";

	}
}
