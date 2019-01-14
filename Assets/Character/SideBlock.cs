using UnityEngine;

public class SideBlock : MonoBehaviour
{
    [SerializeField]
    private SideType side;

    [SerializeField]
    private CharacterMovement charMovement;

    public int counter = 0;
    private bool isRight = false;

    private enum SideType
    {
        Left, Right, Ground
    }

    private void Start()
    {
        if (side == SideType.Right)
        {
            isRight = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        counter++;
        if (counter == 1)
        {
            if(side == SideType.Ground)
            {
                charMovement.SetCanJump(true);
            }
            else
            {
                charMovement.SetBlockLaneSide(isRight, true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        counter--;
        if (counter == 0)
        {
            if(side == SideType.Ground)
            {
                charMovement.SetCanJump(false);
            }
            else
            {
                charMovement.SetBlockLaneSide(isRight, false);
            }
        }
    }
}
