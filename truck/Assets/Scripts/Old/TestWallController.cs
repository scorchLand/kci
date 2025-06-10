using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWallController : MonoBehaviour
{
    private static Vector3 _mapSize = new Vector3(5,10);

    public Vector3 mapSize = new Vector3(15, 30);
    public static bool IsTestBoxCollision(Vector3 targetVec)
    {
        if (Mathf.Abs(targetVec.x) > _mapSize.x)
            return false;
        else if(Mathf.Abs (targetVec.y) > _mapSize.y)
            return false;
        return true;
    }
    private void Awake()
    {
        _mapSize = mapSize;
    }
}
