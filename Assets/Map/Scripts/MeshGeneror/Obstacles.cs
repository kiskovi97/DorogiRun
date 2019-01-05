using UnityEngine;

public class Obstacles : MonoBehaviour
{

    MapValues mapValues;

    int sector;

    float angle = 180f;

    float speed = 0f;

    public void SetValues(MapValues mapValues, int sector, float speed)
    {
        this.mapValues = mapValues;
        angle = mapValues.curve.startAngle;
        this.sector = sector;
        this.speed = speed;
    }

    public void Update()
    {
        angle -= Time.deltaTime * speed;
        if (angle < 0) Destroy(this.gameObject, 0.01f);
        transform.localPosition = mapValues.GetPosition(sector, angle);
        transform.rotation = Quaternion.AngleAxis(angle, mapValues.right);
    }
}
