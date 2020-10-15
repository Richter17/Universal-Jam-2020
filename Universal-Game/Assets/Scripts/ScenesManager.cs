using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager
{
    public static void LoadScene(int id)
    {
        if (id >= 0 && SceneManager.sceneCountInBuildSettings < id)
        {
            Debug.Log("Couldn't find scene id");
            return;
        }
        if (SceneManager.GetActiveScene().buildIndex == id)
        {
            Debug.Log("The same scene ID");
            return;
        }
        SceneManager.LoadScene(id);
    }

    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
