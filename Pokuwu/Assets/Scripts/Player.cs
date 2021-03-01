using System;
using Mirror;
using UnityEngine;

public class Player : Character
{
    
    public Animator animator;

    public override void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        animator.GetComponent<Animator>();
        direction = Direction.South;
    }
    
    private void SetAnimationStatus()
    {
       
        animator.SetFloat("idleDirection",
            direction == Direction.South ? 0f : 
            direction == Direction.North ? 1f:   
            direction == Direction.East ? 0.66f:    
            0.33f); 
        
        animator.SetFloat("xMove",_movement.MoveVector.x);
        animator.SetFloat("yMove",_movement.MoveVector.y);
        animator.SetBool("isMoving", Mathf.Abs(_movement.MoveVector.x) > 0f || Mathf.Abs(_movement.MoveVector.y) > 0f );
        animator.SetBool("isRunning",_movement.MoveVector.z >0);
        
    }


    public override void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        _movement.Move(this);
        SetAnimationStatus();
    }
}
