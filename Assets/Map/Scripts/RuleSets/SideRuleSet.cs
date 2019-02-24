using UnityEngine;
using UnityEditor;
using System.Collections;

public abstract class SideRuleSet : RuleSet
{
    public abstract IEnumerator MakeAll();
}