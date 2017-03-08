﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testing : MonoBehaviour {
    //update values on Main
    public Text numberOfTestPerformed;
    public Text funds_cost;
    public Text labor;
    public Text minEPG;
    public Text maxEPG;
    public Text numberOfNodesPurchased;
    public Text apgFromCurrentTest;
    public Text overAllPG;
    public Text currentTurn;
    public Text costOfCurrentTest;
    public InputField laborInputField;


    // public GameObject displayInfoObject;
    // public DisplayInfo displayInfoScript;
    //public GameObject buyNodeObject;
    //  public BuyNode countVarScript;

    // for calculation
    private float vectorSum;
    private float drillPoints = UnityEngine.Random.Range(0,10) ; // TBD
    private int minEPG_cal;
    private int maxEPG_cal;
    private float pg;
    private float firstCal;
    private float secondCal;
    private float minVectorSum = 0;
    private float maxVectorSum = 40;
    private float apgLower;
    private float apgUpper;

    private float numOfTests;
    private float numOfTurns;
    private int depth;
    private float numOfPeople;


   /* 
    private void Start()
    {
        displayInfoScript = displayInfoObject.GetComponent<DisplayInfo>();
        countVarScript = buyNodeObject.GetComponent<BuyNode>();
    }
    */

    public void UpdatePG()
    {
        minEPG_cal = int.Parse(minEPG.text);
        maxEPG_cal = int.Parse(maxEPG.text);
        if (DisplayInfo.attrWeightedSum < 10)
        {
            minEPG_cal = 3;
            maxEPG_cal = 10;
        }else if (DisplayInfo.attrWeightedSum <25)
        {
            minEPG_cal = 15;
            maxEPG_cal = 25;
        }else if (DisplayInfo.attrWeightedSum < 40)
        {
            minEPG_cal = 25;
            maxEPG_cal = 40;
        }
        else
        {
            minEPG_cal = 40;
            maxEPG_cal = 50;
        }
        vectorSum = drillPoints + int.Parse(numberOfNodesPurchased.text) + int.Parse(numberOfTestPerformed.text);
        

        pg = ((minEPG_cal + (maxEPG_cal - minEPG_cal) * UnityEngine.Random.Range(0.0f, 1.0f))+vectorSum)/2;
        // first cal
        if (int.Parse(numberOfTestPerformed.text) > 0)
        {
            if (vectorSum < minVectorSum +6)
            {
                firstCal = (maxEPG_cal - minEPG_cal) * UnityEngine.Random.Range(0.0f, 1.0f) + UnityEngine.Random.Range(0.03f, 0.05f);
            }
            firstCal = pg;
        }
        else
        {
            firstCal = 0;
        }
        //second cal
        if (int.Parse(numberOfTestPerformed.text)>0)
        {
            if (vectorSum >= maxVectorSum-5)
            {
                secondCal = maxEPG_cal - UnityEngine.Random.Range(0.03f, 0.05f) * 10;
            }
            secondCal = firstCal;
        }
        else
        {
            secondCal = 0;
        }
        //apg lower bound
        if (int.Parse(numberOfTestPerformed.text) > 0)
        {
            if (secondCal<minEPG_cal)
            {
                apgLower = minEPG_cal + (secondCal*0.1f);
            }
            apgLower = secondCal;
        }
        else
        {
            apgLower = 0;
        }
        //apg upper bound
        if (int.Parse(numberOfTestPerformed.text) > 0)
        {
            if (apgLower > maxEPG_cal)
            {
                apgUpper = maxEPG_cal - (apgLower*0.03f);
            }
            apgUpper = apgLower;
        }else
        {
            apgUpper = 0;
        }
        // apg from current test
        apgFromCurrentTest.text = apgUpper.ToString();



        //cost of testing
        numOfTests = (float)Math.Exp(int.Parse(numberOfTestPerformed.text));
        numOfTurns = (float)Math.Exp(((int.Parse(currentTurn.text))-(int.Parse(numberOfTestPerformed.text)))*0.2f);
        depth = BuyNode.count;
        numOfPeople = int.Parse(laborInputField.text);
        labor.text = (int.Parse(labor.text) - int.Parse(laborInputField.text)).ToString();
        costOfCurrentTest.text = (300 + (20 * numOfTests) + 30 * numOfTurns + 30 * numOfPeople).ToString();
        funds_cost.text = (float.Parse(funds_cost.text) - (300 + (20 * numOfTests) + 30 * numOfTurns + 30 * numOfPeople)).ToString();
        overAllPG.text = (float.Parse(overAllPG.text) + float.Parse(apgFromCurrentTest.text)).ToString();

    }

}