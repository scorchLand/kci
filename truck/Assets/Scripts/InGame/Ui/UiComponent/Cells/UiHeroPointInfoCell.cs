using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiHeroPointInfoCell : UiComponent
{
    public GameObject goGauge;
    //public TextMeshProUGUI tmpCount;
    public TextMeshProUGUI tmpValue;

    private void Update()
    {
        goGauge.transform.localScale = new Vector3(InGameController.Instance.stageController.ScoreList[0].Value, 1, 1);
        //tmpCount.text = $"{InGameController.Instance.stageController.ScoreList[0].Count}";
        tmpValue.text = $"{(int)(InGameController.Instance.stageController.ScoreList[0].Value * 100)}%";
    }
}
