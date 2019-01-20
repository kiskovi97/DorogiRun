using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collactable
{
    protected override void TriggerFunction(Collider other)
    {
        PlayerData.actualCoin += 1;
    }
}
