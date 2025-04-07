using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTowerScore
{
    public int Count { get; private set; } = 0;
    public float Value { get; private set; } = 0;

    public void AddValue(float value)
    {
        Value += value;
        Update();
    }
    public void Update()
    {
        if (Value >= 1)
        {
            Count++;
            Value -= 1;
        }
    }
    public void CreateTower()
    {
        if (Count > 0)
        {
            Count--;
            Player.Instance.CreateTower();
        }
    }
}