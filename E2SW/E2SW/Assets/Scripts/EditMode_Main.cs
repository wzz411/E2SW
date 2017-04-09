using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditMode_Main : MonoBehaviour {

    public Button editButton;
    private GameObject editPanel;
    private Vector3 currentPos = new Vector3(0, 0, 0);

    void Start()
    {
        editButton = GetComponent<Button>();
        editButton.onClick.AddListener(TaskOnClick);
        editPanel = Resources.Load("Prefabs/EditPanelMain", typeof(GameObject)) as GameObject;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void TaskOnClick()
    {
        // generate edit panel
        currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPos.x += 100;
        currentPos.y += 20;
        currentPos.z = 250;
        GameObject newEditPanel = Instantiate(editPanel, currentPos, Quaternion.identity) as GameObject;
        newEditPanel.name = "EditPanelMain";
        newEditPanel.transform.SetParent(transform.root);
        GameObject[] editBtns = GameObject.FindGameObjectsWithTag("Edit Button");
        foreach (GameObject editBtn in editBtns)
        {
            editBtn.GetComponent<Button>().enabled = false;
        }
    }
}
