using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
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
    private Gameover gameOver;

    private Rigidbody rigidBody;

    private Animator animator;

    private bool inMove = false;
    private float speed;
    private float direction;
    private float movementTimer;
    private float aimPositionX;

    private bool rightBlocked = false;
    private bool leftBlocked = false;
    private bool canJump = true;

    private string lastAnimation;

    private string leftMoveAnimation = "Left";
    private string rightMoveAnimation = "Right";
    private string jumpStartAnimation = "Jump";
    private string jumpCycleAnimation = "JumpEnd";

    private Vector3 originalPosition;
    private LanePosition originalLane;

    void Start()
    {
        speed = distanceBetweenLanes / time;
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        gameOver.continueGame += Restart;
        originalPosition = transform.position;
        originalLane = lane;
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
                animator.SetBool(lastAnimation, false);
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
        animator.SetBool(rightMoveAnimation, true);
        lastAnimation = rightMoveAnimation;
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
        animator.SetBool(leftMoveAnimation, true);
        lastAnimation = leftMoveAnimation;
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
        if (canJump)
        {
            rigidBody.velocity = new Vector3(0, jumpPower, 0);
            animator.SetBool(jumpCycleAnimation, false);
            animator.SetBool(jumpStartAnimation, true);
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

    public void SetCanJump(bool state)
    {
        canJump = state;
        if (state && animator.GetBool(jumpStartAnimation))
        {
            animator.SetBool(jumpStartAnimation, false);
            animator.SetBool(jumpCycleAnimation, true);
        }
    }

    public void Restart()
    {
        transform.position = originalPosition;
        lane = originalLane;
    }
}
