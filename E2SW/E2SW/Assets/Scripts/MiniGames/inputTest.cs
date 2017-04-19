using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class inputTest : MonoBehaviour {
    public InputField mainInputField1;
    public InputField mainInputField2;

    // Use this for initialization
    public void Start()
    {
        // Sets the MyValidate method to invoke after the input field's default input validation invoke (default validation happens every time a character is entered into the text field.)
        mainInputField1.onValidateInput += delegate (string input, int charIndex, char addedChar) 
        { return MyValidate(addedChar);
        };

        mainInputField2.onValidateInput += delegate (string input, int charIndex, char addedChar)
        {
            return MyValidate(addedChar);
        };

      
    }

    private char MyValidate(char charToValidate)
    {
		bool inputOkay = false;

        string charToValidateX = charToValidate.ToString();
        charToValidateX = charToValidateX.ToUpper();
        int res=System.Array.IndexOf(clueControl.array1, charToValidateX);
        Debug.Log(res);

        if (res != -1) {
            charToValidate = char.ToUpper(charToValidate);
            inputOkay = true;
        }
       

        //Checks if valid
        if (inputOkay == false)
        {
            // ... if it is change it to an empty character.
            charToValidate = '\0';
        }
        return charToValidate;
    }
}
