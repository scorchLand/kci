using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHeroInfoCell : UiComponent
{
    public void OnClick()
    {
        if(InGameController.Instance.stageController.ScoreList[0].Count >= 1)
        {
            InGameController.Instance.stageController.ScoreList[0].CreateTower();
        }
    }
}
