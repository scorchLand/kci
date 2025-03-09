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
        float currentTime = StageSystem.Instance.maxTime - StageSystem.Instance.CurrentTime;
        textMeshProUGUI.text = $"{TimeSpan.FromSeconds(currentTime).ToMMSS()}";

        slider.value = (currentTime) / StageSystem.Instance.maxTime;
    }
}
