using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditMode : MonoBehaviour {

    public Button editButton;
    private GameObject editPanel;
    private Vector3 currentPos = new Vector3(0, 0, 0);

	void Start () {
        editButton = GetComponent<Button>();
        editButton.onClick.AddListener(TaskOnClick);
        editPanel = Resources.Load("Prefabs/EditPanel", typeof(GameObject)) as GameObject;
    }

    private void TaskOnClick()
    {
        // generate edit panel
        currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPos.x += 100;
        currentPos.y += 20;
        currentPos.z = 250;
        GameObject newEditPanel = Instantiate(editPanel, currentPos, Quaternion.identity) as GameObject;
        newEditPanel.name = "EditPanel";
        newEditPanel.transform.SetParent(transform.parent.Find("Canvas"));
        GameObject[] editBtns = GameObject.FindGameObjectsWithTag("Edit Button");
        foreach (GameObject editBtn in editBtns)
        {
            editBtn.GetComponent<Button>().enabled = false;
        }
    }
}
