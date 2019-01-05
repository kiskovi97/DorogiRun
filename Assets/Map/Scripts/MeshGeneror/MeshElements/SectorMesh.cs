using UnityEngine;

class SectorMesh : MeshElementImpl
{
    public SectorMesh(Vector3 right, Vector3 left, Curve curve)
    {
        Vector3 prevRight = right; 
        Vector3 prevLeft = left;
        for (float i=0.5f; i < curve.startAngle; i+=0.5f)
        {
            Vector3 curvePoint = curve.GetCurvePoint(i);
            shapes.Add(new RectangleShape(prevLeft, prevRight, left + curvePoint, right + curvePoint, 0));
            prevLeft = left + curvePoint;
            prevRight = right + curvePoint;
        }
    }
}
