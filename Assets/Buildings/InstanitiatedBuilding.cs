using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanitiatedBuilding : ScriptableObject
{
    public BaseBuilding build;
    public Vector2Int position;
    public float people = 0;
    public bool upgraded = false;

    public GameAttributes getProfit()
    {
        if (upgraded)
            return build.upgradeScales;
        return build.baseScale;
    }
}
