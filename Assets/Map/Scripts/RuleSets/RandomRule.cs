using UnityEngine;
using UnityEditor;

public class RandomRule : RuleSet
{

    public override void Make()
    {
        int sector = mapValues.RandomSector();
        NewObstacle(sector, mapValues.StartDistance);
    }
}