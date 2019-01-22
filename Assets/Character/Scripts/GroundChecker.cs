using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private int count = 0;

    [SerializeField]
    private CharacterMovement characterMovement;

    private void OnTriggerEnter(Collider other)
    {
        Collactable script = other.GetComponent<Collactable>();
        if (script != null)
        {
            return;
        }
        count++;
        if(count == 1)
        {
            characterMovement.SetJump(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Collactable script = other.GetComponent<Collactable>();
        if (script != null)
        {
            return;
        }
        count--;
        if(count == 0)
        {
            characterMovement.SetJump(false);
        }
    }
}
