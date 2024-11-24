using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEntryButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneController.SceneChange(EScene.Main);
    }
}
