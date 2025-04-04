using UnityEngine;

namespace player
{
    public class PlayerMove : MonoBehaviour
    {
        [Header("Movement")]
        private float movespeed;
        public float walkspeed;
        public float sprintSpeed;

        public float groundDrag;

        [Header("Jumping")]
        public float jumpForce;
        public float jumpCooldown;
        public float airMultiplier;
        bool readyToJump;

        [Header("Crouching")]
        public float crouchSpeed;
        public float crouchYScale;
        private float startYScale;

        [Header("KeyBinds")]
        public KeyCode jumpKey = KeyCode.Space;
        public KeyCode sprintKey = KeyCode.LeftShift;
        public KeyCode crouchKey = KeyCode.LeftControl;

        [Header("Ground Check")]
        public float playerHeight;
        public LayerMask whatIsGround;
        bool grounded;

        [Header("Slope Handling")]
        public float maxSlopeAngle;
        private RaycastHit slopeHit;
        private bool exitingSlope;

        public Transform orientation;

        float horizantalInput;
        float verticalInput;

        Vector3 movedirection;

        Rigidbody rb;

        public MovementState state;
        public enum MovementState
        {
            walking,
            sprinting,
            crouching,
            air
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody> ();
            rb.freezeRotation = true;

            readyToJump = true;

            startYScale = transform.localScale.y;
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void Update()
        {
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight* 0.5f + 0.2f, whatIsGround);

            MyInput();
            SpeedControl();
            StateHandler();

            if (grounded)
                rb.drag = groundDrag;
            else
                rb.drag = 0;
        }

        private void MyInput()
        {
            horizantalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            if (Input.GetKey(jumpKey) && readyToJump && grounded)
            {
                readyToJump = false;

                Jump();

                Invoke(nameof(ResetJump), jumpCooldown);
            }

            if (Input.GetKeyDown(crouchKey))
            {
                transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
                rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            }

            if (Input.GetKeyUp(crouchKey))
            {
                transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
            }
        }

        private void StateHandler()
        {
            if (Input.GetKeyUp(crouchKey))
            {
                state = MovementState.crouching;
                movespeed = crouchSpeed;
            }
            if (grounded && Input.GetKey(sprintKey))
            {
                state = MovementState.sprinting;
                movespeed = sprintSpeed;
            }

            else if (grounded)
            {
                state = MovementState.walking;
                movespeed = walkspeed;
            }

            else
            {
                state = MovementState.air;
            }
        }

        private void MovePlayer()
        {
            movedirection = orientation.forward * verticalInput + orientation.right * horizantalInput;

            if (onSlope() && !exitingSlope)
            {
                rb.AddForce(GetSlopeMoveDirection() * 20f, ForceMode.Force);

                if (rb.velocity.y > 0)
                {
                    rb.AddForce(Vector3.down * 80f, ForceMode.Force);
                }
            }

            if (grounded)
                rb.AddForce(movedirection.normalized * movespeed * 10f, ForceMode.Force);
            else if (!grounded)
            {
                rb.AddForce(movedirection.normalized * movespeed * 10f * airMultiplier, ForceMode.Force);
            }

            rb.useGravity = !onSlope();
        }

        private void SpeedControl()
        {
            if(onSlope() && !exitingSlope)
            {
                if (rb.velocity.magnitude > movespeed)
                {
                    rb.velocity = rb.velocity.normalized * movespeed;
                }
            }

            else
            {
                Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

                if (flatVel.magnitude > movespeed)
                {
                    Vector3 limitedVel = flatVel.normalized * movespeed;
                    rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
                }
            }
        }

        private void Jump()
        {
            exitingSlope = true;

            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        private void ResetJump()
        {
            readyToJump = true;

            exitingSlope = false;
        }

        private bool onSlope()
        {
            if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
            {
                float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
                return angle < maxSlopeAngle && angle != 0;
            }

            return false;
        }

        private Vector3 GetSlopeMoveDirection()
        {
            return Vector3.ProjectOnPlane(movedirection, slopeHit.normal).normalized;
        }
    }
}
