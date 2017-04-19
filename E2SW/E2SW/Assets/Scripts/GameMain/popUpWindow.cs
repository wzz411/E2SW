using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class popUpWindow : MonoBehaviour {

    public GameObject popUp;

    public void Show()
    {
        Vector3 currentPos = gameObject.transform.position;
        currentPos.x = 400;
        currentPos.y = 400;
        transform.position = currentPos;
    }

    public void Hide()
    {
        Vector3 currentPos = gameObject.transform.position;
        
        currentPos.x = -5000;
        currentPos.y = -5000;
        transform.position = currentPos;
    }
		
	
}
