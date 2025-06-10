using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitManager
{
    public static IReadOnlyList<Unit> UnitList => _unitList;
    private static List<Unit> _unitList = new List<Unit>();

    public static void AddUnit(Unit unit)
        { _unitList.Add(unit); }
    public static void Remove(Unit unit)
        { _unitList.Remove(unit); }
}