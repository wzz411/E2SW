using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testing : MonoBehaviour {
    //update values on Main
    public Text numberOfTestPerformed, funds, labor, minEPG, maxEPG, numberOfNodesPurchased, apgFromCurrentTest, overAllPG, currentTurn, costOfCurrentTest;
    public InputField laborInputField;
    public Text testedCriA, testedCriB, testedCriC, testedCriD, testedCriE, testedCriF, testedCriG, testedCriH;
    public Text estCriA, estCriB, estCriC, estCriD, estCriE, estCriF, estCriG, estCriH;


    // for calculation
    private float drillPoints = UnityEngine.Random.Range(0,10) ; // TBD
    private float vectorSum, minEPG_cal, maxEPG_cal, pg, firstCal, secondCal, apgLower, apgUpper, numOfTests, numOfTurns, depth, numOfPeople;
    private float minVectorSum = 0;
    private float maxVectorSum = 40;

    void Start()
    {
        laborInputField = GetComponentInChildren<InputField>();
        Button testButton = GetComponent<Button>();
        testButton.onClick.AddListener(UpdatePG);
        
    }

    private void Update()
    {

    }

    private void UpdatePG()
    {
        numberOfTestPerformed.text = (float.Parse(numberOfTestPerformed.text) + 1f).ToString();

        if (laborInputField.text != "")
        {
            numOfPeople = float.Parse(laborInputField.text);
        }

        minEPG_cal = int.Parse(minEPG.text);
        maxEPG_cal = int.Parse(maxEPG.text);
        if (BuyNode.attrWeightedSum < 20)
        {
            minEPG_cal = 3;
            maxEPG_cal = 10;
			minEPG.text = minEPG_cal.ToString ();
			maxEPG.text = maxEPG_cal.ToString ();
        }else if (BuyNode.attrWeightedSum < 50)
        {
            minEPG_cal = 15;
            maxEPG_cal = 25;
			minEPG.text = minEPG_cal.ToString ();
			maxEPG.text = maxEPG_cal.ToString ();
        }else if (BuyNode.attrWeightedSum < 80)
        {
            minEPG_cal = 25;
            maxEPG_cal = 40;
			minEPG.text = minEPG_cal.ToString ();
			maxEPG.text = maxEPG_cal.ToString ();
        }
        else
        {
            minEPG_cal = 40;
            maxEPG_cal = 50;
			minEPG.text = minEPG_cal.ToString ();
			maxEPG.text = maxEPG_cal.ToString ();
        }
        vectorSum = drillPoints + float.Parse(numberOfNodesPurchased.text) + float.Parse(numberOfTestPerformed.text);
        

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
        
        numOfTests = (float)Math.Exp(float.Parse(numberOfTestPerformed.text));
        numOfTurns = (float)Math.Exp(((float.Parse(currentTurn.text))-(float.Parse(numberOfTestPerformed.text)))*0.2f);
		labor.text = (float.Parse(labor.text) - numOfPeople).ToString();
        costOfCurrentTest.text = (300 + (20 * numOfTests) + 30 * numOfTurns + 30 * numOfPeople).ToString();
        funds.text = (float.Parse(funds.text) - (300 + (20 * numOfTests) + 30 * numOfTurns + 30 * numOfPeople)).ToString("0.##");
        overAllPG.text = (float.Parse(overAllPG.text) + float.Parse(apgFromCurrentTest.text)).ToString();

        

        //update tested criteria
        testedCriA.text = (float.Parse(estCriA.text) - UnityEngine.Random.Range(0, 2)).ToString();
        testedCriB.text = (float.Parse(estCriB.text) - UnityEngine.Random.Range(0, 2)).ToString();
        testedCriC.text = (float.Parse(estCriC.text) - UnityEngine.Random.Range(0, 2)).ToString();
        testedCriD.text = (float.Parse(estCriD.text) - UnityEngine.Random.Range(0, 2)).ToString();
        testedCriE.text = (float.Parse(estCriE.text) - UnityEngine.Random.Range(0, 2)).ToString();
        testedCriF.text = (float.Parse(estCriF.text) - UnityEngine.Random.Range(0, 2)).ToString();
        testedCriG.text = (float.Parse(estCriG.text) - UnityEngine.Random.Range(0, 2)).ToString();
        testedCriH.text = (float.Parse(estCriH.text) - UnityEngine.Random.Range(0, 2)).ToString();
    }

}
