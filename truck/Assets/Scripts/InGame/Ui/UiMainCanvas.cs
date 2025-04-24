using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMainCanvas : MonoBehaviour
{
    public UiHeroInfo uiHeroInfo;
    public UiHeroPointInfo uiHeroPointInfo;

    public void Initialize()
    {
        uiHeroInfo.Initialize();
        uiHeroPointInfo.Initialize();
    }
}
