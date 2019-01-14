using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class RuleSets : ScriptableObject
{
    [SerializeField]
    private RuleSet[] rules;

    private int prev = 0;

    public RuleSet NextRule
    {
        get
        {
            if (Random.value > 0.7f)
            {
                prev = (int)(Random.value * rules.Length);
            }
            return rules[prev];
        }
    }
}
