using UnityEngine;

class SectorMesh : MeshElementImpl
{
    public SectorMesh(Vector3 right, Vector3 left, Curve curve, float distance, float resolution)
    {
        Vector3 prevRight = right + curve.GetPointByDistance(distance - resolution); 
        Vector3 prevLeft = left + curve.GetPointByDistance(distance - resolution);
        for (float i = distance; i < curve.StartDistance; i+= resolution)
        {
            Vector3 curvePoint = curve.GetPointByDistance(i);
            shapes.Add(new RectangleShape(prevLeft, prevRight, left + curvePoint, right + curvePoint, 0));
            prevLeft = left + curvePoint;
            prevRight = right + curvePoint;
        }
    }
}
