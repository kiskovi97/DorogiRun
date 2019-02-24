using System.Collections;
using UnityEngine;

public class RandomSideRule : SideRuleSet
{
    public override void Make()
    {
        int[] tomb = mapValues.SideSector();
        foreach (int value in tomb)
        {
            MovingObject obj = enviroment.GetSideObject();
            obj.side = true;
            obj.SetValues(mapValues, value);
            obj.transform.parent = parent;
            if (value > 0)
            {
                Vector3 scale = obj.transform.localScale;
                scale.x *= -1;
                obj.transform.localScale = scale;
            }
            obj.Update();
        }
    }

    public override IEnumerator MakeAll()
    {
        int[] tomb = mapValues.SideSector();
        for (float distance = mapValues.EndDistance; distance < mapValues.StartDistance; distance += length)
        {
            foreach (int value in tomb)
            {
                MovingObject obj = enviroment.GetSideObject();
                obj.side = true;
                obj.SetValues(mapValues, value);
                obj.transform.parent = parent;
                if (value > 0)
                {
                    Vector3 scale = obj.transform.localScale;
                    scale.x *= -1;
                    obj.transform.localScale = scale;
                }
                obj.SetDistance(distance);
                obj.Update();
            }
        }
        yield return null;
    }
}