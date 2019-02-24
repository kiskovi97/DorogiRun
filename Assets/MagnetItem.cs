using UnityEngine;

public class MagnetItem : Collactable
{
    protected override void TriggerFunction(Collider other)
    {
        CharacterItems characterItems = other.GetComponent<CharacterItems>();
        if (characterItems == null)
        {
            return;
        }
        characterItems.ActivateMagnet();
    }
}
