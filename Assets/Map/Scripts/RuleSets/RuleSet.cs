using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuleSet : MonoBehaviour
{

    private static readonly float jumpHeight = 2f;
    private static readonly int coinNumber = 9;
    private static readonly float jumpLength = 15f;

    protected MapValues mapValues;
    protected Enviroment enviroment;
    protected Transform parent;

    protected static readonly float minHeight = 0.5f;
    public float length = 4.0f;

    public void Set(MapValues mapValues, Enviroment enviroment, Transform parent)
    {
        this.mapValues = mapValues;
        this.enviroment = enviroment;
        this.parent = parent;
    }

    public abstract void Make();

    protected void NewObstacle(int sector, float distance)
    {
        MovingObject obj = enviroment.GetObstacle();
        obj.SetValues(mapValues, sector);
        obj.transform.parent = parent;
        obj.SetDistance(distance);
        obj.Update();
    }

    protected void NewSmallObstacle(int sector, float distance, float minLength)
    {
        MovingObject obj = enviroment.GetMaxLengthObstacle(minLength);
        if (obj == null) throw new System.Exception("Not short enough");
        obj.SetValues(mapValues, sector);
        obj.transform.parent = parent;
        obj.SetDistance(distance);
        obj.Update();
    }

    protected void NewBigObstacle(int sector, float distance, float minLength)
    {
        MovingObject obj = enviroment.GetMinLengthObstacle(minLength);
        if (obj == null) throw new System.Exception("Not long enough");
        obj.SetValues(mapValues, sector);
        obj.transform.parent = parent;
        obj.SetDistance(distance);
        obj.Update();
    }

    protected void NewCollacltable(int sector, float distance, float height = 0.5f)
    {
        MovingObject obj = enviroment.GetCollactable();
        if (obj == null) return;
        obj.SetValues(mapValues, sector);
        obj.transform.parent = parent;
        obj.SetDistance(distance);
        obj.SetHeight(height);
        obj.Update();
    }

    protected void Collactables(int sector, float minLength)
    {
        float step = jumpLength / coinNumber;
        float jumpStep = jumpHeight / (coinNumber / 2);
        for (int index = 0; index < coinNumber; index++)
        {
            float heightIndex = index;
            if (index >= (coinNumber / 2 + 1)) heightIndex = (coinNumber - 1 - index);
            float distance = mapValues.StartDistance - step * index + step * (coinNumber / 2);

            // Kozeppont
            if (index == (coinNumber / 2)) NewSmallObstacle(sector, distance, minLength);

            NewCollacltable(sector, distance, heightIndex * jumpStep + minHeight);
        }
    }

    protected void CollactablesLine(int sector)
    {
        float step = jumpLength / coinNumber;
        for (int index = 0; index < coinNumber; index++)
        {
            float distance = mapValues.StartDistance - step * index + step * (coinNumber / 2);
            NewCollacltable(sector, distance);
        }
    }

}
