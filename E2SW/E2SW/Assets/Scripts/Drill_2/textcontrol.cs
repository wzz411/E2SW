using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textcontrol : MonoBehaviour {

	List<string> questions = new List<string>() {"How many subsystems appear in the second level?","What logical connection connects the top event and second level?", "For subsystem 1 in the second level, do any systems appear in the third level?", "If HV1 and HV2 failed, how many systems will fail (excluding HV1 and HV2)?", "How many systems would need to fail for ignitions system to fail?"};

	List<string> correctAnswer = new List<string>() {"4", "3", "1", "4", "4"};

	public Transform resultObj;

	public static string selectedAnswer; 

	public static string choiceSelected = "n";

	public static int randQuestion = -1;

	// Use this for initialization
	void Start () {
		//GetComponent<TextMesh> ().text = questions [0]; 	
	}
	
	// Update is called once per frame
	void Update () {
		if (randQuestion == -1) 
		{
			randQuestion = Random.Range (0, 5);
		}
		if (randQuestion >-1)
		{
			GetComponent<TextMesh> ().text = questions [randQuestion]; 
		}
		//Debug.Log (questions [randQuestion]);

		if (choiceSelected == "y") {
			
			choiceSelected = "n";

			if (correctAnswer [randQuestion] == selectedAnswer) {

				resultObj.GetComponent<TextMesh> ().text = "Correct! Click next to continue";

			} else {
				resultObj.GetComponent<TextMesh> ().text = "Incorrect! Click next to continue";
			}
		}
	}
}
