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
        if (sideObjects == null) throw new System.Exception("Enviroment Not Valid: Missing obstacles");
        int selected = (int)(sideObjects.Length * Random.value);
        return Instantiate(sideObjects[selected], new Vector3(0, 100, 0), new Quaternion());
    }
}
