using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public static Vector3 vector = new Vector3(2.3f, 1.15f, 0f);
    private const float finalX = 9.2f;
    public Transform lainTrans;
    private List<GameObject> _lainList = new List<GameObject>();

    private void Awake()
    {
        for(int i = 0; i< lainTrans.childCount; i++)
        {
            _lainList.Add(lainTrans.GetChild(i).gameObject);
        }
    }
    private void OnEnable()
    {
        ObjectiveEvent<float>.onTruckDistanceUpdate += OnTruckDistanceUpdate;
    }
    private void OnDisable()
    {
        ObjectiveEvent<float>.onTruckDistanceUpdate -= OnTruckDistanceUpdate;
    }
    private void OnTruckDistanceUpdate(EventData<float> data)
    {
        foreach (var lain in _lainList)
        {
            lain.transform.position += vector * data.data * Time.deltaTime * 0.01f;
            if (lain.transform.position.x > finalX)
            {
                lain.transform.position += -vector * (finalX);
            }
        }
    }
}
