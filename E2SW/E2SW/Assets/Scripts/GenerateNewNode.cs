using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GenerateNewNode : MonoBehaviour {


    public Transform button;
    public GameObject node;
    public InputField laborInputField;
    //public BuyNode buyNodeScript;
    public bool ifMastermind;

    private GameObject newNode;


    private void Start()
    {
		ifMastermind = false;
        //ifMastermind = Random.Range(0, 100)/50 >= 1;
        Debug.Log("mastermind "+ifMastermind);
    }



    public void Generate() {

        int numberOfNewNode = 1;
        
        if (int.Parse(laborInputField.text) >= 2)
            numberOfNewNode += 1;
        if (int.Parse(laborInputField.text) >= 5)
            numberOfNewNode += 1;

        //buyNodeScript.exploreLabor = int.Parse(laborInputField.text);
        //buyNodeScript.UpdateInfo();
       // Debug.Log("Generated!");

        while (numberOfNewNode > 0) {
            newNode = Instantiate(node, new Vector3(transform.position.x + 150, transform.position.y - (numberOfNewNode - 1) * 150, transform.position.z), Quaternion.identity) as GameObject;
            newNode.AddComponent<BoxCollider2D>();
            numberOfNewNode--;
        }

        // enter mini game
        if (ifMastermind)
        {
            SceneManager.LoadScene("mastermind");
        }

        if (button.GetComponent<Button>().IsInteractable() == true) {


            button.GetComponent<Button>().interactable = false;
            button.GetComponent<Renderer>().material.color = Color.gray;

        } else {

            button.GetComponent<Button>().interactable = true;
            button.GetComponent<Renderer>().material.color = Color.white;

            
        }
    }


}
