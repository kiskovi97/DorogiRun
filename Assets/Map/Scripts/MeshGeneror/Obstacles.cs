using UnityEngine;
using System.Collections;

public class Obstacles : MonoBehaviour
{

    MapValues mapValues;

    int sector;

    float angle = 180;

    public void setValues(MapValues mapValues, int sector)
    {
        this.mapValues = mapValues;
        angle = mapValues.startAngle;
        this.sector = sector;
    }

    public void Update()
    {
        angle -= Time.deltaTime * mapValues.speed;
        if (angle < 0) Destroy(this.gameObject, 0.01f);
        transform.position = mapValues.GetPosition(sector, angle);
    }
}
