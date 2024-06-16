using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private const float finalY = 12.4f;
    private const float finalY2 = 16;
    public List<GameObject> lains = new List<GameObject>();

    public List<GameObject> lains2 = new List<GameObject>();

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
            lain.transform.position += Vector3.up * data.data * Time.deltaTime;
            if (lain.transform.position.y > finalY)
            {
                lain.transform.position += Vector3.down * 2 * finalY;
            }
        }
        foreach (var lain in lains2)
        {
            lain.transform.position += Vector3.up * data.data * Time.deltaTime;
            if (lain.transform.position.y > finalY2)
            {
                lain.transform.position += Vector3.down * 2 * finalY2;
            }
        }
    }
}
