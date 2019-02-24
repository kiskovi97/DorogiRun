using UnityEngine;

class MapGenerator : GeneratorImpl
{
    public MapGenerator(MapValues mapValues, float distance, float resolution)
    {
        Vector3 farLeft = - mapValues.right.normalized * mapValues.sectorSize * (mapValues.sectorNumber / 2.0f);
        for (int i=0; i < mapValues.sectorNumber; i++)
        {
            Vector3 currentLeft = farLeft + mapValues.right.normalized * mapValues.sectorSize * i;
            Vector3 currentRight = farLeft + mapValues.right.normalized * mapValues.sectorSize * (i + 1f);
            meshElements.Add(new SectorMesh(currentLeft, currentRight, mapValues.curve, distance, resolution));
        }
    }
}