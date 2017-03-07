using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateNewNode : MonoBehaviour {

	public Transform button;
	public GameObject node;

	private GameObject newNode;

	public void Generate() {
		Debug.Log ("Generated!");
		newNode = Instantiate(node, new Vector3(transform.position.x + 150, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
		if (button.GetComponent<Button> ().IsInteractable () == true) {
			button.GetComponent<Button> ().interactable = false;
			button.GetComponent<Renderer> ().material.color = Color.gray;
		} else {
			button.GetComponent<Button> ().interactable = true;
			button.GetComponent<Renderer> ().material.color = Color.white;
		}
	}
}