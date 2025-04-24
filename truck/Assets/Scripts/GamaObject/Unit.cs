using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public ETeam Team { get; private set; }

    public void SetTeam(ETeam team)
    {
        Team = team;
    }
    private void Awake()
    {
        UnitManager.AddUnit(this);
    }
    private void OnDestroy()
    {
        UnitManager.Remove(this);
    }
}
