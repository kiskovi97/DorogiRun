using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuleSet : MonoBehaviour
{
    protected MapValues mapValues;
    protected Enviroment enviroment;
    protected Transform parent;
    public float length = 4.0f;

    public void Set(MapValues mapValues, Enviroment enviroment, Transform parent)
    {
        this.mapValues = mapValues;
        this.enviroment = enviroment;
        this.parent = parent;
    }

    public abstract void Make(float speed);

    protected void NewCollacltable(int sector, float speed, float distance, float height = 0f)
    {
        MovingObject obj = enviroment.GetCollactable();
        if (obj == null) return;
        obj.SetValues(mapValues, sector, speed);
        obj.transform.parent = parent;
        obj.SetDistance(distance);
        obj.SetHeight(height);
        obj.Update();
    }

}
