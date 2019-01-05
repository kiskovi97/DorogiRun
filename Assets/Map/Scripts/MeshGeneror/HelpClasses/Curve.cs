using UnityEngine;

[System.Serializable]
public class Curve : System.Object
{
    public Vector3 forward = new Vector3(0, 0, 10);
    public float R = 10.0f;
    public float startAngle = 30;

    public Vector3 GetCurvePoint(float angle)
    {
        Vector3 up = new Vector3(0, 1, 0);
        float radiant = angle / 180 * 3.14f;
        float height = R * Mathf.Cos(radiant) - R;
        float length = R * Mathf.Sin(radiant);
        return up * height + forward.normalized * length;
    }

}
