using UnityEngine;

public class MapMesh : GeneratedObject
{
    private float angle = 0.0f;

    // angle/vertex
    public float anglePerVertex = 0.2f;

    public MapValues mapValues;

    public void Start()
    {
        MakePlace();
        angle = anglePerVertex;
    }

    public void UpdateAngle(float deltaTime)
    {
        angle -= deltaTime;
        if (angle < 0f) angle += anglePerVertex;
        MakePlace();
    }

    public void MakePlace()
    {
        if (mapValues == null) return;
        Clear();
        MapGenerator place = new MapGenerator(mapValues, angle, anglePerVertex);
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
