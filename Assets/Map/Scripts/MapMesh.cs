public class MapMesh : GeneratedObject
{

    public MapValues mapValues;

    public void Start()
    {
        MakePlace();
    }

    public void MakePlace()
    {
        Clear();
        MapGenerator place = new MapGenerator(mapValues);
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
