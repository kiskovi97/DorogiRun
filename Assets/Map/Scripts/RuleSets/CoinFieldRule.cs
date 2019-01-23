using UnityEngine;
using UnityEditor;

public class CoinFieldRule : RuleSet
{
    public float minLength = 10f;

    public override void Make()
    {
        for (int i=0; i<mapValues.SectorNumber; i++)
        {
            if (i == (mapValues.SectorNumber / 2)) Collactables(i, minLength);
            else CollactablesLine(i);
        }
    }
}