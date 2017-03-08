using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DisplayInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GUISkin gameSkin;
    public string attributes;
    private bool displayInfo_ = false;

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

    private void Start()
    {
        attributes = "";
        // funds random
        funds = Random.Range(15, 50) * 10;
        attributes += "$ " + funds + '\n';
        // labor random
        labor = Random.Range(1, 5);
        attributes += "Labor " + labor + '\n';
        // number of turns
        numofturn = Random.Range(1, 3);
        attributes += "NumofTurn " + numofturn + '\n';
        // attributes
        attrA = Random.Range(0, 9);
        attributes += "Criteria A " + attrA + '\n';
        attrB = Random.Range(0, 9);
        attributes += "Criteria B " + attrB + '\n';
        attrC = Random.Range(0, 9);
        attributes += "Criteria C " + attrC + '\n';
        attrD = Random.Range(0, 9);
        attributes += "Criteria D " + attrD + '\n';
        attrE = Random.Range(0, 9);
        attributes += "Criteria E " + attrE + '\n';
        attrF = Random.Range(0, 9);
        attributes += "Criteria F " + attrF + '\n';
        attrG = Random.Range(0, 9);
        attributes += "Criteria G " + attrG + '\n';
        attrH = Random.Range(0, 9);
        attributes += "Criteria H " + attrH + '\n';

        attrWeightedSum += attrA + attrB + attrC + attrD + attrE + attrF + attrG + attrG + attrH ;

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
            GUI.Box(new Rect(Event.current.mousePosition.x + 20, Event.current.mousePosition.y + 10, 150, 180), attributes);
        }
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
















