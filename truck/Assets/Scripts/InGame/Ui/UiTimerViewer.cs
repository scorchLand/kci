using DevDev.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiTimerViewer : UiComponent
{
    public TextMeshProUGUI textMeshProUGUI;
    public Slider slider;



    private void Awake()
    {

    }
    public void Update()
    {
        float currentTime = InGameController.Instance.stageSystem.maxTime - InGameController.Instance.stageSystem.CurrentTime;
        textMeshProUGUI.text = $"{TimeSpan.FromSeconds(currentTime).ToMMSS()}";

        slider.value = (currentTime) / InGameController.Instance.stageSystem.maxTime;
    }
}
