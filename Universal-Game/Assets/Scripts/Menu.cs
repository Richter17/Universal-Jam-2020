using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public int GameSceneID;

    public void OnPlayClick()
    {
        ScenesManager.LoadScene(GameSceneID);
    }
}
