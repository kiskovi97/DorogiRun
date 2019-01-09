using UnityEngine;

[RequireComponent(typeof(MapMesh))]
public class MapObjectGenerator : MonoBehaviour
{
    private MapValues mapValues;
    public MovingObjects[] generated;
    public MovingObjects[] sideObjects;
    public float speed = 5.0f;
    public float sideObjectFrequency = 2.0f;
    public float objectGeneratingFrequency = 1.0f;
    private MapMesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MapMesh>();
        mapValues = mesh.mapValues;
        InvokeRepeating("NewObject", objectGeneratingFrequency / speed, objectGeneratingFrequency / speed);
        InvokeRepeating("MakeSideObjects", sideObjectFrequency / speed, sideObjectFrequency / speed);
        MakeAllSideObjects();
    }

    private void Update()
    {
        mesh.UpdateAngle(Time.deltaTime * speed);
    }

    void NewObject()
    {
        int sector = mapValues.RandomSector();
        NewObstacle(sector);
    }

    void NewObstacle(int sector)
    {
        if (generated == null) return;
        int selected = (int)(generated.Length * Random.value);
        MovingObjects obj = Instantiate(generated[selected], new Vector3(0, 100, 0), new Quaternion());
        obj.SetValues(mapValues, sector, speed);
        obj.transform.parent = gameObject.transform;
        obj.Update();
    }

    void MakeSideObjects()
    {
        if (sideObjects == null) return;
        int[] tomb = mapValues.SideSector();
        foreach (int value in tomb)
        {
            int selected = (int)(sideObjects.Length * Random.value);
            MovingObjects obj = Instantiate(sideObjects[selected], new Vector3(0, 100, 0), new Quaternion());
            obj.SetValues(mapValues, value, speed);
            obj.transform.parent = gameObject.transform;
            if (value > 0)
            {
                Vector3 scale = obj.transform.localScale;
                scale.x *= -1;
                obj.transform.localScale = scale;
            }
            obj.Update();
        }
    }

    private void MakeAllSideObjects()
    {
        if (sideObjects == null) return;
        int[] tomb = mapValues.SideSector();
        foreach (int value in tomb)
        {
            for (float distance = mapValues.curve.StartDistance; distance > mapValues.curve.EndDistance; distance-= sideObjectFrequency)
            {
                int selected = (int)(sideObjects.Length * Random.value);
                MovingObjects obj = Instantiate(sideObjects[selected], new Vector3(0, 100, 0), new Quaternion());
                obj.SetValues(mapValues, value, speed);
                obj.transform.parent = gameObject.transform;
                if (value > 0)
                {
                    Vector3 scale = obj.transform.localScale;
                    scale.x *= -1;
                    obj.transform.localScale = scale;
                }
                obj.SetDistance(distance);
                obj.Update();
            }
        }
    }
}
