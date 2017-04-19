using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputTextOut : MonoBehaviour {
    private int total;
    // Use this for initialization
    public void Start()
	{


	}


	// Update is called once per frame
	void Update () {

    }

    public void getInput(string guess)
    {


        if (gameObject.tag == "criteria1")
        {
          //  clueControl.choice1 = guess;
        }

        if (gameObject.tag == "criteria2")
        {
           // clueControl.choice2 = guess;
        }

    }



}
