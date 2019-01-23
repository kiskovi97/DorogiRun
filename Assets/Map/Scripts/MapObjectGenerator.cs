using UnityEngine;

[RequireComponent(typeof(MapMesh))]
public class MapObjectGenerator : MonoBehaviour
{
    private MapValues mapValues;
    public Enviroment enviroment;
    public RuleSets obstacleRules;
    public SideRuleSet sideRuleSet;
    private MapMesh mesh;
    public static float Speed = 5.0f;
    public float speed = 5.0f;
    public float sideObjectFrequency = 2.0f;
    public float destroyDistance = 60f;
    public float intensity = 1f;

    [SerializeField]
    private Gameover gameOver;

    // Start is called before the first frame update
    void Start()
    {
        Speed = speed;
        mesh = GetComponent<MapMesh>();
        mapValues = mesh.mapValues;
        NewRule();
        sideRuleSet.Set(mapValues, enviroment, transform);
        StartCoroutine(sideRuleSet.MakeAll());
        MakeSideObjects();
        if (gameOver != null)
            gameOver.continueGame += Continue;
    }

    private void Update()
    {
        mesh.UpdateAngle(Time.deltaTime * speed);
        if (Time.timeScale != 0)
        Time.timeScale += 0.001f * intensity * Time.unscaledDeltaTime;
    }

    void NewRule()
    {
        RuleSet ruleSet = obstacleRules.NextRule;
        float length = ruleSet.length;
        ruleSet.Set(mapValues, enviroment, transform);
        ruleSet.Make();
        Invoke("NewRule", length / speed);
    }

    void MakeSideObjects()
    {
        float length = sideRuleSet.length;
        sideRuleSet.Make();
        Invoke("MakeSideObjects", length / speed);
    }

    void Continue()
    {
        MovingObject[] objects = Object.FindObjectsOfType<MovingObject>();
        foreach(MovingObject obj in objects)
        {
            if (!obj.side && obj.Close(destroyDistance)) Destroy(obj.gameObject);
        }
    }
}
