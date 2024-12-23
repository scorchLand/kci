using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiTruckDistance : UiComponent
{
    public TextMeshProUGUI tmpDistance;
    public float distance;
    private void Awake()
    {
        ObjectiveEvent<float>.AddObjectiveAction(EObjective.TRUCK_DISTANCE_UPDATE, UpdateUi);
    }
    private void OnDestroy()
    {
        ObjectiveEvent<float>.RemoveObjectiveAction(EObjective.TRUCK_DISTANCE_UPDATE, UpdateUi);
    }
    private void UpdateUi(EventData<float> data)
    {
        distance += Time.deltaTime * data.data;
        tmpDistance.text = $"{(long)distance}M";
    }
}
