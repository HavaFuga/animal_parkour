using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationManager : MonoBehaviour
{
    private static string currentState;

    public static void ChangeAnimation(Animator animator, string newState)
    {
        // stop animation from interrupting itself
        if (currentState == newState) return;
        
        // play animation 
        animator.Play(newState);
        
        // reassign current State
        currentState = newState;
    }
}
