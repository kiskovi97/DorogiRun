using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float length = 4.0f;

    private float height = 0f;

    public float offset = 0.0f;

    public bool side = false;

    public bool ramp = false;

    MapValues mapValues;

    int sector;

    float distance = 180f;

    private float minDistance = 0f;

    float speed = 0f;

    public void SetValues(MapValues mapValues, int sector, float plusSpeed = 0)
    {
        this.mapValues = mapValues;
        distance = mapValues.StartDistance;
        this.sector = sector;
        speed = MapObjectGenerator.Speed + plusSpeed;
        minDistance = mapValues.EndDistance;
    }

    public void SetDistance(float distance)
    {
        this.distance = distance;
    }

    public void SetHeight(float height)
    {
        this.height = height;
    }

    public void Update()
    {
        distance -= Time.deltaTime * speed;
        if (distance < minDistance) Destroy(this.gameObject, 0.01f);
        transform.localPosition = mapValues.GetPosition(sector, distance, offset) + new Vector3(0,height,0);
        transform.rotation = mapValues.GetRotation(distance);
    }

    public bool Close(float far)
    {
        return (distance - far < minDistance);
    }
}
