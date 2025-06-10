using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiGameStartButton : UiComponent
{
    public void OnClick()
    {
        SceneController.SceneChange(EScene.Main);
    }
}
