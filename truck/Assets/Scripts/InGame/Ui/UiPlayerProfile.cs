using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiPlayerProfile : MonoBehaviour
{
    public Slider fuelValue;

    private void OnEnable()
    {
        ObjectiveEvent<float>.AddEvent("OnFuelUpdate", OnFuelUpdate);
    }
    private void OnDisable()
    {
        ObjectiveEvent<float>.RemoveEvent("OnFuelUpdate", OnFuelUpdate);
    }
    private void OnFuelUpdate(EventData<float> data )
    {
        //fuelValue.value = data.data / InGameController.Instance.stageSystem.maxFuel;

        float currentTime = InGameController.Instance.stageSystem.maxTime - InGameController.Instance.stageSystem.CurrentTime;

        fuelValue.value = (currentTime) / InGameController.Instance.stageSystem.maxTime;
    }
}
