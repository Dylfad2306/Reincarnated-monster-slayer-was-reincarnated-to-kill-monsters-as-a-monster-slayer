using UnityEngine;

namespace player
{
    public class playerAnimationController : MonoBehaviour
    {
        Animator animator;
        float velocityZ = 0.0f;
        float velocityX = 0.0f;
        public bool readyToAttack;
        public float acceleration = 2.0f;
        public float deceleration = 2.0f;
        public float maximumWalkVelocity = 0.5f;
        public float maximumRunVelocity = 2.0f;

        int velocityZHash;
        int velocityXHash;
        int readyToAttackHash;
        int attackAnimationHash;

        public string GreatSwordSlash;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();

            velocityZHash = Animator.StringToHash("velocity Z");
            velocityXHash = Animator.StringToHash("velocity X");
            readyToAttackHash = Animator.StringToHash("readyToAttack");

            // Convert the attack animation state name to a hash for faster comparison
            attackAnimationHash = Animator.StringToHash(GreatSwordSlash);
        }

        void changeVelocity(bool forwardpressed, bool BackwardPressed, bool leftPressed, bool rightPressed, bool runPressed, float currentMaxVelocity)
        {
            if (forwardpressed && velocityZ < currentMaxVelocity)
            {
                velocityZ += Time.deltaTime * acceleration;
            }

            if (BackwardPressed && velocityZ > -currentMaxVelocity)
            {
                velocityZ -= Time.deltaTime * acceleration;
            }

            if (leftPressed && velocityX > -currentMaxVelocity)
            {
                velocityX -= Time.deltaTime * acceleration;
            }

            if (rightPressed && velocityX < currentMaxVelocity)
            {
                velocityX += Time.deltaTime * acceleration;
            }

            if (!BackwardPressed && velocityZ < 0.0f)
            {
                velocityZ += Time.deltaTime * deceleration;
            }

            if (!leftPressed && velocityX < 0.0f)
            {
                velocityX += Time.deltaTime * deceleration;
            }

            if (!rightPressed && velocityX > 0.0f)
            {
                velocityX -= Time.deltaTime * deceleration;
            }
        }

        void lockOrResetVelocity(bool forwardpressed, bool BackwardPressed, bool leftPressed, bool rightPressed, bool runPressed, float currentMaxVelocity)
        {
            if (!forwardpressed && velocityZ > 0.0f)
            {
                velocityZ -= Time.deltaTime * deceleration;
            }

            if (!forwardpressed && velocityZ < -0.2f)
            {
                velocityZ = -0.2f;
            }

            if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f))
            {
                velocityX = 0.0f;
            }

            if (forwardpressed && runPressed && velocityZ > currentMaxVelocity)
            {
                velocityZ = currentMaxVelocity;
            }

            else if (forwardpressed && velocityZ > currentMaxVelocity)
            {
                velocityZ -= Time.deltaTime * deceleration;

                if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05f))
                {
                    velocityZ = currentMaxVelocity;
                }
            }
            else if (forwardpressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
            {
                velocityZ = currentMaxVelocity;
            }

            if (leftPressed && runPressed && velocityZ < -currentMaxVelocity)
            {
                velocityZ = -currentMaxVelocity;
            }

            else if (leftPressed && velocityZ < -currentMaxVelocity)
            {
                velocityZ += Time.deltaTime * deceleration;

                if (velocityZ < -currentMaxVelocity && velocityZ > (-currentMaxVelocity - 0.05f))
                {
                    velocityZ = -currentMaxVelocity;
                }
            }
            else if (leftPressed && velocityZ > -currentMaxVelocity && velocityZ < (-currentMaxVelocity + 0.05f))
            {
                velocityZ = -currentMaxVelocity;
            }

            if (rightPressed && runPressed && velocityZ > currentMaxVelocity)
            {
                velocityZ = currentMaxVelocity;
            }

            else if (rightPressed && velocityZ > currentMaxVelocity)
            {
                velocityZ -= Time.deltaTime * deceleration;

                if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05f))
                {
                    velocityZ = currentMaxVelocity;
                }
            }
            else if (rightPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
            {
                velocityZ = currentMaxVelocity;
            }
        }

        void attackAnimationFunction(bool leftClick)
        {
            if (leftClick)
            {
                readyToAttack = true;
            }
        }

    
        // Update is called once per frame
        void Update()
        {
            bool forwardpressed = Input.GetKey(KeyCode.W);
            bool leftPressed = Input.GetKey(KeyCode.A);
            bool BackwardPressed = Input.GetKey(KeyCode.S);
            bool rightPressed = Input.GetKey(KeyCode.D);
            bool runPressed = Input.GetKey(KeyCode.LeftShift);
            bool leftClick = Input.GetKey(KeyCode.Mouse0);

            float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity;

            changeVelocity(forwardpressed, BackwardPressed, leftPressed, rightPressed, runPressed, currentMaxVelocity);
            lockOrResetVelocity(forwardpressed, BackwardPressed, leftPressed, rightPressed, runPressed, currentMaxVelocity);
            attackAnimationFunction(leftClick);

            animator.SetFloat(velocityZHash, velocityZ);
            animator.SetFloat(velocityXHash, velocityX);
            //animator.SetBool(readyToAttackHash, readyToAttack);
        }
        
        public void InitateAttack()
        {
            animator.SetBool(readyToAttackHash, true);
        }
        public void EndAttack()
        {
            animator.SetBool(readyToAttackHash, false);
        }
    }
}
