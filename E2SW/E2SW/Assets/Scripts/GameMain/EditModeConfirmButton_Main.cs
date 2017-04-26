using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditModeConfirmButton_Main : MonoBehaviour {
    public InputField funds_input, labor_input, current_input, remaining_input, overallPG_input, numofPN_input, numofTP_input, coef_funds_input, 
        coef_labor_input, coef_testCost_input, coef_criteriaA_input, coef_criteriaB_input, coef_criteriaC_input, coef_criteriaD_input, coef_criteriaE_input,
        coef_criteriaF_input, coef_criteriaG_input, coef_criteriaH_input;
    public Text funds, labor, current, remaining, overallPG, numofPN, numofTP;
    public Button confirmButton;
    // Use this for initialization
    void Start () {
        confirmButton = GetComponent<Button>();
        confirmButton.onClick.AddListener(TaskOnClick);

        funds = GameObject.Find("fundsValue").GetComponent<Text>();
        labor = GameObject.Find("laborValue").GetComponent<Text>();
        current = GameObject.Find("currentTurnValue").GetComponent<Text>();
        remaining = GameObject.Find("turnsRemainingValue").GetComponent<Text>();
        overallPG = GameObject.Find("overallPGValue").GetComponent<Text>();
        numofPN = GameObject.Find("numofPNValue").GetComponent<Text>();
        numofTP = GameObject.Find("numofTPValue").GetComponent<Text>();
    }

    
    // Update is called once per frame
    void Update () {
		
	}

    private void TaskOnClick()
    {
        if (funds_input.text != "")
        {
            funds.text = funds_input.text;
        }
        if (labor_input.text != "")
        {
            labor.text = labor_input.text;
        }
        if (current_input.text != "")
        {
            current.text = current_input.text;
        }
        if(remaining_input.text != "")
        {
            remaining.text = remaining_input.text;
        }
        if(overallPG_input.text != "")
        {
            overallPG.text = overallPG_input.text;
        }
        if(numofPN_input.text != "")
        {
            numofPN.text = numofPN_input.text;
        }
        if(numofTP_input.text != "")
        {
            numofTP.text = numofTP_input.text;
        }
        if(coef_funds_input.text != "")
        {
            GodMode.coef_funds = float.Parse(coef_funds_input.text);
        }
        if (coef_labor_input.text != "")
        {
            GodMode.coef_labor = float.Parse(coef_labor_input.text);
        }
        if (coef_testCost_input.text != "")
        {
            GodMode.coef_testCost = float.Parse(coef_testCost_input.text);
        }
        if (coef_criteriaA_input.text != "")
        {
            GodMode.coef_criteriaA = float.Parse(coef_criteriaA_input.text);
        }
        if (coef_criteriaB_input.text != "")
        {
            GodMode.coef_criteriaB = float.Parse(coef_criteriaB_input.text);
        }
        if (coef_criteriaC_input.text != "")
        {
            GodMode.coef_criteriaC = float.Parse(coef_criteriaC_input.text);
        }
        if (coef_criteriaD_input.text != "")
        {
            GodMode.coef_criteriaD = float.Parse(coef_criteriaD_input.text);
        }
        if (coef_criteriaE_input.text != "")
        {
            GodMode.coef_criteriaE = float.Parse(coef_criteriaE_input.text);
        }
        if (coef_criteriaF_input.text != "")
        {
            GodMode.coef_criteriaF = float.Parse(coef_criteriaF_input.text);
        }
        if (coef_criteriaG_input.text != "")
        {
            GodMode.coef_criteriaG = float.Parse(coef_criteriaG_input.text);
        }



        Destroy(transform.parent.gameObject);
        GameObject[] editBtns = GameObject.FindGameObjectsWithTag("Edit Button");
        foreach (GameObject editBtn in editBtns)
        {
            editBtn.GetComponent<Button>().enabled = true;
        }
    }

}
