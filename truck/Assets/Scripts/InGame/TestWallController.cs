using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWallController : MonoBehaviour
{

    public static bool IsTestBoxCollision(Vector3 targetVec)
    {
        if (Mathf.Abs(targetVec.x) > 10)
            return false;
        else if(Mathf.Abs (targetVec.y) > 10)
            return false;
        return true;
    }
}
