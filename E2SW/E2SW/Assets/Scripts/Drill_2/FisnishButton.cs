using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FisnishButton : MonoBehaviour {

    void OnMouseDown()
    {

        SceneManager.LoadScene("sample01");
        GameObject.FindWithTag("Main Game Scene").GetComponent<Canvas>().scaleFactor = 1;

    }
}
