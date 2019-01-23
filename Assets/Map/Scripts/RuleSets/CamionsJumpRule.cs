using UnityEngine;
using UnityEditor;

public class CamionsJumpRule : RuleSet
{
    public float minLength = 10f;
    public float overLap = 2f;

    public void Reset()
    {
        length = 50f;
    }

    public override void Make()
    {
        int max = mapValues.SectorNumber;
        if (max < 3) return;
        float distance = Ramp() - overLap;
        while (distance < length - 10f)
        {
            distance = Fork(distance) - overLap;
        }
    }

    private float Ramp()
    {
        MovingObject obj = NewRampObstacle(0, mapValues.StartDistance, minLength);
        MovingObject obj2 = NewRampObstacle(2, mapValues.StartDistance, minLength);
        return Mathf.Max(obj2.length, obj.length);
    }

    private float Fork(float distance)
    {
        MovingObject obj = NewBigObstacle(1, mapValues.StartDistance + distance, minLength);
        float moreDistance = obj.length + distance;
        if (moreDistance > length - 10f) return moreDistance;
        MovingObject obj2;
        if (Random.value > 0.5f) obj2 = NewBigObstacle(0, mapValues.StartDistance + moreDistance - overLap, minLength);
        else obj2 = NewBigObstacle(2, mapValues.StartDistance + moreDistance - overLap, minLength);
        moreDistance = moreDistance + obj2.length - overLap;
        return moreDistance;
    }
}