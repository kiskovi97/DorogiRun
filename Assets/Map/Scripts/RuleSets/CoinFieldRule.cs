using UnityEngine;
using UnityEditor;

public class CoinFieldRule : RuleSet
{
    public float minLength = 10f;

    public override void Make()
    {
        for (int i=0; i<mapValues.SectorNumber; i++)
        {
            if (i == (mapValues.SectorNumber / 2)) Coins(i, minLength);
            else
            {
                if (Random.value > 0.9f)
                {
                    MovingObject obj = NewCollactable(i, mapValues.StartDistance);
                    if (obj == null) CoinLine(i);
                }
                else
                {
                    CoinLine(i);
                }
            }
            
        }
    }
}