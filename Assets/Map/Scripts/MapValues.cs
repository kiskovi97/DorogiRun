using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class MapValues : ScriptableObject
{
    public Vector3 basePoint = new Vector3(0, 0, 0);
    public Vector3 right = new Vector3(1, 0, 0);
    public Vector3 forward = new Vector3(0, 0, 10);
    public float sectorSize = 2.0f;
    public int sectorNumber = 3;
    public float R = 10.0f;
    public float startAngle = 30;
    public float speed = 5;
    public int RandomSector()
    {
        int selected = (int)(Random.value * (float)sectorNumber);
        return selected;
    }

    public Vector3 Sector(int selected)
    {
        Vector3 farLeft = basePoint - right.normalized * sectorSize * (sectorNumber / 2f);
        return farLeft + right.normalized * sectorSize * (selected + 0.5f);
    }

    public Vector3 GetPosition(int sector, float angle)
    {
        Vector3 up = new Vector3(0, 1, 0);
        float radiant = angle / 180 * 3.14f;
        float height = R * Mathf.Cos(radiant) - R;
        float length = R * Mathf.Sin(radiant);
        return Sector(sector) + up * height + forward.normalized * length;
    }

}
