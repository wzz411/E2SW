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
        funds.text = (float.Parse(funds.text) - nodeAttr.funds * GodMode.coef_funds).ToString();
        labor.text = (float.Parse(labor.text) - nodeAttr.labor * GodMode.coef_labor).ToString();
        current.text = (float.Parse(current.text) + nodeAttr.numofturn).ToString();
        remaining.text = (float.Parse(remaining.text) - nodeAttr.numofturn).ToString();
        numofPN.text = (float.Parse(numofPN.text) + 1f).ToString();
        criteriaA.text = (float.Parse(criteriaA.text) + nodeAttr.attrA * GodMode.coef_criteriaA).ToString();
        criteriaB.text = (float.Parse(criteriaB.text) + nodeAttr.attrB * GodMode.coef_criteriaB).ToString();
        criteriaC.text = (float.Parse(criteriaC.text) + nodeAttr.attrC * GodMode.coef_criteriaC).ToString();
        criteriaD.text = (float.Parse(criteriaD.text) + nodeAttr.attrD * GodMode.coef_criteriaD).ToString();
        criteriaE.text = (float.Parse(criteriaE.text) + nodeAttr.attrE * GodMode.coef_criteriaE).ToString();
        criteriaF.text = (float.Parse(criteriaF.text) + nodeAttr.attrF * GodMode.coef_criteriaF).ToString();
        criteriaG.text = (float.Parse(criteriaG.text) + nodeAttr.attrG * GodMode.coef_criteriaG).ToString();
        criteriaH.text = (float.Parse(criteriaH.text) + nodeAttr.attrH * GodMode.coef_criteriaH).ToString();
        buyButton.GetComponent<Button>().interactable = false;

        attrWeightedSum += nodeAttr.attrA + nodeAttr.attrB + nodeAttr.attrC + nodeAttr.attrD + nodeAttr.attrE + nodeAttr.attrF + nodeAttr.attrG + nodeAttr.attrH;

        //TODO: work on depth of the tree

        // decide whether minigames
        if (nodeAttr.ifMiniGame)
        {
            GameObject.FindWithTag("Mini Game").transform.position = new Vector3(400, 400, 250);
        }
        if (nodeAttr.ifDrill_1)
        {
            
            SceneManager.LoadScene("drill_1");
            GameObject.FindWithTag("Main Game Scene").GetComponent<Canvas>().scaleFactor = 50;
        }
        if (nodeAttr.ifDrill_2)
        {

            SceneManager.LoadScene("drill_2");
            GameObject.FindWithTag("Main Game Scene").GetComponent<Canvas>().scaleFactor = 50;
        }


        // move children, as well as its line renderer
        // 1) move LineRenderer
        for (int j = 0; j < 60; j++)
        {
            Vector3 lrMoveFwd = gameObject.transform.parent.parent.GetChild(1).GetComponent<LineRenderer>().GetPosition(j); // this is to find CreateButton in each Node Debug.log(gameObject.transform.parent.parent.GetChild(1));
            lrMoveFwd.z = 250;
            gameObject.transform.parent.parent.GetChild(1).GetComponent<LineRenderer>().SetPosition(j, lrMoveFwd);  

        }
        // 2) move Nodes
        for (int m = 0; m < gameObject.transform.parent.parent.GetChild(3).childCount; m++)
        {
            Vector3 nodeMoveFwd = gameObject.transform.parent.parent.GetChild(3).GetChild(m).transform.position;
            nodeMoveFwd.z = 250;
            gameObject.transform.parent.parent.GetChild(3).GetChild(m).transform.position = nodeMoveFwd;
            //gameObject.transform.parent.parent.GetChild(3).GetChild(m).transform.localScale = new Vector3(1f, 1f, 1f);

            Vector3 nodeChildMoveBwk = gameObject.transform.parent.parent.GetChild(3).GetChild(m).GetChild(3).position;
            nodeChildMoveBwk.z = 2000;
            gameObject.transform.parent.parent.GetChild(3).GetChild(m).GetChild(3).position = nodeChildMoveBwk;

            // Debug.Log("child count is :" + gameObject.transform.parent.parent.GetChild(3).childCount);
            // Debug.Log(gameObject.transform.parent.parent.GetChild(3).GetChild(m));
        }


        
    }

  
}



