using UnityEngine;
using UnityEditor;

public class JumpRule : RuleSet
{

    public float minLength = 10f;

    public override void Make(float speed)
    {
        for (int i=0; i<mapValues.SectorNumber; i++)
        {
            if (Random.value > 0.5f)
                NewObstacle(i, speed, mapValues.StartDistance);
            else
                Collactables(i, speed);
        }
    }

    void NewObstacle(int sector, float speed, float distance)
    {
        MovingObject obj = enviroment.GetMaxLengthObstacle(minLength);
        if (obj == null) throw new System.Exception("Not short enough");
        obj.SetValues(mapValues, sector, speed);
        obj.transform.parent = parent;
        obj.SetDistance(distance);
        obj.Update();
    }

    void Collactables(int sector, float speed)
    {
        for (int index = 0; index < 5; index++)
        {
            float step = length / 7f;
            float height = index;
            if (index >= 3) height =( -1 * index + 4);
            float distance = mapValues.StartDistance - step * index + step * 2f;
            if (index == 2) NewObstacle(sector, speed, distance);
            NewCollacltable(sector, speed, distance, height + 0.3f);
        }
    }
}