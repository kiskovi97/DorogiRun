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
    private LanePosition lane = LanePosition.Mid;

    [SerializeField]
    private float jumpVelocity = 0;

    private Rigidbody rigidBody;

    private bool inMove = false;
    private float speed;
    private float direction;
    private float movementTimer;
    private float aimPositionX;

    private bool rightBlocked = false;
    private bool leftBlocked = false;

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
        if(lane == LanePosition.Left || leftBlocked)
        {
            return;
        }
        if(lane == LanePosition.Mid)
        {
            lane = LanePosition.Left;
        }
        else
        {
            lane = LanePosition.Mid;
        }
        rightBlocked = false;
        StartMovement(LanePosition.Left);
    }

    private void MoveRight()
    {
        if (lane == LanePosition.Right || rightBlocked)
        {
            return;
        }
        if (lane == LanePosition.Mid)
        {
            lane = LanePosition.Right;
        }
        else
        {
            lane = LanePosition.Mid;
        }
        leftBlocked = false;
        StartMovement(LanePosition.Right);
    }

    private void StartMovement(LanePosition direction)
    {
        inMove = true;
        movementTimer = time;
        aimPositionX = transform.position.x;

        if (direction == LanePosition.Left)
        {
            this.direction = -1;
            aimPositionX -= distanceBetweenLanes;
        }
        else if(direction == LanePosition.Right)
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
        if (rigidBody.velocity.y > 0 - jumpVelocity || rigidBody.velocity.y < 0 + jumpVelocity)
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

    public void SetBlockLaneSide(bool isRight, bool blockState)
    {
        if (isRight)
        {
            rightBlocked = blockState;
        }
        else
        {
            leftBlocked = blockState;
        }
    }
}
