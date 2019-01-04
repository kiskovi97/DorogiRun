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
}
