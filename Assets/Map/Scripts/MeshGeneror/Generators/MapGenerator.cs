using System.Collections.Generic;
using UnityEngine;

class MapGenerator : GeneratorImpl
{
    public MapGenerator(MapValues mapValues)
    {
        Vector3 basePoint = mapValues.basePoint - mapValues.right.normalized * mapValues.sectorSize * (mapValues.sectorNumber / 2.0f);
        for (int i=0; i < mapValues.sectorNumber; i++)
        {
            Vector3 left = basePoint + mapValues.right.normalized * mapValues.sectorSize * i;
            Vector3 right = basePoint + mapValues.right.normalized * mapValues.sectorSize * (i + 0.9f);
            meshElements.Add(new SectorMesh(left, right, mapValues.forward, mapValues.R));
        }
    }
}