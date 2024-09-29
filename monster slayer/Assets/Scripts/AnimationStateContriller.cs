using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateContriller : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);

        bool forwardpressed = Input.GetKey("w");
        bool runForwardPressed = Input.GetKey("left shift");

        if (!isWalking && forwardpressed)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && !forwardpressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (forwardpressed && runForwardPressed))
        {
            animator.SetBool(isRunningHash, true);
        }
        if (isRunning && (!forwardpressed || !runForwardPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}
