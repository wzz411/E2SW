using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

	public GameObject node;
	public GameObject nodeConnection;
	public int initialPos;
	public List<NodeInfo> nodeList = new List<NodeInfo> ();
	public static GameControllerScript Instance;

	private GameObject newNode;
	private GameObject newChildNode;
	private	GameObject newConnection;
	private Transform parentGroup;

	void Start () {

		Instance = this;

		parentGroup = GameObject.Find("NodeGroup").transform;

		if (nodeList.Count == 0) {

			//New Game Method
			newNode = Instantiate (node, new Vector3 (0+initialPos, 0+initialPos, -50), Quaternion.identity, parentGroup) as GameObject;
			newNode.name = "4 0 0";

			nodeList.Add (new NodeInfo (4, 0, 0, newNode.name, false));

			//New Game initicial four node
			for (int i = 0; i < 4; i++) {
				switch (i) {
				case 0:
					newNode = Instantiate (node, new Vector3 (0+initialPos, 150+initialPos, -50), Quaternion.identity, parentGroup) as GameObject;
					break;
				case 1:
					newNode = Instantiate (node, new Vector3 (150+initialPos, 0+initialPos, -50), Quaternion.identity, parentGroup) as GameObject;
					break;
				case 2:
					newNode = Instantiate (node, new Vector3 (0+initialPos, -150+initialPos, -50), Quaternion.identity, parentGroup) as GameObject;
					break;
				case 3:
					newNode = Instantiate (node, new Vector3 (-150+initialPos, 0+initialPos, -50), Quaternion.identity, parentGroup) as GameObject;
					break;
				default:
					Debug.Log ("Fail To Generate");
					break;
				}
				newNode.name = i + " 1 0";

				nodeList.Add (new NodeInfo (i, 1, 0, newNode.name, true));
			}
		} else {

			//Loading the Game Method
			Debug.Log ("Loading the Game");

			List<NodeInfo> tempNodeList = new List<NodeInfo> (nodeList);

			while(tempNodeList.Count != 0) {
				
				Debug.Log (tempNodeList.Count);
				NodeInfo tempNode = tempNodeList [0];

				int[] pos = GenerateNewNode.Instance.changeAbpos (tempNode);
				string name = tempNode.name;

				Vector3 vec3Pos = new Vector3 (pos [0] * 150 + initialPos, pos [1] * 150 + initialPos, -50);

				newNode = Instantiate (node, vec3Pos, Quaternion.identity, parentGroup) as GameObject;
				newNode.name = name;

				List<string> childNodeNames = tempNode.childNodeName;

				if (childNodeNames != null) {

					NodeInfo tempChildNode = tempNode;
					string childNodeName = childNodeNames [0];

					for (int i = 0; i < tempNodeList.Count; i++) {
						if (tempNodeList [i].name == childNodeName) {
							tempChildNode = tempNodeList [i];
							break;
						}
					}

					newChildNode = Instantiate (node, vec3Pos, Quaternion.identity, parentGroup) as GameObject;
					newChildNode.name = childNodeName; 

					newConnection = Instantiate (nodeConnection, new Vector3 (0, 0, 0), Quaternion.identity, parentGroup) as GameObject;
					newConnection.name = childNodeName + " Connection";

					int currentDirection = int.Parse (newNode.name.Split (' ') [0]);

					Connection nC = newConnection.GetComponent<Connection> ();
					nC.SetTargets (newNode.transform as RectTransform, newChildNode.transform as RectTransform);
					nC.SetPoints (currentDirection, (currentDirection + 2) % 4);
					Debug.Log ("Connection Created : " + newChildNode.name);

					tempNodeList.Remove (tempChildNode);
					childNodeNames.Remove (childNodeName);
				}

				tempNodeList.Remove (tempNode);
			}
		}
	}

	public void Reload() {
		Start ();
	}
}