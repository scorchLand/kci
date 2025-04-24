using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
public static class ObjectiveEvent<T>
{
    //public static bool IsLogging { get; } = false;
    public static event Action<EventData<T>> onPeapleHit;
    //public static event Action<EventData<T>> onTruckCrash;
    //public static event Action<EventData<T>> onTruckDistanceUpdate;
    //public static event Action<EventData<T>> onTruckFuleDown;
    private static Dictionary<string, List<Action<EventData<T>>>> _list = new Dictionary<string, List<Action<EventData<T>>>>();

    public static void AddEvent(string key, Action<EventData<T>> action)
    {
        if (!_list.ContainsKey(key))
        {
            _list.Add(key, new List<Action<EventData<T>>>());
        }
        _list[key].Add(action);
    }
    public static void RemoveEvent(string key, Action<EventData<T>> action)
    {
        if (!_list.ContainsKey(key))
        {
            return;
        }
        _list[key].Remove(action);
        if (_list[key].Count == 0)
            _list.Remove(key);
    }
    public static void OnEvent(string key, EventData<T> data = null)
    {
        if (!_list.ContainsKey(key))
        {
            return;
        }
        foreach(var action in _list[key])
        {
            action?.Invoke(data);
        }
    }
    public static void OnPeopleHit(EventData<T> data)
    {
        onPeapleHit?.Invoke(data);
    }
    //public static void OnTruckCrash(EventData<T> data)
    //{
    //    onTruckCrash?.Invoke(data);
    //}
    //public static void OnTruckDictanceUpdate(EventData<T> data)
    //{
    //    onTruckDistanceUpdate?.Invoke(data);
    //}
    //public static void OnTruckFuleDown(EventData<T> data)
    //{
    //    onTruckFuleDown?.Invoke(data);
    //}
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
