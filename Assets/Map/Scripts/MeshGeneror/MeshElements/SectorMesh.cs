using UnityEngine;

class SectorMesh : MeshElementImpl
{
    public SectorMesh(Vector3 right, Vector3 left, Vector3 forward, float R)
    {
        Vector3 up = new Vector3(0, 1, 0);
        Vector3 prevRight = right; 
        Vector3 prevLeft = left;
        for (float i=2; i < 30; i+=2)
        {
            float angle = i / 180 * 3.14f;
            float height = R * Mathf.Cos(angle) - R;
            float length = R * Mathf.Sin(angle);

            shapes.Add(new RectangleShape(prevLeft, prevRight, left + up * height + forward.normalized * length, right + up * height + forward.normalized * length, 0));
            prevLeft = left + up * height + forward.normalized * length;
            prevRight = right + up * height + forward.normalized * length;
        }
    }
}
