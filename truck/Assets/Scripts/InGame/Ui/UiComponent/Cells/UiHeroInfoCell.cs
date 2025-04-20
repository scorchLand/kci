using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHeroInfoCell : UiComponent
{
    public UiHeroInfo Parant { get; private set; }

    public void Initialize(UiHeroInfo parant)
    {
        Parant = parant;
    }
    public void OnClick()
    {
        if (InGameController.Instance.stageController.StageNumber % 2 == 0)
        {
            Debug.LogError($"적 웨이브 시에만 타워 출력 가능");
            return;
        }
        if(InGameController.Instance.stageController.ScoreList[0].Count >= 1)
        {
            InGameController.Instance.stageController.ScoreList[0].CreateTower();
            Parant.RemoveList(this);
        }
    }
}
