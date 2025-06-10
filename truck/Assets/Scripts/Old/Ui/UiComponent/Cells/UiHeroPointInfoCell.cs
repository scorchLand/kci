using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiHeroPointInfoCell : UiComponent
{
    public Slider goGauge;
    //public TextMeshProUGUI tmpCount;
    public TextMeshProUGUI tmpValue;

    private void Update()
    {
        goGauge.value = InGameController.Instance.stageController.ScoreList[0].Value;
        //tmpCount.text = $"{InGameController.Instance.stageController.ScoreList[0].Count}";
        tmpValue.text = $"{(int)(InGameController.Instance.stageController.ScoreList[0].Value * 100)}%";
    }
}
