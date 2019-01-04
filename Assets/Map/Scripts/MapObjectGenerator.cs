using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjectGenerator : MonoBehaviour
{
    public MapValues mapValues;
    public Obstacles generated;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("NewObject", 0.5f, 0.5f);
    }

    void NewObject()
    {
        Debug.Log("New Object Created");
        int sector = mapValues.RandomSector();
        Obstacles obj = Instantiate(generated, new Vector3(0,100, 0), new Quaternion());
        obj.setValues(mapValues, sector);
        obj.Update();
    }
}
