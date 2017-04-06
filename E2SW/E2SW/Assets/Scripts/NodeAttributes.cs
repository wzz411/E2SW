using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeAttributes : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public GUISkin gameSkin;
	public string[] attributes = new string[9];
	private bool displayInfo = false;

	public static float funds;
	public static float labor;
	public static float numofturn;
	public static float attrA;
	public static float attrB;
	public static float attrC;
	public static float attrD;
	public static float attrE;
	public static float attrF;
	public static float attrG;
	public static float attrH;
	public static float attrWeightedSum=0;

	void Start () {
		attributes[0] = "";
		// funds random
		funds = Random.Range(15, 50) * 10;
		attributes[0] += "$ " + funds + '\n';
		// labor random
		labor = Random.Range(1, 5);
		attributes[0] += "Labor " + labor + '\n';
		// number of turns
		numofturn = Random.Range(1, 3);
		attributes[0] += "NumofTurn " + numofturn + '\n';
		// attributes
		attrA = Random.Range(0, 9);
		attributes[1] = "Criteria A " + attrA + '\n';
		attrB = Random.Range(0, 9);
		attributes[2] = "Criteria B " + attrB + '\n';
		attrC = Random.Range(0, 9);
		attributes[3] = "Criteria C " + attrC + '\n';
		attrD = Random.Range(0, 9);
		attributes[4] = "Criteria D " + attrD + '\n';
		attrE = Random.Range(0, 9);
		attributes[5] = "Criteria E " + attrE + '\n';
		attrF = Random.Range(0, 9);
		attributes[6] = "Criteria F " + attrF + '\n';
		attrG = Random.Range(0, 9);
		attributes[7] = "Criteria G " + attrG + '\n';
		attrH = Random.Range(0, 9);
		attributes[8] = "Criteria H " + attrH + '\n';

		attrWeightedSum += attrA + attrB + attrC + attrD + attrE + attrF + attrG + attrG + attrH ;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{
		GUI.skin = gameSkin;
		DisplayName();
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		displayInfo = true;
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		displayInfo = false;
	}

	public void DisplayName()
	{
		if (displayInfo)
		{
			GUI.Box(new Rect(Event.current.mousePosition.x + 20, Event.current.mousePosition.y + 10, 150, 180), Array2String(attributes));
		}
	}


	private string Array2String(string[] input){
		string result = "";
		for (int i = 0; i < 9; i++) {
			result += input [i];
		}
		return result;
	}

	public void ButtonDebug(){
		Debug.Log ("button clicked");
	}
		
}
