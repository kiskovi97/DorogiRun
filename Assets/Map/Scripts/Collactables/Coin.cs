using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collactable
{
    protected override void TriggerFunction(Collider other)
    {
        Debug.Log("Do Coin Stuff");
    }
}
