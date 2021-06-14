using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonMovement : MonoBehaviour
{
    #region Platform Code

    public Transform activePlatform;

    Vector3 moveDirection;
    Vector3 activeGlobalPlatformPoint;
    Vector3 activeLocalPlatformPoint;
    Quaternion activeGlobalPlatformRotation;
    Quaternion activeLocalPlatformRotation;

    #endregion

    [SerializeField] private Respawning respawnManager;
    [SerializeField] public CharacterController controller;
    [SerializeField] private Transform cam;
    [SerializeField] private Image crossHairImage;

    [Header("Movement")]

    [SerializeField] private float startSpeed = 24f;
    public float speed;
    [SerializeField] private float smoothTurnTime = 0.2f;
    private float turnSmoothVelocity;


    [Header("Jumping")]
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] public float startJumpHeight = 3f;
    public float jumpHeight;
    Vector3 velocity;
    public Vector3 characterVelocityMomentum;
    [SerializeField] private Transform groundCheck;
    private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    bool isGrounded;

    [Header("Grappling Hook")]
    [SerializeField] private LayerMask whatIsHookable;
    [SerializeField] private Transform hookShotTransform;
    private Vector3 hookShotPosition;
    private float hookShotSize;
    [SerializeField] private float minThrowDis = 30f;
    public float maxThrowDis = 400f;

    private State state;
    public bool isTalkingToSomeone;
    private enum State
    {
        Normal,
        HookShotThrow,
        HookShotFlyingPlayer,
        FirstPerson
    }
    void Start()
    {
        cam = Camera.main.transform;
        controller = GetComponent<CharacterController>();
        respawnManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Respawning>();

        groundCheck = transform.Find("Ground Check");

        Cursor.lockState = CursorLockMode.Locked;
        state = State.Normal;

        DisableHookShot(false);
        ChangeCrossHairColor(Color.black);
        jumpHeight = startJumpHeight;
        speed = startSpeed;
    }
    void Update()
    {
        switch (state)
        {
            case State.Normal:
                CharacterController();
                UsingWhip();
                break;
            case State.HookShotThrow:
                CharacterController();
                HookShotThrow();
                break;
            case State.HookShotFlyingPlayer:
                HookShotMovement();
                break;
            case State.FirstPerson:
                CharacterController();
                break;
            default:
                break;
        }
    }

    void LateUpdate()
    {
        if (activePlatform != null)
        {
            Vector3 newGlobalPlatformPoint = activePlatform.TransformPoint(activeLocalPlatformPoint);
            moveDirection = newGlobalPlatformPoint - activeGlobalPlatformPoint;
            if (moveDirection.magnitude > 0.01f)
            {
                controller.Move(moveDirection);
            }
            if (activePlatform)
            {
                // Support moving platform rotation
                Quaternion newGlobalPlatformRotation = activePlatform.rotation * activeLocalPlatformRotation;
                Quaternion rotationDiff = newGlobalPlatformRotation * Quaternion.Inverse(activeGlobalPlatformRotation);
                // Prevent rotation of the local up vector
                rotationDiff = Quaternion.FromToRotation(rotationDiff * Vector3.up, Vector3.up) * rotationDiff;
                transform.rotation = rotationDiff * transform.rotation;
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

                UpdateMovingPlatform();
            }
        }
        else
        {
            if (moveDirection.magnitude > 0.01f)
            {
                moveDirection = Vector3.Lerp(moveDirection, Vector3.zero, Time.deltaTime);
                controller.Move(moveDirection);
            }
        }
    }

    private bool TestInputDownHookShot()
    {
        return Input.GetButtonDown("Fire1");
    }
    private bool TestInputJump()
    {
        return Input.GetButtonDown("Jump");
    }

    private void ChangeCrossHairColor(Color color)
    {
        color.a = 0.6f;
        crossHairImage.color = color;
    }

    private void UsingWhip()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hit, maxThrowDis, whatIsHookable))
        {

            if (Vector3.Distance(transform.position, hit.point) >= minThrowDis)
            {
                ChangeCrossHairColor(Color.green);
                if (TestInputDownHookShot())
                {
                    hookShotPosition = hit.point;

                    float targetAngle = Mathf.Atan2(hit.point.x - transform.position.x, hit.point.z - transform.position.z) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
                    DisableHookShot(true);
                    if (!isTalkingToSomeone)
                    {
                        state = State.HookShotThrow;
                    }
                }
            }
            else
            {
                ChangeCrossHairColor(Color.black);
            }

        }
        else
        {
            ChangeCrossHairColor(Color.black);
        }
    }

    private void HookShotThrow()
    {
        ChangeCrossHairColor(Color.black);
        hookShotTransform.LookAt(hookShotPosition);
        float hookShotSpeed = 250f;
        hookShotSize += hookShotSpeed * Time.deltaTime;
        hookShotTransform.localScale = new Vector3(1, 1, hookShotSize);


        if (hookShotSize >= Vector3.Distance(transform.position, hookShotPosition))
        {
            float targetAngle = Mathf.Atan2(hookShotPosition.x - transform.position.x, hookShotPosition.z - transform.position.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            state = State.HookShotFlyingPlayer;
        }
    }

    private void HookShotMovement()
    {
        hookShotTransform.LookAt(hookShotPosition);
        hookShotTransform.localScale = new Vector3(1, 1, Vector3.Distance(hookShotTransform.position, hookShotPosition));

        Vector3 hookShotDir = (hookShotPosition - transform.position).normalized;

        float minSpeed = 40f;
        float maxSpeed = 43f;
        float hookShotSpeed = Mathf.Clamp(Vector3.Distance(transform.position, hookShotPosition), minSpeed, maxSpeed); //tentar com slerp
        //float hookShotSpeed = Vector3.Slerp(transform.position, hookShotPosition, 1f);    this isn't working cause i can't convert from Vector3 to float
        float hookShotSpeedMultiplier = 2f;
        controller.Move(hookShotDir * hookShotSpeed * hookShotSpeedMultiplier * Time.deltaTime);

        float reachedHookShotPosition = 2f;
        if (Vector3.Distance(transform.position, hookShotPosition) <= reachedHookShotPosition)
        {
            state = State.Normal;
            ResetGravity();
            DisableHookShot(false);
        }

        if (TestInputJump())
        {
            float extraMomentum = 5f;
            float extraHeight = 10f;
            characterVelocityMomentum = (hookShotDir * hookShotSpeed * extraMomentum);
            characterVelocityMomentum += Vector3.up * extraHeight;
            state = State.Normal;
            ResetGravity();
            DisableHookShot(false);
        }
    }

    private void DisableHookShot(bool isBeingUsed)
    {
        hookShotSize = 0;
        hookShotTransform.gameObject.SetActive(isBeingUsed);
        hookShotTransform.localScale = new Vector3(1, 1, hookShotSize);
    }

    private void ResetGravity()
    {
        velocity.y = 2f;
    }

    void CharacterController()
    {
        if (state == State.FirstPerson)
        {
            speed = (startSpeed / 2f);
        }
        if (state == State.Normal)
        {
            speed = startSpeed;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (!isTalkingToSomeone)
        {
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTurnTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;



                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -20f;
        }

        if (TestInputJump() && isGrounded)
        {
            Jump();
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (characterVelocityMomentum.magnitude > 0f)
        {
            controller.Move(characterVelocityMomentum * Time.deltaTime);

            float momentumDrag = 3f;

            if (!isGrounded)
            {
                characterVelocityMomentum -= characterVelocityMomentum * momentumDrag * Time.deltaTime;
            }
            else if (isGrounded)
            {
                characterVelocityMomentum -= characterVelocityMomentum * momentumDrag * 3 * Time.deltaTime;
            }

            if (characterVelocityMomentum.magnitude < .1f)
            {
                characterVelocityMomentum = Vector3.zero;
            }
        }
    }

    public void GravityStop()
    {
        velocity.y = 2f;
    }

    public void SwitchState()
    {
        if (state == State.FirstPerson)
        {
            state = State.Normal;
        }
        else if (state == State.Normal)
        {
            state = State.FirstPerson;
        }
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity = Vector3.up + velocity;

        if (activePlatform)
        {
            activePlatform = null;
        }
    }

    public void Die()
    {
        DisableHookShot(false);
        characterVelocityMomentum = Vector3.zero;
        state = State.Normal;
        respawnManager.RespawnSystem();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Jump Pad")
        {
            jumpHeight = hit.gameObject.GetComponent<ChangeMushColor>().jumpHeight;
            Jump();
            jumpHeight = startJumpHeight;
        }

        #region Platform Collision
        // Make sure we are really standing on a straight platform *NEW*
        // Not on the underside of one and not falling down from it either!
        if (hit.moveDirection.y < -0.9 && hit.normal.y > 0.41 && hit.collider.transform.CompareTag("MovingPlatform"))
        {
            if (activePlatform != hit.collider.transform)
            {
                activePlatform = hit.collider.transform;
                UpdateMovingPlatform();
            }
        }
        else
        {
            activePlatform = null;
        }

        #endregion
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxThrowDis);
    }

    #region UpdatePlatforming
    void UpdateMovingPlatform()
    {
        activeGlobalPlatformPoint = transform.position;
        activeLocalPlatformPoint = activePlatform.InverseTransformPoint(transform.position);
        // Support moving platform rotation
        activeGlobalPlatformRotation = transform.rotation;
        activeLocalPlatformRotation = Quaternion.Inverse(activePlatform.rotation) * transform.rotation;
    }

    #endregion
}
