using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void PlayIdle()
    {
        animator.Play("Idle");
    }

    public void PlayRun_Forward()
    {
        animator.Play("RunForward");
        Debug.Log("RunForward");
    }

    public void PlayRun_Backward()
    {
        animator.Play("RunBackward");
        Debug.Log("RunBackward");
    }

    public void PlayRun_BackwardLeft()
    {
        animator.Play("RunBackwardLeft"); //TODO check wrong names

        Debug.Log("RunBackwardLeft");
    }

    public void PlayRun_BackwardRight()
    {
        animator.Play("RunBackwardRight"); //TODO check wrong names
        Debug.Log("RunBackwardRight");
    }

    public void PlayRun_Right()
    {
        animator.Play("RunLeft"); //TODO check wrong names
        Debug.Log("RunLeft");
    }

    public void PlayRun_Left()
    {
        animator.Play("RunRight"); //TODO check wrong names
        Debug.Log("RunRight");
    }

    public void PlayStrafe_Left()
    {
        animator.Play("StrafeLeft");
        Debug.Log("StrafeLeft");
    }
    public void PlayStrafe_Right()
    {
        animator.Play("StrafeRight");
        Debug.Log("StrafeRight");
    }
}
