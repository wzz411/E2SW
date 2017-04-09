using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditModeConfirmButton_Main : MonoBehaviour {
    public InputField funds_input, labor_input, current_input, remaining_input, overallPG_input, numofPN_input, numofTP_input;
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
        Debug.Log("here");
        if (funds_input.text != "")
        {
            funds.text = funds_input.text;
            Debug.Log("here2");
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

        Destroy(transform.parent.gameObject);
        GameObject[] editBtns = GameObject.FindGameObjectsWithTag("Edit Button");
        foreach (GameObject editBtn in editBtns)
        {
            editBtn.GetComponent<Button>().enabled = true;
        }
    }

}
