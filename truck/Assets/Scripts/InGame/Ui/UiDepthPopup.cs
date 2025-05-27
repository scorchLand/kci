using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiDepthPopup : MonoBehaviour
{
    public void Close()
    {
        UiDepthManager.OnClosePopup(gameObject);
    }
}
