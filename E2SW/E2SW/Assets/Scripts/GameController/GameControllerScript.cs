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
	private Transform parentGroup;

	void Start () {

		Instance = this;

		parentGroup = GameObject.Find("NodeGroup").transform;

		if (nodeList.Count == 0) {

			//New Game Method
			newNode = Instantiate (node, new Vector3 (0 + initialPos, 0 + initialPos, -50), Quaternion.identity, parentGroup) as GameObject;
			newNode.name = "4 0 0";

			NodeInfo nodeInfo = new NodeInfo (4, 0, 0, newNode.name, false);
			nodeInfo.childNodeName = new List<string> {"0 1 0", "1 1 0", "2 1 0", "3 1 0"};
			nodeList.Add (nodeInfo);

			//New Game initicial four node
			for (int i = 0; i < 4; i++) {
				switch (i) {
				case 0:
					newNode = Instantiate (node, new Vector3 (0 + initialPos, 150 + initialPos, -50), Quaternion.identity, parentGroup) as GameObject;
					break;
				case 1:
					newNode = Instantiate (node, new Vector3 (150 + initialPos, 0 + initialPos, -50), Quaternion.identity, parentGroup) as GameObject;
					break;
				case 2:
					newNode = Instantiate (node, new Vector3 (0 + initialPos, -150 + initialPos, -50), Quaternion.identity, parentGroup) as GameObject;
					break;
				case 3:
					newNode = Instantiate (node, new Vector3 (-150 + initialPos, 0 + initialPos, -50), Quaternion.identity, parentGroup) as GameObject;
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

			NodeInfo nodeInfo = nodeList [0];
			int[] parentPos = GenerateNewNode.Instance.changeAbpos (nodeInfo);
			Vector3 vec3ParentPos = new Vector3 (parentPos [0] * 150 + initialPos, parentPos [1] * 150 + initialPos, -50);
			newNode = Instantiate (node, vec3ParentPos, Quaternion.identity, parentGroup) as GameObject;
			newNode.name = nodeInfo.name;
			newNode = generateNode (newNode);
		}
	}

	public void Reload() {
		Start ();
	}

	public GameObject generateNode(GameObject _node) {
		NodeInfo nodeInfo = null;
		GameObject newConnection;
		GameObject newNodeG;

		for (int i = 0; i < nodeList.Count; i++) {
			if (_node.name == nodeList [i].name) {
				nodeInfo = nodeList [i];
				break;
			}
		}

		List<string> childNodeNames = nodeInfo.childNodeName;
		if (childNodeNames != null) {
			for (int i = 0; i < childNodeNames.Count; i++) {
				NodeInfo childNodeInfo = null;

				for (int j = 0; j < nodeList.Count; j++) {
					if (childNodeNames [i] == nodeList [j].name) {
						childNodeInfo = nodeList [j];
						break;
					}
				}

				int[] pos = GenerateNewNode.Instance.changeAbpos (childNodeInfo);
				Vector3 vec3Pos = new Vector3 (pos [0] * 150 + initialPos, pos [1] * 150 + initialPos, -50);

				newNodeG = Instantiate (node, vec3Pos, Quaternion.identity, parentGroup) as GameObject;
				newNodeG.name = childNodeInfo.name;

				newConnection = Instantiate(nodeConnection, new Vector3(0, 0, 0), Quaternion.identity, parentGroup) as GameObject;
				newConnection.name = childNodeNames [i] + " Connection";

				int currentDirection = childNodeInfo.direction;
				Connection nC = newConnection.GetComponent<Connection> ();
				nC.SetTargets (_node.transform as RectTransform, generateNode(newNodeG).transform as RectTransform);
				nC.SetPoints(currentDirection, (currentDirection + 2) % 4);
			}
		}
		return _node;
	}
}