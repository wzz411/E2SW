using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CriteriaToggle : MonoBehaviour {
    public Toggle criteriaToggle;
    public Text criteriaText;
    public Text testedCriteriaText;

    public void ShowText()
    {
        if (criteriaToggle.isOn)
        {
            criteriaText.color = Color.black;
            testedCriteriaText.color = Color.black;
        }
        else
        {
            criteriaText.color = Color.clear;
            testedCriteriaText.color = Color.clear;
        }
    }
	
}
