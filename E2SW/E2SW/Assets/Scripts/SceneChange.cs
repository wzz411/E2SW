using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ChangingScene(string sceneName)
    {
        //SceneManager.LoadScene;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

}