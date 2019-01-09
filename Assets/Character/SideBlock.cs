using UnityEngine;

public class SideBlock : MonoBehaviour
{
    [SerializeField]
    private bool isRight;

    [SerializeField]
    private CharacterMovement charMovement;

    private int counter = 0;

    private void OnTriggerEnter(Collider other)
    {
        counter++;
        if (counter == 1)
        {
            charMovement.SetBlockLaneSide(isRight, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        counter--;
        if (counter == 0)
        {
            charMovement.SetBlockLaneSide(isRight, false);
        }
    }
}
