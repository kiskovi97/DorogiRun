using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collactable : MovingObject
{
    public void OnTriggerEnter(Collider other)
    {
        TriggerFunction(other);
        Destroy(this, 0.01f);
    }

    protected abstract void TriggerFunction(Collider other);
}
