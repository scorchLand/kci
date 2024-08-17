using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private static GameObject _goCamera;
    public static void Initialize(GameObject targetObject)
    {
        _goCamera = targetObject;
        _goCamera.AddComponent<CameraController>();
    }
    public static void Dispose()
    {
        Destroy(_goCamera);
    }

    public static void CameraShake()
    {

    }

    public Vector3 StaticPosition { get; private set; }

    private Coroutine _currentProcess;

    private void Start()
    {
        StaticPosition = transform.position;
    }

    private void ResetPosition()
    {
        transform.position = StaticPosition;
    }

    private IEnumerator RoutineCameraShake()
    {
        yield break;
    }
}
