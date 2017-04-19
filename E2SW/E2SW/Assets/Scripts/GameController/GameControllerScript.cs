using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

	public GameObject node;
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

			for (int i = 0; i < nodeList.Count; i++) {
				int[] pos = GenerateNewNode.Instance.changeAbpos (nodeList [i]);

				newNode = Instantiate (node, new Vector3 (pos [0] * 150 + initialPos, pos [1] * 150 + initialPos, -50), Quaternion.identity, parentGroup) as GameObject;
				newNode.name = nodeList [i].name;
			}
		}
	}

	public void Reload() {
		Start ();
	}
}