using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collactable : MovingObject
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        TriggerFunction(other);
        Destroy(gameObject, 0.01f);
    }

    protected abstract void TriggerFunction(Collider other);
}
