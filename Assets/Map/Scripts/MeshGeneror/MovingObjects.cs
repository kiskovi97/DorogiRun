using UnityEngine;

public class MovingObjects : MonoBehaviour
{

    MapValues mapValues;

    int sector;

    float distance = 180f;

    float speed = 0f;

    public void SetValues(MapValues mapValues, int sector, float speed)
    {
        this.mapValues = mapValues;
        distance = mapValues.curve.StartDistance;
        this.sector = sector;
        this.speed = speed;
    }

    public void SetDistance(float distance)
    {
        this.distance = distance;
    }

    public void Update()
    {
        distance -= Time.deltaTime * speed;
        if (distance < mapValues.curve.EndDistance) Destroy(this.gameObject, 0.01f);
        transform.localPosition = mapValues.GetPosition(sector, distance);
        transform.rotation = Quaternion.AngleAxis(mapValues.curve.DistanceToAngle(distance), mapValues.right);
    }
}
