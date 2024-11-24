using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameController : MonoBehaviour
{
    public float Distance { get; private set; }
    public static InGameController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        ObjectiveEvent<float>.AddObjectiveAction(EObjective.TRUCK_DISTANCE_UPDATE, UpdateUi);
    }
    private void OnDestroy()
    {
        ObjectiveEvent<float>.RemoveObjectiveAction(EObjective.TRUCK_DISTANCE_UPDATE, UpdateUi);
    }
    private void UpdateUi(EventData<float> data)
    {
        Distance += Time.deltaTime * data.data;
    }
}
