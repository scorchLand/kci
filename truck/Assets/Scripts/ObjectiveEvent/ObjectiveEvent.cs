using System;
using System.Numerics;
using UnityEngine;
public enum EObjective
{
    NONE,
    TRUCK_CRASH,
    TRUCK_DISTANCE_UPDATE,
}
public static class ObjectiveEvent<T>
{
    //public static bool IsLogging { get; } = false;

    public static event Action<EventData<T>> onTruckCrash;
    public static event Action<EventData<T>> onTruckDistanceUpdate;

    public static void AddObjectiveAction(EObjective type, Action<EventData<T>> action)
    {
        switch (type)
        {
            case EObjective.TRUCK_CRASH:
                onTruckCrash += action;
                break;
            case EObjective.TRUCK_DISTANCE_UPDATE:
                onTruckDistanceUpdate += action;
                break;
        }
    }
    public static void RemoveObjectiveAction(EObjective type, Action<EventData<T>> action)
    {
        switch (type)
        {
            case EObjective.TRUCK_CRASH:
                onTruckCrash -= action;
                break;
            case EObjective.TRUCK_DISTANCE_UPDATE:
                onTruckDistanceUpdate -= action;
                break;
        }
    }
    public static void OnTruckCrash(EventData<T> data)
    {
        onTruckCrash?.Invoke(data);
    }
    public static void OnTruckDictanceUpdate(EventData<T> data)
    {
        onTruckDistanceUpdate?.Invoke(data);
    }
}
public class EventData<T>
{
    public static EventData<T> Empty => _empty;
    private static readonly EventData<T> _empty = new EventData<T>();

    public T data;
    //public string[] str;
    //public BigInteger[] bigInteger;
    //public long[] value;
    public EventData()
    {

    }
    public EventData(T data)
    {
        this.data = data;
    }
    //public EventData(T data, params long[] value)
    //{
    //    this.data = data;
    //    this.value = value;
    //}
    //public EventData(T data, params BigInteger[] bigInteger)
    //{
    //    this.data = data;
    //    this.bigInteger = bigInteger;
    //}
}
