using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enviroment : ScriptableObject
{
    public MovingObject[] obstacles;
    public MovingObject[] sideObjects;

    public MovingObject GetObstacle()
    {
        if (obstacles == null) throw new System.Exception("Enviroment Not Valid: Missing obstacles");
        int selected = (int)(obstacles.Length * Random.value);
        return Instantiate(obstacles[selected], new Vector3(0, 100, 0), new Quaternion());
    }

    public MovingObject GetSideObject()
    {
        if (sideObjects == null) throw new System.Exception("Enviroment Not Valid: Missing sideObjects");
        int selected = (int)(sideObjects.Length * Random.value);
        return Instantiate(sideObjects[selected], new Vector3(0, 100, 0), new Quaternion());
    }

    public MovingObject GetMinLengthObstacle(float min)
    {
        if (sideObjects == null) throw new System.Exception("Enviroment Not Valid: Missing obstacles");
        List<MovingObject> list = new List<MovingObject>();
        for (int i=0; i<obstacles.Length; i++)
        {
            if (obstacles[i].length >= min)
            {
                list.Add(obstacles[i]);
            }
        }
        if (list.Count > 0)
        {
            int selected = (int)(Random.value * list.Count);
            return Instantiate(list[selected], new Vector3(0, 100, 0), new Quaternion());
        }
        return null;
    }
}
