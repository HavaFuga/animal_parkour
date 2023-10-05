using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationManager : MonoBehaviour
{
    private static string currentState;

    private void Update()
    {
        
    }

    public static void ChangeAnimation(Animator animator, string newState)
    {
        // stop animation from interrupting itself
        if (currentState == newState) return;
        
        // play animation 
        animator.Play(newState);
        
        // reassign current State
        currentState = newState;
    }
    
    public static void OneShotAnimation(Animator animator, string newState)
    {
        string oldState;
        // stop animation from interrupting itself
        if (currentState == newState) return;
        
        // play animation 
        animator.PlayInFixedTime(newState);
        
        // reassign current State
        currentState = newState;
    }
}
