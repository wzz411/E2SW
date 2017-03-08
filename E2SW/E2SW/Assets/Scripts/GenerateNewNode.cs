using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateNewNode : MonoBehaviour {

	public Transform button;
	public GameObject node;
	public InputField laborInputField;

	private GameObject newNode;

	public void Generate() {

		int numberOfNewNode = 1;

		Debug.Log ("Generated!");
		if (int.Parse (laborInputField.text) >= 2)
			numberOfNewNode += 1;
		if (int.Parse (laborInputField.text) >= 5)
			numberOfNewNode += 1;

		while (numberOfNewNode > 0) {
			newNode = Instantiate (node, new Vector3 (transform.position.x + 150, transform.position.y - (numberOfNewNode - 1) * 150, transform.position.z), Quaternion.identity) as GameObject;
			numberOfNewNode--;
		}
		if (button.GetComponent<Button> ().IsInteractable () == true) {
			button.GetComponent<Button> ().interactable = false;
			button.GetComponent<Renderer> ().material.color = Color.gray;
		} else {
			button.GetComponent<Button> ().interactable = true;
			button.GetComponent<Renderer> ().material.color = Color.white;
		}
	}
}