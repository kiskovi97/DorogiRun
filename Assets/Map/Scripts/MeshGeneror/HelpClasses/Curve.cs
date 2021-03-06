﻿using UnityEngine;

[System.Serializable]
public class Curve : System.Object
{
    public Vector3 forward = new Vector3(0, 0, 1);

    public float R = 500.0f;

    public float StartDistance = 100f;

    public float EndDistance = -20f;
    
    private Vector3 GetPoint(float angle)
    {
        Vector3 up = new Vector3(0, 1, 0);
        float radiant = angle / 180 * Mathf.PI;
        float height = R * Mathf.Cos(radiant) - R;
        float length = R * Mathf.Sin(radiant);
        return up * height + forward.normalized * length;
    }

    private float AngleToDistance(float angle)
    {
        return angle / 360 * (2 * R * Mathf.PI);
    }

    public float DistanceToAngle(float distance)
    {
        return distance * 360 / (2 * R * Mathf.PI);
    }

    public Vector3 GetPointByDistance(float distance)
    {
        float angle = DistanceToAngle(distance);
        return GetPoint(angle);
    }

}
