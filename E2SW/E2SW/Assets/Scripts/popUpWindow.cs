using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class popUpWindow : MonoBehaviour {

    public GameObject popUp;
    public Text actionLog;

    public void recordlog(string log)
    {
        actionLog.text += (log + "; ");
        popUp.SetActive(true);
    }

    public void show()
    {
        popUp.SetActive(true);
    }

    public void hide()
    {
        popUp.SetActive(false);
    }
		
	
}
