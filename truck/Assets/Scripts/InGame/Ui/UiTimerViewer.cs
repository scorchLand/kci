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
    public float maxTime = 60;

    private float _currentTime = 60;

    private void Awake()
    {
        _currentTime = maxTime;
    }
    public void Update()
    {
        textMeshProUGUI.text = $"{TimeSpan.FromSeconds(_currentTime).ToMMSS()}";

        _currentTime -= Time.deltaTime;
        slider.value = _currentTime / maxTime;
    }
}
