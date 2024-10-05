using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EScene
{
    Loding,
    Lobby,
    Main
}
public static class SceneController
{ 
    public static void SceneChange(EScene scene)
    {
        SceneManager.LoadSceneAsync((int)scene);
    }

}
