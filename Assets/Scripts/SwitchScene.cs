using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public string sceneName;

    public void switchScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void tap()
    {
        Debug.Log("TEST");
    }
}
