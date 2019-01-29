using UnityEngine;

public class ShieldItem : Collactable
{
    protected override void TriggerFunction(Collider other)
    {
        CharacterItems characterItems = other.GetComponent<CharacterItems>();
        if (characterItems == null)
        {
            return;
        }
        characterItems.ShieldActivate();
    }
}
