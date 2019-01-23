using UnityEngine;
using UnityEditor;

public class JumpRule : RuleSet
{

    public float minLength = 10f;

    public override void Make()
    {
        for (int i=0; i<mapValues.SectorNumber; i++)
        {
            if (Random.value > 0.2f)
                NewSmallObstacle(i, mapValues.StartDistance, minLength);
            else Collactables(i, minLength);
                
        }
    }
}