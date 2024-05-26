using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiScore : UiComponent
{
    public TextMeshProUGUI tmpScore;
    public long score = 0;
    private void Awake()
    {
        tmpScore.text = "0";
        ObjectiveEvent<long>.AddObjectiveAction(EObjective.TRUCK_CRASH, UpdateUi);
    }
    private void OnDestroy()
    {
        ObjectiveEvent<long>.RemoveObjectiveAction(EObjective.TRUCK_CRASH, UpdateUi);
    }
    private void UpdateUi(EventData<long> data)
    {
        score += data.data;
        tmpScore.text = score.ToString();
    }
}
