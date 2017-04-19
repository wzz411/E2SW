using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CriteriaToggle : MonoBehaviour {
    public Toggle criteriaToggle;
    public Text criteriaText, testedCriteriaText;
    public int attrIDon, attrIDoff;

    public void ShowText()
    {

        if (criteriaToggle.isOn)
        {
            switch (attrIDon)
            {
                case 1:
                    NodeAttributes.attrIndex = 1;
                    UpdateEachNode();
                    break;
                case 2:
                    NodeAttributes.attrIndex = 2;
                    UpdateEachNode();
                    break;
                case 3:
                    NodeAttributes.attrIndex = 3;
                    UpdateEachNode();
                    break;
                case 4:
                    NodeAttributes.attrIndex = 4;
                    UpdateEachNode();
                    break;
                case 5:
                    NodeAttributes.attrIndex = 5;
                    UpdateEachNode();
                    break;
                case 6:
                    NodeAttributes.attrIndex = 6;
                    UpdateEachNode();
                    break;
                case 7:
                    NodeAttributes.attrIndex = 7;
                    UpdateEachNode();
                    break;
                case 8:
                    NodeAttributes.attrIndex = 8;
                    UpdateEachNode();
                    break;


            }

            criteriaText.color = Color.black;
            testedCriteriaText.color = Color.black;
        }
        else
        {
            switch (attrIDoff)
            {
                case 11:
                    NodeAttributes.attrIndex = 11;
                    UpdateEachNode();
                    break;
                case 22:
                    NodeAttributes.attrIndex = 22;
                    UpdateEachNode();
                    break;
                case 33:
                    NodeAttributes.attrIndex = 33;
                    UpdateEachNode();
                    break;
                case 44:
                    NodeAttributes.attrIndex = 44;
                    UpdateEachNode();
                    break;
                case 55:
                    NodeAttributes.attrIndex = 55;
                    UpdateEachNode();
                    break;
                case 66:
                    NodeAttributes.attrIndex = 66;
                    UpdateEachNode();
                    break;
                case 77:
                    NodeAttributes.attrIndex = 77;
                    UpdateEachNode();
                    break;
                case 88:
                    NodeAttributes.attrIndex = 88;
                    UpdateEachNode();
                    break;

            }
            criteriaText.color = Color.clear;
            testedCriteriaText.color = Color.clear;
        }
    }

    private void UpdateEachNode()
    {
        GameObject[] nodeInfos = GameObject.FindGameObjectsWithTag("Node Info and Buy Btn");
        foreach (GameObject nodeInfo in nodeInfos)
        {
            NodeAttributes temp = nodeInfo.GetComponent<NodeAttributes>();
            temp.UpdateDisplayInfo();
        }
    }



}
