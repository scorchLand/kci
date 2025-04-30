using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static Vector3 InputDistance => IsMouseDown && !IsUiMode ? GetDragValue (InputMouseDrag): Vector3.zero;
    public static Vector3 InputMouseDrag => Input.mousePosition - InputMouseDown;

    public static bool IsMouseDown { get; private set; } = false;
    public static bool IsUiMode { get; private set; } = false;

    private static Vector3 InputMouseDown;

    private static Vector3 GetDragValue(Vector3 distance)
    {
        var nomalize = distance.normalized;
        if (distance.sqrMagnitude > 4000)
            return nomalize;
        else
        {
            return nomalize * distance.sqrMagnitude / 4000;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsMouseDown = true;
            InputMouseDown = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            IsMouseDown = false;
        }
        
    }
    public static void SetUiMode(bool on)
    {
        IsUiMode = on;
    }
}
