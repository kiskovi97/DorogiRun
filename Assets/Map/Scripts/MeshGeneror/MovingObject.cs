using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float length = 4.0f;

    public bool side = false;

    MapValues mapValues;

    int sector;

    float distance = 180f;

    private float minDistance = 0f;

    float speed = 0f;

    public void SetValues(MapValues mapValues, int sector, float speed)
    {
        this.mapValues = mapValues;
        distance = mapValues.StartDistance;
        this.sector = sector;
        this.speed = speed;
        minDistance = mapValues.EndDistance;
    }

    public void SetDistance(float distance)
    {
        this.distance = distance;
    }

    public void Update()
    {
        distance -= Time.deltaTime * speed;
        if (distance < minDistance) Destroy(this.gameObject, 0.01f);
        transform.localPosition = mapValues.GetPosition(sector, distance);
        transform.rotation = mapValues.GetRotation(distance);
    }

    public bool Close(float far)
    {
        return (distance - far < minDistance);
    }
}
