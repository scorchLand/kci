using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiEntryStartButton : UiComponent
{
    public void OnClick()
    {
        SceneController.SceneChange(EScene.Lobby);
    }
}
