using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class testInputScript : MonoBehaviour{

    InputField input;
    InputField.SubmitEvent se;
    public Text output;
    private int counter;

    private void Start()
    {
        input = gameObject.GetComponent<InputField>();
        se = new InputField.SubmitEvent();
        se.AddListener(SubmitInput);
        input.onEndEdit = se;

    }

    private void SubmitInput(string arg0)
    {
        counter += 1;
        output.text = counter.ToString();

    }


}
