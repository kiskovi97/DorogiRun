using UnityEngine;
using UnityEditor;

public class OneWayRule : RuleSet
{

    public float minLength = 10f;

    public override void Make()
    {
        int sector = mapValues.RandomSector();
        for (int i=0; i<mapValues.SectorNumber; i++)
        {
            if (i == sector) NewCollacltable(i, mapValues.StartDistance);
            else NewBigObstacle(i, mapValues.StartDistance, minLength);
        }
    }
}