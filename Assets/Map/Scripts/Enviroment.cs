using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enviroment : ScriptableObject
{
    public MovingObject[] obstacles;
    public MovingObject[] sideObjects;
    public ObjectFrequency[] collactables;

    [System.Serializable]
    public class ObjectFrequency
    {
        public MovingObject obj;
        public float frequency=1.0f;
    }

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

    public MovingObject GetMinLengthObstacle(float min, bool rampToo = false)
    {
        if (sideObjects == null) throw new System.Exception("Enviroment Not Valid: Missing obstacles");
        List<MovingObject> list = new List<MovingObject>();
        for (int i=0; i<obstacles.Length; i++)
        {
            if (obstacles[i].length >= min && !obstacles[i].ramp || rampToo)
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

    public MovingObject GetMaxLengthObstacle(float max)
    {
        if (sideObjects == null) throw new System.Exception("Enviroment Not Valid: Missing obstacles");
        List<MovingObject> list = new List<MovingObject>();
        for (int i = 0; i < obstacles.Length; i++)
        {
            if (obstacles[i].length < max)
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

    public MovingObject GetRampObstacle(float min)
    {
        if (sideObjects == null) throw new System.Exception("Enviroment Not Valid: Missing obstacles");
        List<MovingObject> list = new List<MovingObject>();
        for (int i = 0; i < obstacles.Length; i++)
        {
            if (obstacles[i].ramp && obstacles[i].length > min)
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

    public MovingObject GetCollactable()
    {
        if (collactables == null) return null;
        foreach (ObjectFrequency objectFrequency in collactables)
        {
            if (Random.value < objectFrequency.frequency)
            {
                return Instantiate(objectFrequency.obj);
            }
        }
        return null;
    }
}
