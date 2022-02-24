using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isLeftHash;
    int isRightHash;
    int isBackwardsHash;

    // Start is called before the first frame update
    void Start()
    {
        //reference animator and convert strings to hash 
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRightHash = Animator.StringToHash("isRight");
        isLeftHash = Animator.StringToHash("isLeft");
        isBackwardsHash = Animator.StringToHash("isBackwards");
    }

    // Update is called once per frame
    void Update()
    {
        //create bool variable for each animation state
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRight = animator.GetBool(isRightHash);
        bool isLeft = animator.GetBool(isLeftHash);
        bool isBackwards = animator.GetBool(isBackwardsHash);

        //create bool variable for each input key state
        bool isForwardPressed = Input.GetKey("w");
        bool isLeftPressed = Input.GetKey("a");
        bool isRightPressed = Input.GetKey("d");
        bool isBackwardsPressed = Input.GetKey("s");

        
        if (!isWalking && isForwardPressed)
        {
            //set isWalking to true if w is pressed
            animator.SetBool(isWalkingHash, true);    
        }

        if (isWalking && !isForwardPressed)
        {
            //set isWalking to false if w is not pressed
            animator.SetBool(isWalkingHash, false);
        }

        //check current state and key state for right strafe animation
        if (!isRight && isRightPressed)
        {
            //set all animations to stop apart from right strafe
            animator.SetBool(isBackwardsHash, false);
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isLeftHash, false);
            animator.SetBool(isRightHash, true);
        }

        //check current state and key state for right strafe animation
        if (isRight && !isRightPressed)
        {
            animator.SetBool(isRightHash, false);
        }

        //check current state and key state for left strafe animation
        if (!isLeft && isLeftPressed)
        {
            //set all animations to stop apart from left strafe
            animator.SetBool(isBackwardsHash, false);
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isRightHash, false);
            animator.SetBool(isLeftHash, true);
        }

        //check current state and key state for left strafe animation
        if (isLeft && !isLeftPressed)
        {
            animator.SetBool(isLeftHash, false);
        }

        //check current state and key state for backwards animation
        if (!isBackwards && isBackwardsPressed)
        {
            //set all animations to stop apart from backwards 
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isLeftHash, false);
            animator.SetBool(isRightHash, false);
            animator.SetBool(isBackwardsHash, true);
        }

        //check for current state and key state
        if (isBackwards && !isBackwardsPressed)
        {
            animator.SetBool(isBackwardsHash, false);
        }
    }
}
