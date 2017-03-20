using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GenerateNewNode : MonoBehaviour {


    public Transform button;
    public GameObject node;
    public InputField laborInputField;
    public BuyNode buyNodeScript;
    public bool ifMastermind;

    private GameObject newNode;
	private int nodeTrim = 30;

    private void Start()
    {
		ifMastermind = false;
        //ifMastermind = Random.Range(0, 100)/50 >= 1;
        Debug.Log("mastermind "+ifMastermind);
		button.GetComponent<Button> ().interactable = true;
    }

    public void Generate() {

        int numberOfNode = 1;
        
		if (int.Parse(laborInputField.text) >= Random.Range(3, 6))
            numberOfNode += 1;
		if (int.Parse(laborInputField.text) >= Random.Range(6, 9))
            numberOfNode += 1;

		Debug.Log ("Generated!");

		Debug.Log (numberOfNode + " Generating");

		float[,] positions = new float[numberOfNode,2];

		int order = Mathf.Abs((int)transform.position.x) / nodeTrim;

		order++;

		//Button unpressable
		if (button.GetComponent<Button> ().IsInteractable () == true) {
			button.GetComponent<Button> ().interactable = false;
			//button.GetComponent<Renderer> ().material.color = Color.black;
		} else {
			button.GetComponent<Button> ().interactable = true;
			//button.GetComponent<Renderer> ().material.color = Color.white;
		}

		for (int i = 0; i < numberOfNode; i++) {
			int x, y;
			if (Random.Range (0, 2) == 0) {
				x = Random.Range (1, 50) + nodeTrim * order;
			} else {
				x = Random.Range (-50, -1) - nodeTrim * order;
			}
			if (Random.Range (0, 2) == 0) {
				y = Random.Range (1, 50) + nodeTrim * order;
			} else {
				y = Random.Range (-50, -1) - nodeTrim * order;
			}
			if (isNodeContainOkay (positions, x, y, i)) {
				positions[i,0] = x;
				positions[i,1] = y;
			} else {
				Debug.Log ("Again");
				i--;
			}
		}

        buyNodeScript.exploreLabor = int.Parse(laborInputField.text);
        buyNodeScript.UpdateInfo();

		for (int i = 0; i < numberOfNode; i++) {
			newNode = Instantiate (node, new Vector3 (transform.position.x + positions [i, 0], transform.position.y + positions [i, 1], transform.position.z), Quaternion.identity) as GameObject;
            newNode.AddComponent<BoxCollider2D>();
        }

        // enter mini game
        if (ifMastermind)
        {
            SceneManager.LoadScene("mastermind");
        }
    }
	public bool isNodeContainOkay(float[,] arrays, int x, int y, int num) {
		for (int i = 0; i < num; i++) {
			if ((x < (arrays[i,0] + 25) && x > (arrays[i,0] - 25)) && (y < (arrays[i,1] + 25) || y > (arrays[i,1] - 25))) {
				return false;
			}
		}
		return true;
	}
}
