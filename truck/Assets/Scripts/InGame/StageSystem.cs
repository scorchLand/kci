using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour
{

    public float CurrentTime { get; private set; } = 0;
    public float Fuel { get; private set; }

    public float maxTime = 10;
    public int currentStage = 0;
    public float maxFuel = 30;

    public void Initialize()
    {
        Fuel = maxFuel;
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;
        CurrentTime += deltaTime;
        if (Fuel <= 0)
            return;
        var consum = InputController.InputDistance.magnitude;
        Fuel -= consum * deltaTime;
        ObjectiveEvent<float>.OnEvent("OnFuelUpdate", new EventData<float>(Fuel));
    }
    public void SetCurrentTime(float time)
    {
        CurrentTime = time;
    }
}
