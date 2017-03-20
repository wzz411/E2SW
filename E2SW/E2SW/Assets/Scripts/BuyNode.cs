using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyNode : MonoBehaviour
{
    public static int count;
    public Text funds;
    public Text labor;
    public Text numberOfTurns;
    public Text criteriaA;
    public Text criteriaB;
    public Text criteriaC;
    public Text criteriaD;
    public Text criteriaE;
    public Text criteriaF;
    public Text criteriaG;
    public Text criteriaH;
    public Text turnsRemaining;
    public Text numberOfPurchasedNodes;




    public int exploreLabor;

    public GameObject nodeObject;
    private DisplayInfo scriptToAccess;


    // Use this for initialization
    void Start()
    {
        scriptToAccess = nodeObject.GetComponent<DisplayInfo>();

    }


    public void UpdateInfo()
    {
        
        funds.text = (float.Parse(funds.text) - DisplayInfo.funds).ToString();
        //Debug.Log("buynode.updateinfo");
        labor.text = (int.Parse(labor.text) - DisplayInfo.labor - exploreLabor).ToString();
        numberOfTurns.text = (int.Parse(numberOfTurns.text) + DisplayInfo.numofturn).ToString();
        turnsRemaining.text = (int.Parse(turnsRemaining.text) - DisplayInfo.numofturn).ToString();
        criteriaA.text = (Int32.Parse(criteriaA.text) + DisplayInfo.attrA).ToString();
        criteriaB.text = (Int32.Parse(criteriaB.text) + DisplayInfo.attrB).ToString();
        criteriaC.text = (Int32.Parse(criteriaC.text) + DisplayInfo.attrC).ToString();
        criteriaD.text = (Int32.Parse(criteriaD.text) + DisplayInfo.attrD).ToString();
        criteriaE.text = (Int32.Parse(criteriaE.text) + DisplayInfo.attrE).ToString();
        criteriaF.text = (Int32.Parse(criteriaF.text) + DisplayInfo.attrF).ToString();
        criteriaG.text = (Int32.Parse(criteriaG.text) + DisplayInfo.attrG).ToString();
        criteriaH.text = (Int32.Parse(criteriaH.text) + DisplayInfo.attrH).ToString();
        numberOfPurchasedNodes.text = (Int32.Parse(numberOfPurchasedNodes.text) + 1).ToString();
        count++;
    }
}



