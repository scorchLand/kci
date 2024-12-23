using Grooz;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameController : MonoBehaviour
{
    public static InGameController Instance { get; private set; }


    public SpawnSystem spawnSystem { get; private set; }
    public float Distance { get; private set; }

    private void Awake()
    {
        Tables.LoadFromResources();
        Instance = this;
        ObjectiveEvent<float>.AddObjectiveAction(EObjective.TRUCK_DISTANCE_UPDATE, UpdateDistance);

        spawnSystem = new SpawnSystem();
    }
    private void OnDestroy()
    {
        ObjectiveEvent<float>.RemoveObjectiveAction(EObjective.TRUCK_DISTANCE_UPDATE, UpdateDistance);
    }
    private void Update()
    {
        spawnSystem.Update();
    }
    private void UpdateDistance(EventData<float> data)
    {
        Distance += Time.deltaTime * data.data;
    }
}
