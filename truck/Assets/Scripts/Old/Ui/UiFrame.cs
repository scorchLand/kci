using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiFrame : MonoBehaviour, IUiExtension
{
    public RectTransform RectTransform => (RectTransform)transform;
}
