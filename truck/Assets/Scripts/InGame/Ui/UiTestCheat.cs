using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiTestCheat : UiComponent
{
    public GameObject goUiCheat;
    public Slider slider;

    private void Awake()
    {
        slider.value = 0.5f;
    }
    private void Update()
    {
        Truck.TestPlayer.truckSpeed = slider.value * 1000;
    }

    public void OnClickCheatButton()
    {
        goUiCheat.SetActive(!goUiCheat.activeSelf);
    }
}
