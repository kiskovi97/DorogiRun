﻿using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class MapValues : ScriptableObject
{
    public Vector3 basePoint = new Vector3(0, 0, 0);
    public Vector3 right = new Vector3(1, 0, 0);
    public Curve curve;
    public float sectorSize = 2.0f;
    public int sectorNumber = 3;
    public int RandomSector()
    {
        int selected = (int)(Random.value * (float)sectorNumber);
        return selected;
    }

    public int[] SideSector()
    {
        return new int[]
        {
            -1,
            sectorNumber
        };
    }

    public Vector3 Sector(int selected)
    {
        Vector3 farLeft = basePoint - right.normalized * sectorSize * (sectorNumber / 2f);
        return farLeft + right.normalized * sectorSize * (selected + 0.5f);
    }

    private Vector3 Forward(float distance)
    {
        return curve.GetPointByDistance(distance);
    }

    public Vector3 GetPosition(int sector, float distance)
    {
        return Sector(sector) + Forward(distance);
    }

}
