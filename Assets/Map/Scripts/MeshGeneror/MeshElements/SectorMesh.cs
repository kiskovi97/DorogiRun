using UnityEngine;

class SectorMesh : MeshElementImpl
{
    public SectorMesh(Vector3 right, Vector3 left, Curve curve, float angle, float resolution)
    {
        Vector3 prevRight = right + curve.GetCurvePoint(angle- resolution); 
        Vector3 prevLeft = left + curve.GetCurvePoint(angle- resolution);
        for (float i = angle; i < curve.startAngle; i+= resolution)
        {
            Vector3 curvePoint = curve.GetCurvePoint(i);
            shapes.Add(new RectangleShape(prevLeft, prevRight, left + curvePoint, right + curvePoint, 0));
            prevLeft = left + curvePoint;
            prevRight = right + curvePoint;
        }
    }
}
