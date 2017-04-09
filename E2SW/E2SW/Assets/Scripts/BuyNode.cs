using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyNode : MonoBehaviour
{
    public Button buyButton;
    public static int pn; // pn = numofPN = number of purchased nodes

    public Text funds, labor, current, remaining, criteriaA, criteriaB, criteriaC, criteriaD, criteriaE, criteriaF, criteriaG, criteriaH, numofPN;


    public static int count;

    void Start()
    {
        //TODO: find a more efficient way to assign game objects
        buyButton = GetComponent<Button>();
        buyButton.onClick.AddListener(TaskOnClick);
        funds = GameObject.Find("fundsValue").GetComponent<Text>();
        labor = GameObject.Find("laborValue").GetComponent<Text>();
        current = GameObject.Find("currentTurnValue").GetComponent<Text>();
        remaining = GameObject.Find("turnsRemainingValue").GetComponent<Text>();
        numofPN = GameObject.Find("numofPNValue").GetComponent<Text>();
        //find with tag

        criteriaA = GameObject.Find("ValueCriteriaA").GetComponent<Text>();
        criteriaB = GameObject.Find("ValueCriteriaB").GetComponent<Text>();
        criteriaC = GameObject.Find("ValueCriteriaC").GetComponent<Text>();
        criteriaD = GameObject.Find("ValueCriteriaD").GetComponent<Text>();
        criteriaE = GameObject.Find("ValueCriteriaE").GetComponent<Text>();
        criteriaF = GameObject.Find("ValueCriteriaF").GetComponent<Text>();
        criteriaG = GameObject.Find("ValueCriteriaG").GetComponent<Text>();
        criteriaH = GameObject.Find("ValueCriteriaH").GetComponent<Text>();



    }

    private void TaskOnClick()
    {
        NodeAttributes nodeAttr = gameObject.GetComponentInParent<NodeAttributes>();
        funds.text = (float.Parse(funds.text) - nodeAttr.funds).ToString();
        labor.text = (float.Parse(labor.text) - nodeAttr.labor).ToString();
        current.text = (float.Parse(current.text) + nodeAttr.numofturn).ToString();
        remaining.text = (float.Parse(remaining.text) - nodeAttr.numofturn).ToString();
        numofPN.text = (float.Parse(numofPN.text) + 1f).ToString();
        criteriaA.text = (float.Parse(criteriaA.text) + nodeAttr.attrA).ToString();
        criteriaB.text = (float.Parse(criteriaB.text) + nodeAttr.attrB).ToString();
        criteriaC.text = (float.Parse(criteriaC.text) + nodeAttr.attrC).ToString();
        criteriaD.text = (float.Parse(criteriaD.text) + nodeAttr.attrD).ToString();
        criteriaE.text = (float.Parse(criteriaE.text) + nodeAttr.attrE).ToString();
        criteriaF.text = (float.Parse(criteriaF.text) + nodeAttr.attrF).ToString();
        criteriaG.text = (float.Parse(criteriaG.text) + nodeAttr.attrG).ToString();
        criteriaH.text = (float.Parse(criteriaH.text) + nodeAttr.attrH).ToString();
        Debug.Log("dd");
        buyButton.GetComponent<Button>().interactable = false;
    }

  
}



