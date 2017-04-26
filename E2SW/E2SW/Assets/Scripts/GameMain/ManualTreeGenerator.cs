using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ManualTreeGenerator : MonoBehaviour {

    // Create connecting lines between nodes
    private LineRenderer lr;
    private Vector3 initialPos = new Vector3(0, 0, 0);
    private Vector3 currentPos = new Vector3(0, 0, 0);
    private bool ifOnGUI = false;
    private int index = 1; // even #, including 0, for parent node; odd # for child node

    // 
    private GameObject node;
    private static int count = 1;


    void Start () {
        // initiate line renderer -- conncecting lines
        lr = GetComponent<LineRenderer>();
        Button createButton = GetComponent<Button>();
        createButton.onClick.AddListener(TaskOnClick);
        initialPos = transform.parent.position;
        initialPos.z = 250;
        
        // initiate all line points 
        for (int i = 0; i < 60; i++)
        {
            lr.SetPosition(i, initialPos);
        }

        // initiate new node
        node = Resources.Load("Prefabs/NewNode", typeof(GameObject)) as GameObject;


    }

    

    // if create button is clicked
    private void TaskOnClick()
    {
        ifOnGUI = true;
    }

    private void OnGUI()
    {
        if (ifOnGUI)
        {
            // create line 
            currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPos.z = 250;
            lr.SetPosition(2 * index - 1, currentPos);
            // if mouse clicked, generate the node
            if (Event.current.isMouse)
            {
                ifOnGUI = false;
                if (NodeAttributes.colliding)
                {
                    Debug.Log("collide with existing node");
                }
                else
                {
                    GameObject newNode = Instantiate(node, currentPos, Quaternion.identity) as GameObject;
                    newNode.name = "node" + count;
                    // re-name new node
                    Button btn = newNode.gameObject.GetComponentInChildren<Button>();
                    btn.GetComponentInChildren<Text>().text = newNode.name;
                    // assign new node to its parent
                    newNode.transform.SetParent(transform.parent.Find("ChildrenNode"));
                    count++;
                }
 
                index++;

                // Debug.Log(newNode.name + " " + newNode.transform.position);
            }
        }
    }


}
