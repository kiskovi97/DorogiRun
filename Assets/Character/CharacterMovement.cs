using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Lane settings")]
    [SerializeField]
    private float timeBetweenLaneChanging;

    [SerializeField]
    private float distanceBetweenLanes; //TODO: Ask it 

    [SerializeField]
    private LanePosition lane = LanePosition.Mid;

    [Header("Jump")]
    [SerializeField]
    private float jumpPower;

    [Header("UI")]
    [SerializeField]
    private GameObject continueQuestion;

    [Header("Dependecy")]
    [SerializeField]
    private Gameover gameOver;

    private Rigidbody rigidBody;

    private Animator animator;

    private bool inMove = false;
    private ChangingDirection directionBetweenLanes;
    private float aimPositionX;

    private bool canJump = true;

    private string lastAnimation;

    private string leftMoveAnimation = "Left";
    private string rightMoveAnimation = "Right";
    private string jumpStartAnimation = "Jump";
    private string jumpCycleAnimation = "JumpEnd";

    private Vector3 swipeStart;

    private Vector3 originalPosition;

    private bool sideBlock = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        gameOver.continueGame += Restart;
        originalPosition = transform.position;
        aimPositionX = originalPosition.x;
    }

    private void Update()
    {
        InputCheck();
    }

    private void InputCheck()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                swipeStart = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                SwipeDirection swipeDirection = DirectionCalculating(touch.position);
                Move(swipeDirection);
            }
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    swipeStart = Input.mousePosition;
        //}
        //else if (Input.GetMouseButtonUp(0))
        //{
        //    SwipeDirection swipeDirection = DirectionCalculating();
        //    Move(swipeDirection);
        //}

        //For testing (windows)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (inMove)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }

    private void Restart()
    {
        transform.position = new Vector3(aimPositionX, originalPosition.y, originalPosition.z);
        continueQuestion.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.GetContact(0).normal;

        int x = Convert.ToInt32(normal.x);
        int y = Convert.ToInt32(normal.y);
        int z = Convert.ToInt32(normal.z);

        //Side
        if (y == 0 && z == 0 && (x == 1 || x == -1))
        {
            sideBlock = true;
        }
        // Something hit him
        else if (y == 0 && x == 0 && z == -1)
        {
            continueQuestion.SetActive(true);
            Time.timeScale = 0;
        }
        //Ground or rampa hit
        else
        {
            canJump = true;
            animator.SetBool(jumpCycleAnimation, true);
            animator.SetBool(jumpStartAnimation, false);
        }
    }

    #region Move part

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

    private void MoveLeft()
    {
        if (inMove)
        {
            return;
        }
        if (lane == LanePosition.Left)
        {
            return;
        }
        if (lane == LanePosition.Mid)
        {
            lane = LanePosition.Left;
        }
        else
        {
            lane = LanePosition.Mid;
        }

        directionBetweenLanes = ChangingDirection.Left;
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
        if (lane == LanePosition.Right)
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
        directionBetweenLanes = ChangingDirection.Right;
        aimPositionX += distanceBetweenLanes;

        StartMovement();

        animator.SetBool(leftMoveAnimation, true);
        lastAnimation = leftMoveAnimation;
    }

    private void StartMovement()
    {
        inMove = true;
        StartCoroutine(MoveToPosition());
    }

    private void Jump()
    {
        if (canJump)
        {
            rigidBody.velocity = new Vector3(0, jumpPower, 0);
            animator.SetBool(jumpCycleAnimation, false);
            animator.SetBool(jumpStartAnimation, true);
            canJump = false;
        }
    }

    private IEnumerator MoveToPosition()
    {
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            if (sideBlock)
            {
                t = 1 - t;
                aimPositionX = currentPos.x;
                currentPos = transform.position;
                CanceledLaneSwitch();
                sideBlock = false;
            }
            t += Time.deltaTime / timeBetweenLaneChanging;
            rigidBody.MovePosition(Vector3.Lerp(currentPos, new Vector3(aimPositionX, transform.position.y, transform.position.z), t));
            yield return null;
        }
        inMove = false;
        animator.SetBool(lastAnimation, false);
    }

    private void CanceledLaneSwitch()
    {
        if (directionBetweenLanes == ChangingDirection.Left)
        {
            if (lane == LanePosition.Left)
            {
                lane = LanePosition.Mid;
            }
            else
            {
                lane = LanePosition.Right;
            }
        }
        else
        {
            if (lane == LanePosition.Right)
            {
                lane = LanePosition.Mid;
            }
            else
            {
                lane = LanePosition.Left;
            }
        }
    }

    private enum ChangingDirection
    {
        Right, Left
    }

    #endregion

    #region Swipe

    private SwipeDirection DirectionCalculating(Vector3 position)
    {
        float x = position.x;
        float y = position.y;

        //Left or Right swipe
        if (Mathf.Abs(swipeStart.x - x) >= Mathf.Abs(swipeStart.y - y))
        {
            if (swipeStart.x > x)
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
    #endregion
}
