using UnityEngine;
using System.Collections;

public class ManualTreeGenerator : MonoBehaviour
{
	public bool ifDraw = false;
	public GUISkin gameSkin;
	public GameObject node;
	public GameObject line;
	public static int count = 0;

	private Transform prev;
	private Vector3 mousePos;

	//private bool ifCreated = false;			//? make sure that each node generates one child



	void Update(){
		// instantiate node when mouse clicked
		//? if (Input.GetMouseButtonDown(0) && !ifCreated)
//		if (Input.GetMouseButtonDown(0))
//		{
//			mousePos = Input.mousePosition;
//			mousePos.z = 200;
//			Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
//			GameObject newNode = Instantiate(node, worldPos, Quaternion.identity) as GameObject;
//			newNode.name = "node" + count;
//			newNode.transform.SetParent(GameObject.Find ("Node Group").transform);
//			// ? ifCreated = true;
//			count++;					// giving unique name to the new node 
//			Destroy(GameObject.Find("CreateButton")); // or try to disable it: button.enable = false
//
//		}
		if (ifDraw) {
			DrawConnectionLine ();
		}

	}
		



	public void CreateNode(){
		Debug.Log ("creat node ()");
	}

	public void DrawConnectionLine(){
		ifDraw = true;

		mousePos = Input.mousePosition;
		mousePos.z = 200;
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
		GameObject newLine = Instantiate(line, worldPos, Quaternion.identity) as GameObject;
		Vector3 scale = new Vector3(1, Mathf.Sqrt(Mathf.Pow(node.transform.position.y,2f)-Mathf.Pow(mousePos.y,2f)),1);
		newLine.transform.localScale = scale;
		newLine.transform.SetParent(GameObject.Find ("Node Group").transform);			

		if (Input.GetMouseButtonDown (0)) {
			ifDraw = false;
		}


	}




}
