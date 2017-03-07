using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class inputScript : MonoBehaviour {
    public GameObject popup;
    InputField input;
    InputField.SubmitEvent se;
    public Text output;

    private void Start()
    {
        input = gameObject.GetComponent<InputField>();
        se = new InputField.SubmitEvent();
        se.AddListener(SubmitInput);
        input.onEndEdit = se;

    }

    private void SubmitInput(string arg0)
    {
        output.text = arg0;
        popup.SetActive(false);
        
    }


}
