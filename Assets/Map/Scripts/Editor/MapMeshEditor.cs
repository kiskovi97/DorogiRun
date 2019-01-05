using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(MapMesh))]
public class MapMeshEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MapMesh obj = (MapMesh)target;

        if (GUILayout.Button("ReGenerate"))
        {
            obj.ReGenerate();
        }
    }
}
