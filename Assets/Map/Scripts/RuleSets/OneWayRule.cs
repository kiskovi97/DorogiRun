using UnityEngine;
using UnityEditor;

public class OneWayRule : RuleSet
{

    public float minLength = 10f;

    public override void Make(float speed)
    {
        int sector = mapValues.RandomSector();
        for (int i=0; i<mapValues.SectorNumber; i++)
        {
            if (i == sector) NewCollacltable(i, speed);
            else NewObstacle(i, speed);
        }
    }

    void NewObstacle(int sector, float speed)
    {
        MovingObject obj = enviroment.GetMinLengthObstacle(minLength);
        if (obj == null) throw new System.Exception("Not long enough");
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