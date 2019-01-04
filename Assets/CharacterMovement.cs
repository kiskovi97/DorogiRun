using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float time;

    [SerializeField]
    private float distanceBetweenLanes;

    [SerializeField]
    private float jumpPower;

    [SerializeField]
    private Position lane = Position.Mid;

    private Rigidbody rigidBody;

    private bool inMove = false;
    private float speed;
    private float direction;
    private float movementTimer;
    private float aimPositionX;

    private enum Position
    {
        Right, Mid, Left
    }

    void Start()
    {
        speed = distanceBetweenLanes / time;
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputCheck();

        if (inMove)
        {
            if (movementTimer - Time.deltaTime > 0)
            {
                transform.position = transform.position + new Vector3(speed, 0, 0) * Time.deltaTime * direction;
                movementTimer -= Time.deltaTime;
            }
            else
            {
                transform.position = new Vector3(aimPositionX, transform.position.y, transform.position.z);
                inMove = false;
            }
        }
    }

    private void MoveLeft()
    {
        if(lane == Position.Left)
        {
            return;
        }
        if(lane == Position.Mid)
        {
            lane = Position.Left;
        }
        else
        {
            lane = Position.Mid;
        }
        StartMovement(Position.Left);
    }

    private void MoveRight()
    {
        if (lane == Position.Right)
        {
            return;
        }
        if (lane == Position.Mid)
        {
            lane = Position.Right;
        }
        else
        {
            lane = Position.Mid;
        }
        StartMovement(Position.Right);
    }

    private void StartMovement(Position direction)
    {
        inMove = true;
        movementTimer = time;
        aimPositionX = transform.position.x;

        if (direction == Position.Left)
        {
            this.direction = -1;
            aimPositionX -= distanceBetweenLanes;
        }
        else if(direction == Position.Right)
        {
            this.direction = 1;
            aimPositionX += distanceBetweenLanes;
        }
        else
        {
            this.direction = 0;
        }
    }

    private void Jump()
    {
        if (rigidBody.velocity.y == 0)
        {
            rigidBody.velocity = new Vector3(0, jumpPower, 0);
        }
    }

    private void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (inMove)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
    }
}
