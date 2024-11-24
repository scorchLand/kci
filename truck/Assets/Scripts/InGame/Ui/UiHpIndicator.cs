using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiHpIndicator : MonoBehaviour
{
    public Slider hp;
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
        hp.value = Truck.TestPlayer.CurrentHp / Truck.TestPlayer.MaxHp;
    }
}
