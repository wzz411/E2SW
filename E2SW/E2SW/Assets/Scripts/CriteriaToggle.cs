using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CriteriaToggle : MonoBehaviour {
    public Toggle criteriaToggle;
    public Text criteriaText;
    public Text testedCriteriaText;
	public int attrIDon=0;
	public int attrIDoff=0;

    public void ShowText()
    {
        if (criteriaToggle.isOn)
        {
			switch (attrIDon) {
			case 1:
				Debug.Log (attrIDon + " A is toggled");
				DisplayInfo.attrIndex = 1;
				DisplayInfo.ifUpdate = true;
				break;
			case 2:
				DisplayInfo.attrIndex = 2;
				DisplayInfo.ifUpdate = true;
				break;
			case 3:
				DisplayInfo.attrIndex = 3;
				DisplayInfo.ifUpdate = true;
				break;
			case 4:
				DisplayInfo.attrIndex = 4;
				DisplayInfo.ifUpdate = true;
				break;

			}

            criteriaText.color = Color.black;
            testedCriteriaText.color = Color.black;
        }
        else
        {
			switch(attrIDoff){
			case 11:
				DisplayInfo.attrIndex = 11;
				DisplayInfo.ifUpdate = true;
				break;
			case 22:
				DisplayInfo.attrIndex = 22;
				DisplayInfo.ifUpdate = true;
				break;
			case 33:
				DisplayInfo.attrIndex = 33;
				DisplayInfo.ifUpdate = true;
				break;
			case 44:
				DisplayInfo.attrIndex = 44;
				DisplayInfo.ifUpdate = true;
				break;
			}
            criteriaText.color = Color.clear;
            testedCriteriaText.color = Color.clear;
        }
    }
	
}
