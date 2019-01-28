using UnityEngine;
using UnityEditor;

public class OneWayRule : RuleSet
{

    public float minLength = 10f;

    public override void Make()
    {
        int sector = mapValues.RandomSector();
        for (int i=0; i<mapValues.SectorNumber; i++)
        {
            if (i == sector)
            {   
                if (Random.value > 0.9f)
                    NewCollactable(i, mapValues.StartDistance);
                else
                    ShortCoinLine(i);
            }
            else NewBigObstacle(i, mapValues.StartDistance, minLength);
        }
    }
}