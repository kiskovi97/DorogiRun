using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collactable
{
    private bool inAttract = false;
    private Transform aimTransform;

    [SerializeField]
    private float attractSpeed = 5;

    protected override void TriggerFunction(Collider other)
    {
        PlayerData.actualCoin += 1;
    }

    public void MagnetAttract(Transform aim)
    {
        inAttract = true;
        aimTransform = aim;
    }

    public override void Update()
    {
        if (!inAttract)
        {
            base.Update();
        }
        else
        {
            Vector3 aimPosition = aimTransform.position - transform.position;
            transform.position += aimPosition * Time.deltaTime * attractSpeed;
        }
    }
}
