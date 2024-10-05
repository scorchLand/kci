using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class UiButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
	[System.Serializable]
	public class UiButtonEvent : UnityEvent<UiButton> { }

	public UiButtonEvent onClick = new UiButtonEvent();
    private void Awake()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onClick.Invoke(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
