using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExCoroutine : MonoBehaviour
{
    private static ExCoroutine _instance;
    private static List<Coroutine> _list = new List<Coroutine>();
}
