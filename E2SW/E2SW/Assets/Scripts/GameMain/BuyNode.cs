using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BuyNode : MonoBehaviour
{
    public Button buyButton;
    public static int pn; // pn = numofPN = number of purchased nodes
    public static float attrWeightedSum;

    public Text funds, labor, current, remaining, criteriaA, criteriaB, criteriaC, criteriaD, criteriaE, criteriaF, criteriaG, criteriaH, numofPN;

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
        criteriaA = GameObject.FindWithTag("EstCriteriaA").GetComponent<Text>();
        criteriaB = GameObject.FindWithTag("EstCriteriaB").GetComponent<Text>();
        criteriaC = GameObject.FindWithTag("EstCriteriaC").GetComponent<Text>();
        criteriaD = GameObject.FindWithTag("EstCriteriaD").GetComponent<Text>();
        criteriaE = GameObject.FindWithTag("EstCriteriaE").GetComponent<Text>();
        criteriaF = GameObject.FindWithTag("EstCriteriaF").GetComponent<Text>();
        criteriaG = GameObject.FindWithTag("EstCriteriaG").GetComponent<Text>();
        criteriaH = GameObject.FindWithTag("EstCriteriaH").GetComponent<Text>();


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
        buyButton.GetComponent<Button>().interactable = false;

        attrWeightedSum += nodeAttr.attrA + nodeAttr.attrB + nodeAttr.attrC + nodeAttr.attrD + nodeAttr.attrE + nodeAttr.attrF + nodeAttr.attrG + nodeAttr.attrH;

        //TODO: work on depth of the tree

        if (nodeAttr.ifMiniGame)
        {
            GameObject.FindWithTag("Mini Game").transform.position = new Vector3(400, 400, 250);
        }
        if (nodeAttr.ifDrill)
        {
            
            SceneManager.LoadScene("drill_1");
            GameObject.FindWithTag("Main Game Scene").GetComponent<Canvas>().scaleFactor = 50;
        }

    }

  
}



