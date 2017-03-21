using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GenerateNewNode : MonoBehaviour {

	public Transform parentGroup;
    public Transform button;
    public InputField laborInputField;
    public BuyNode buyNodeScript;
    public bool ifMastermind;

	public GameObject node;
	public int nodeTrim;

	private GameObject newNode;

    private void Start()
    {
		ifMastermind = false;
        //ifMastermind = Random.Range(0, 100)/50 >= 1;
        //Debug.Log("mastermind "+ifMastermind);
		button.GetComponent<Button> ().interactable = true;
    }

    public void Generate() {

		Debug.Log ("Generated!");

		string[] currentNodeName = transform.name.Split(' ');
		if (int.Parse (currentNodeName [1]) == 4) {
			Debug.Log ("Start");
		}

		//Button unpressable
		if (button.GetComponent<Button> ().IsInteractable () == true) {
			button.GetComponent<Button> ().interactable = false;
			//button.GetComponent<Renderer> ().material.color = Color.black;
		} else {
			button.GetComponent<Button> ().interactable = true;
			//button.GetComponent<Renderer> ().material.color = Color.white;
		}

		//Getting the current node info
		int currentDirection = int.Parse (currentNodeName [0]);
		int currentLevel = int.Parse (currentNodeName [1]);
		int currentOrder = int.Parse (currentNodeName [2]);

		//Making the random number of node
		int maxNode = 2 * (currentLevel + 1) + 1;
		int[] nodeExist = new int[Random.Range(1, maxNode + 1)];
		int element;

		//Checking independence order
		for(int i = 0; i < nodeExist.Length; i++) {
			element = Random.Range (-(currentLevel + 1), currentLevel + 2);
			for (int j = 0; j < i; j++) {
				if (element == nodeExist [j]) {
					i--;
					break;
				}
			}
			nodeExist [i] = element;
		}

		//Checking overrapping
		for (int i = 0; i < nodeExist.Length; i++) {

			string name = currentDirection + " " + (currentLevel + 1) + " " + nodeExist [i];
			NodeInfo _node = new NodeInfo (currentDirection, currentLevel + 1, nodeExist [i], name, true);

			if (!isOverraped (_node)) {
				Vector3 pos = new Vector3 ();
				switch (currentDirection) {
				case 0:
					pos = new Vector3 (nodeTrim * nodeExist [i], nodeTrim * (currentLevel + 1), -50);
					break;
				case 1:
					pos = new Vector3 (nodeTrim * (currentLevel + 1), nodeTrim * nodeExist [i], -50);
					break;
				case 2:
					pos = new Vector3 (-nodeTrim * nodeExist [i], -nodeTrim * (currentLevel + 1), -50);
					break;
				case 3:
					pos = new Vector3 (-nodeTrim * (currentLevel + 1), -nodeTrim * nodeExist [i], -50);
					break;
				default:
					break;
				}
				newNode = Instantiate (node, pos, Quaternion.identity, parentGroup) as GameObject;
				newNode.name = name;
				GameControllerScript.Instance.nodeList.Add (_node);
			}
		}

		foreach (NodeInfo node in GameControllerScript.Instance.nodeList) {
			Debug.Log (node.ToString ());
		}
	}

	//Checking overrapping method
	public bool isOverraped(NodeInfo _node) {
		foreach (NodeInfo node in GameControllerScript.Instance.nodeList) {
			if (isSamePos(_node, node))
				return true;
		}
		return false;
	}

	//Checking same node position method
	public bool isSamePos(NodeInfo node1, NodeInfo node2) {
		int[] node1Ab = changeAbpos (node1);
		int[] node2Ab = changeAbpos (node2);
		return node1Ab[0] == node2Ab[0] && node1Ab[1] == node2Ab[1];
	}

	//Changing to absolute position method
	public int[] changeAbpos(NodeInfo node) {
		switch (node.direction) {
		case 0:
			return new int[] { node.order, node.level };
			break;
		case 1:
			return new int[] { node.level, node.order };
			break;
		case 2:
			return new int[] { -node.order, -node.level };
			break;
		case 3:
			return new int[] { -node.level, -node.order };
			break;
		default:
			return new int[] {0, 0};
			break;
		}
	}
}