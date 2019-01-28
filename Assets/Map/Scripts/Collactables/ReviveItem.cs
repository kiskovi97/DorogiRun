using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveItem : Collactable
{
    protected override void TriggerFunction(Collider other)
    {
        PlayerData.reviveItemCount += 1;
    }
}
