using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMainCanvas : MonoBehaviour
{
    public UiHeroInfo uiHeroInfo;
    public UiHeroPointInfo uiHeroPointInfo;

    public MouseEffect mouseEffect;

    public void Initialize()
    {
        UiDepthManager.SetRoot(transform);
        uiHeroInfo.Initialize();
        uiHeroPointInfo.Initialize();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                transform as RectTransform,
                Input.mousePosition,
                Camera.main,
                out Vector2 localPoint
            );
            ((RectTransform)(mouseEffect.transform)).anchoredPosition = localPoint;
            mouseEffect.Play();
        }
    }
}
