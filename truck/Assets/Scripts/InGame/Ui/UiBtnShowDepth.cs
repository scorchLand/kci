using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiBtnShowDepth : MonoBehaviour
{
    public string popupPath;

    public void OnClick()
    {
        UiDepthManager.ShowPopup(popupPath);
    }
}
