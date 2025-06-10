using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiComponent : MonoBehaviour, IUiExtension
{
    public RectTransform RectTransform => (RectTransform)transform;
}
