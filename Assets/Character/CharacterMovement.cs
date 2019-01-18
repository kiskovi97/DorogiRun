using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Lane settings")]
    [SerializeField]
    private float timeBetweenLaneChanging;

    [SerializeField]
    private float distanceBetweenLanes;

    [SerializeField]
    private LanePosition lane = LanePosition.Mid;

    [Header("Jump")]
    [SerializeField]
    private float jumpPower;

    [Header("Run setting")]
    [SerializeField]
    private float speedToOriginalPosition;

    [Header("Dependencies")]
    [SerializeField]
    private Gameover gameOver;

    private Rigidbody rigidBody;

    private Animator animator;

    private bool inMove = false;
    private float speedBetweenLanes;
    private float directionBetweenLanes;
    private float timeForGoOtherLane;
    private float aimPositionX;

    private bool rightBlocked = false;
    private bool leftBlocked = false;
    private bool canJump = true;

    private string lastAnimation;

    private string leftMoveAnimation = "Left";
    private string rightMoveAnimation = "Right";
    private string jumpStartAnimation = "Jump";
    private string jumpCycleAnimation = "JumpEnd";

    private Vector3 swipeStart;

    private Vector3 originalPosition;
    private LanePosition originalLane;

    void Start()
    {
        speedBetweenLanes = distanceBetweenLanes / timeBetweenLaneChanging;
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        gameOver.continueGame += Restart;
        originalPosition = transform.position;
        originalLane = lane;
        aimPositionX = originalPosition.x;
    }

    private void Update()
    {
        InputCheck();

        LaneMove();

        PositionCheck();
    }

    private void MoveLeft()
    {
        if (inMove)
        {
            return;
        }
        if (lane == LanePosition.Left || leftBlocked)
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

        directionBetweenLanes = -1;
        aimPositionX -= distanceBetweenLanes;

        StartMovement();

        animator.SetBool(rightMoveAnimation, true);
        lastAnimation = rightMoveAnimation;
    }

    private void MoveRight()
    {
        if (inMove)
        {
            return;
        }
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
        directionBetweenLanes = 1;
        aimPositionX += distanceBetweenLanes;

        StartMovement();

        animator.SetBool(leftMoveAnimation, true);
        lastAnimation = leftMoveAnimation;
    }

    private void StartMovement()
    {
        inMove = true;
        timeForGoOtherLane = timeBetweenLaneChanging;
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
        if (Input.GetMouseButtonDown(0))
        {
            swipeStart = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            SwipeDirection swipeDirection = DirectionCalculating();
            Move(swipeDirection);
        }

        //For testing
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

    private void Move(SwipeDirection swipe)
    {
        switch (swipe)
        {
            case SwipeDirection.Left:
                MoveLeft();
                break;
            case SwipeDirection.Right:
                MoveRight();
                break;
            case SwipeDirection.Up:
                Jump();
                break;
            default:
                break;
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

    private void Restart()
    {
        transform.position = originalPosition;
        lane = originalLane;
    }

    private void LaneMove()
    {
        if (inMove)
        {
            if (timeForGoOtherLane - Time.deltaTime > 0)
            {
                transform.position = transform.position + new Vector3(speedBetweenLanes, 0, 0) * Time.deltaTime * directionBetweenLanes;
                timeForGoOtherLane -= Time.deltaTime;
            }
            else
            {
                transform.position = new Vector3(aimPositionX, transform.position.y, transform.position.z);
                inMove = false;
                animator.SetBool(lastAnimation, false);
            }
        }
    }

    private void PositionCheck()
    {
        if (!inMove)
        {
            if(aimPositionX != transform.position.x)
            {
                rigidBody.MovePosition(new Vector3(aimPositionX, transform.position.y, transform.position.z));
            }
        }

        if(transform.position.z != originalPosition.z)
        {
            int direction;
            if (originalPosition.z > transform.position.z)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            if (Mathf.Abs(transform.position.z - originalPosition.z) <= speedToOriginalPosition * Time.deltaTime)
            {
                rigidBody.MovePosition(new Vector3(transform.position.x, transform.position.y, originalPosition.z));
            }
            else
            {
                rigidBody.MovePosition(transform.position + new Vector3(0, 0, direction * speedToOriginalPosition * Time.deltaTime));
            }
        }
    }

    private SwipeDirection DirectionCalculating()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        //Left or Right swipe
        if(Mathf.Abs(swipeStart.x - x) >= Mathf.Abs(swipeStart.y - y))
        {
            if(swipeStart.x > x)
            { 
                return SwipeDirection.Left;
            }
            else if (swipeStart.x < x)
            {
                return SwipeDirection.Right;
            }
        }
        else
        {
            if (swipeStart.y > y)
            {
                return SwipeDirection.Down;
            }
            else if (swipeStart.y < y)
            {
                return SwipeDirection.Up;
            }
        }
        return SwipeDirection.Touch;
    }

    private enum SwipeDirection
    {
        Left, Up, Right, Down, Touch
    }
}
