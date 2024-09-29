using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public static Vector3 vector = new Vector3(2.3f, 1.15f, 0f);
    private const float finalY = 5;
    public List<GameObject> lains = new List<GameObject>();

    private void Awake()
    {
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
        foreach (var lain in lains)
        {
            lain.transform.position += vector * data.data * Time.deltaTime;
            if (lain.transform.position.y > finalY)
            {
                lain.transform.position += -vector * (finalY * 2);
            }
        }
    }
}
