using UnityEngine;
using UnityEditor;

public class JumpRule : RuleSet
{
    private static readonly float jumpHeight = 2f;
    private static readonly int coinNumber = 9;
    private static readonly float jumpLength = 15f;

    public float minLength = 10f;

    public override void Make(float speed)
    {
        for (int i=0; i<mapValues.SectorNumber; i++)
        {
            if (Random.value > 0.5f)
                NewObstacle(i, speed, mapValues.StartDistance);
            else if (Random.value > 0.5f)
                CollactablesLine(i, speed);
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
        float step = jumpLength / coinNumber;
        float jumpStep = jumpHeight / (coinNumber / 2);
        for (int index = 0; index < coinNumber; index++)
        {
            float heightIndex = index;
            if (index >= (coinNumber / 2 + 1)) heightIndex = (coinNumber - 1 - index);
            float distance = mapValues.StartDistance - step * index + step * (coinNumber / 2);

            // Kozeppont
            if (index == (coinNumber/2)) NewObstacle(sector, speed, distance);

            NewCollacltable(sector, speed, distance, heightIndex * jumpStep + minHeight);
        }
    }

    void CollactablesLine(int sector, float speed)
    {
        float step = jumpLength / coinNumber;
        for (int index = 0; index < coinNumber; index++)
        {
            float distance = mapValues.StartDistance - step * index + step * (coinNumber / 2);
            NewCollacltable(sector, speed, distance);
        }
    }
}