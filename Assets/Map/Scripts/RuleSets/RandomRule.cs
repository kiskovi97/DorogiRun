using UnityEngine;
using UnityEditor;

public class RandomRule : RuleSet
{

    public override void Make(float speed)
    {
        int sector = mapValues.RandomSector();
        NewObstacle(sector, speed);
    }

    void NewObstacle(int sector, float speed)
    {
        MovingObject obj = enviroment.GetObstacle();
        obj.SetValues(mapValues, sector, speed);
        obj.transform.parent = parent;
        obj.Update();
    }
}