using UnityEngine;

public class RandomSideRule : SideRuleSet
{
    public override void Make(float speed)
    {
        int[] tomb = mapValues.SideSector();
        foreach (int value in tomb)
        {
            MovingObject obj = enviroment.GetSideObject();
            obj.SetValues(mapValues, value, speed);
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

    public override void MakeAll(float speed)
    {
        int[] tomb = mapValues.SideSector();
        foreach (int value in tomb)
        {
            for (float distance = mapValues.StartDistance; distance > mapValues.EndDistance; distance -= length)
            {
                MovingObject obj = enviroment.GetSideObject();
                obj.SetValues(mapValues, value, speed);
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
    }
}