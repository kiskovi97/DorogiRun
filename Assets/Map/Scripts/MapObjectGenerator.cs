using UnityEngine;

[RequireComponent(typeof(MapMesh))]
public class MapObjectGenerator : MonoBehaviour
{
    private MapValues mapValues;
    public Enviroment enviroment;
    public RuleSets ruleSets;
    public SideRuleSet sideRuleSet;
    private MapMesh mesh;
    public float speed = 5.0f;
    public float sideObjectFrequency = 2.0f;
    public float objectGeneratingFrequency = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MapMesh>();
        mapValues = mesh.mapValues;
        NewRule();
        sideRuleSet.Set(mapValues, enviroment, transform);
        sideRuleSet.MakeAll(speed);
        Invoke("MakeSideObjects", sideObjectFrequency / speed);
    }

    private void Update()
    {
        mesh.UpdateAngle(Time.deltaTime * speed);
    }

    void NewRule()
    {
        RuleSet ruleSet = ruleSets.ruleSet;
        float length = ruleSet.length;
        ruleSet.Set(mapValues, enviroment, transform);
        ruleSet.Make(speed);
        Invoke("NewRule", length / speed);
    }

    void MakeSideObjects()
    {
        float length = sideRuleSet.length;
        sideRuleSet.Make(speed);
        Invoke("MakeSideObjects", length / speed);
    }
}
