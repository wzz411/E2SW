using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditModeConfirmButton : MonoBehaviour {

    public InputField funds, labor, numofturn, attrA, attrB, attrC, attrD, attrE, attrF, attrG, attrH, minigame, drill_1, drill_2;
    public Button confirmButton;
    // Use this for initialization
    void Start () {
        confirmButton = GetComponent<Button>();
        confirmButton.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        NodeAttributes temp = gameObject.GetComponentInParent<NodeAttributes>();
        if(funds.text != "")
        {
            temp.funds = float.Parse(funds.text);
        }
        if (labor.text != "")
        {
            temp.labor = float.Parse(labor.text);
        }
        if(numofturn.text != "")
        {
            temp.numofturn = float.Parse(numofturn.text);
        }
        if(attrA.text != "")
        {
            temp.attrA = float.Parse(attrA.text);
        }
        if(attrB.text != "")
        {
            temp.attrB = float.Parse(attrB.text);
        }
        if(attrC.text != "")
        {
            temp.attrC = float.Parse(attrC.text);
        }
        if(attrD.text != "")
        {
            temp.attrD = float.Parse(attrD.text);
        }
        if (attrE.text != "")
        {
            temp.attrE = float.Parse(attrE.text);
        }
        if(attrF.text != "")
        {
            temp.attrF = float.Parse(attrF.text);
        }
        if(attrG.text != "")
        {
            temp.attrG = float.Parse(attrG.text);
        }
        if(attrH.text != "")
        {
            temp.attrH = float.Parse(attrH.text);
        }
        if (minigame.text != "")
        {
            temp.ifMiniGame = (int.Parse(minigame.text) == 1);
        }
        if (drill_1.text != "")
        {
            temp.ifDrill_1 = (int.Parse(drill_1.text) == 1);
        }
        if (drill_2.text != "")
        {
            temp.ifDrill_2 = (int.Parse(drill_2.text) == 1);
        }

        temp.UpdateDisplayInfo();
        Destroy(transform.parent.gameObject);
        GameObject[] editBtns = GameObject.FindGameObjectsWithTag("Edit Button");
        foreach(GameObject editBtn in editBtns)
        {
            editBtn.GetComponent<Button>().enabled = true;
        }
        
        // todo in EditMode, change editButton.enabled to be true;

    }

}
