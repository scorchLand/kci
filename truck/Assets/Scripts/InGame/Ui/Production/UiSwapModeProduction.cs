using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSwapModeProduction : MonoBehaviour, IDepthUi, ILifeTimeAble
{
    public Animation ani;

    public float LifeTime { get; private set; } = 2;

    public float ProgressTime { get; private set; } = 0;

    public void SetMode(int num)
    {
        ani.clip = ani.GetClip(num == 0 ? "UiLoadingWave_goDrive" : "UiLoadingWave_goDefense");
        ani.Play();
    }
    public void SetLifeTime(float time)
    {
        LifeTime = time;
        ProgressTime = 0;
    }
    private void Update()
    {
        ProgressTime += Time.deltaTime;
        if (ProgressTime > LifeTime)
        {
            Close();
        }
    }
    public void Close()
    {
        UiDepthManager.OnClosePopup(gameObject);
    }
}
