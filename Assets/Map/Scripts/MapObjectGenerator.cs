using UnityEngine;

[RequireComponent(typeof(MapMesh))]
public class MapObjectGenerator : MonoBehaviour
{
    private MapValues mapValues;
    public Obstacles[] generated;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        MapMesh mesh = GetComponent<MapMesh>();
        mapValues = mesh.mapValues;
        InvokeRepeating("NewObject", 0.5f, 0.5f);
    }

    void NewObject()
    {
        int sector = mapValues.RandomSector();
        int selected = (int)(generated.Length * Random.value);
        Obstacles obj = Instantiate(generated[selected], new Vector3(0, 100, 0), new Quaternion());
        obj.SetValues(mapValues, sector, speed);
        obj.transform.parent = gameObject.transform;
        obj.Update();
    }
}
