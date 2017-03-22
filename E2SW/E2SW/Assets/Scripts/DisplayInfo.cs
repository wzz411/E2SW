using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class DisplayInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GUISkin gameSkin;
    private bool displayInfo_ = false;
	public string attributes;
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
	public static int attrIndex=0;
	public static bool ifUpdate = false;

	public string[] attrArray = new string[9];

	private string criteriaA;
	private string criteriaB;
	private string criteriaC;
	private string criteriaD;
	private string criteriaE;
	private string criteriaF;
	private string criteriaG;
	private string criteriaH;

	public void Start()
    {
        // funds random
		attrArray[0] = "";
        funds = UnityEngine.Random.Range(15, 50) * 10;
        attrArray[0] += "$ " + funds + '\n';
        // labor random
		labor = UnityEngine.Random.Range(1, 5);
        attrArray[0] += "Labor " + labor + '\n';
        // number of turns
		numofturn = UnityEngine.Random.Range(1, 3);
        attrArray[0] += "NumofTurn " + numofturn + '\n';
        // attributes
		attrA = UnityEngine.Random.Range(0, 9);
        criteriaA = "Criteria A " + attrA + '\n';
		attrArray[1] = criteriaA;
		attrB = UnityEngine.Random.Range(0, 9);
        criteriaB = "Criteria B " + attrB + '\n';
		attrArray[2] = criteriaB;
		attrC = UnityEngine.Random.Range(0, 9);
        criteriaC = "Criteria C " + attrC + '\n';
		attrArray[3] = criteriaC;
		attrD = UnityEngine.Random.Range(0, 9);
        criteriaD = "Criteria D " + attrD + '\n';
		attrArray[4] = criteriaD;
		attrE = UnityEngine.Random.Range(0, 9);
        criteriaE = "Criteria E " + attrE + '\n';
		attrArray[5] = criteriaE;
		attrF = UnityEngine.Random.Range(0, 9);
        criteriaF = "Criteria F " + attrF + '\n';
		attrArray[6] = criteriaF;
		attrG = UnityEngine.Random.Range(0, 9);
		criteriaG = "Criteria G " + attrG + '\n';
		attrArray[7] = criteriaG;
		attrH = UnityEngine.Random.Range(0, 9);
		criteriaH = "Criteria H " + attrH + '\n';
		attrArray[8] = criteriaH;


        attrWeightedSum += attrA + attrB + attrC + attrD + attrE + attrF + attrG + attrG + attrH ;

    }

	public void Update(){
		if (ifUpdate) {
			switch (attrIndex) {
			case 1: 
				attrArray [1] += criteriaA;
				DisplayName ();
				//Debug.Log(converToString(attrArray));
				//attributes = converToString (attrArray);
				ifUpdate = false;
				break;
			case 2: 
				attrArray [2] += criteriaB;
				DisplayName ();
				ifUpdate = false;
				break;
			case 3: 
				attrArray [3] += criteriaC;
				DisplayName ();
				ifUpdate = false;
				break;
			case 4: 
				attrArray [4] += criteriaD;
				DisplayName ();
				ifUpdate = false;
				break;
			case 5: 
				attrArray [5] += criteriaE;
				DisplayName ();
				ifUpdate = false;
				break;
			case 11:
				attrArray [1] = "";
				DisplayName ();
				//Debug.Log(converToString(attrArray));
				//attributes = converToString (attrArray);
				ifUpdate = false;
				break;
			case 22:
				attrArray [2] = "";
				DisplayName ();
				ifUpdate = false;
				break;
			case 33:
				attrArray [3] = "";
				DisplayName ();
				ifUpdate = false;
				break;
			case 44:
				attrArray [4] = "";
				DisplayName ();
				ifUpdate = false;
				break;
			case 55:
				attrArray [5] = "";
				DisplayName ();
				ifUpdate = false;
				break;

			}
		
		}


	}

    void OnGUI()
    {
        GUI.skin = gameSkin;
        DisplayName();
    }



    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        displayInfo_ = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        displayInfo_ = false;
    }

    public void DisplayName()
    {
        if (displayInfo_)
        {
			GUI.Box(new Rect(Event.current.mousePosition.x + 20, Event.current.mousePosition.y + 10, 150, 180), converToString(attrArray));
        }
    }


	private string converToString(string[] strArray){
		string temp= "";
		for (int i = 0; i < strArray.Length; i++) {
			temp += strArray [i];
		}
		return temp;
	}


}



/*using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class displayInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public string myString;
    public Text myText;
    public float fadeTime;
    public bool displayinfo;
    void Start()
    {
        myText = GameObject.Find("Text").GetComponent<Text>();
        myText.color = Color.clear;
    }

    void Update()
    {
        FadeText();
    }


    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        displayinfo = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        displayinfo = false;
    }
    

    void FadeText()
    {
        if (displayinfo)
        {
            myText.text = myString;
            myText.color = Color.Lerp(myText.color, Color.black, fadeTime * Time.deltaTime);
        }
        else
        {
            myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
        }
    }


}
*/
















