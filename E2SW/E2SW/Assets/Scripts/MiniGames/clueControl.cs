using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class clueControl : MonoBehaviour {

    [SerializeField]

    public InputField mainInputField1;
    public InputField mainInputField2;
   // public Text name_text2;
    private string results="";
    public static string[]array1 = {"A","B","C","D","E","F","G","H"};//input test check
	float[]array2 = {27F, 0.0F, 30F, 0.00F, 13F,30F,0.0F,0.0F};
    public static string choice1;
    public static string choice2;
    int count = 0;
    public Text textCounter;
    public Text textClue;
    public void myFunc()
    {

        choice1 = mainInputField1.text;
        choice2 = mainInputField2.text;
        //Debug.Log(choice1);
        //Debug.Log(choice2);
        int index1 = System.Array.IndexOf(array1, choice1);
        int index2 = System.Array.IndexOf(array1, choice2);  
        float c1 = array2[index1];
        float c2 = array2[index2];
      Debug.Log(c1 +", " + c2);
        //Debug.Log(clue(c1,c2));
        //Debug.Log(criteria1Clue + "\n" + criteria2Clue + "\n" + criteria3Clue + "\n" + criteria4Clue);
        results =choice1 +" is "+ clue(c1, c2) + " than " + choice2+"\n"+ results;
        count = count +1;
        textCounter.text = "Labor Used: " + count.ToString();
        textClue.text = results;
        Debug.Log(results +"  " +count);
       // name_text2.text = "Clues:\n" + results;
    }

    public void myFunc2() {
        Debug.Log(mainInputField1.text);
        Debug.Log("CAT");
    }
    private string clue(float number1, float number2)
    {
        string result = "";
        float treshholdU = .10F;
        float tresholdL = .05F;
        number1 = number1 + 0.001F;
        number2 = number2 + 0.001F;
        if (Mathf.Abs(number1 / number2 - 1) < tresholdL)
        {
            result = "~~";

        }
        else
        if (Mathf.Abs(number1 / number2 - 1) > treshholdU)
        {
            if (number1 > number2)
            {
                result = ">>";

            }

            else
                result = "<<";

        }
        else

        {
            if (number1 > number2)
            {
                result = ">";

            }
            else
                result = "<";

        }


        return result;
    }

}