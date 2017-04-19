using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public void ChangingScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        GameObject.FindWithTag("Main Game Scene").GetComponent<Canvas>().scaleFactor = 1;
    }
}
