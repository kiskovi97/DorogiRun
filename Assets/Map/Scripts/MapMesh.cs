using UnityEngine;

public class MapMesh : GeneratedObject
{
    private float distance = 0.0f;

    // angle/vertex
    public float resolution = 0.2f;

    public MapValues mapValues;

    public void Start()
    {
        MakePlace();
        distance = resolution;
    }

    public void UpdateAngle(float deltaTime)
    {
        distance -= deltaTime;
        if (distance < 0f) distance += resolution;
        MakePlace();
    }

    public void MakePlace()
    {
        if (mapValues == null) return;
        Clear();
        MapGenerator place = new MapGenerator(mapValues, distance, resolution);
        foreach (Triangle triangle in place.getTriangles())
        {
            AddTriangle(triangle);
        }
        CreateMesh();
    }

    public void ReGenerate()
    {
        MakePlace();
    }
}
