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
                NewObstacle(i, speed);
            else
                NewCollacltable(i, speed);
        }
    }

    void NewObstacle(int sector, float speed)
    {
        MovingObject obj = enviroment.GetMaxLengthObstacle(minLength);
        if (obj == null) throw new System.Exception("Not short enough");
        obj.SetValues(mapValues, sector, speed);
        obj.transform.parent = parent;
        obj.Update();
    }
    void NewCollacltable(int sector, float speed)
    {
        MovingObject obj = enviroment.GetCollactable();
        if (obj == null) return;
        obj.SetValues(mapValues, sector, speed);
        obj.transform.parent = parent;
        obj.Update();
    }
}