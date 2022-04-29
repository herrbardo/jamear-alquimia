using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMoving : PlayerStateBase
{
    Transform targetToMove;

    public PlayerStateMoving(PlayerStateManager context, Transform target)
    {
        this.Context = context;
        this.targetToMove = target;
    }

    public override void EnterState()
    {
        this.Context.Animator.SetBool("IsWalking", true);
        this.Context.SpriteRenderer.flipX = !this.Context.FacingRight;
    }

    public override void ExitState()
    {
        this.Context.Animator.SetBool("IsWalking", false);
    }


    public override void AwakeState(){}
    public override void StartState(){}

    public override void UpdateState()
    {
        Move();
    }

    void Move()
    {
        Vector3 movementDirection = (targetToMove.position - Context.transform.position).normalized;
        Context.gameObject.transform.Translate(movementDirection * Context.MovementSpeed * Time.deltaTime, Space.World);
        CheckTargetReached();
    }

    void CheckTargetReached()
    {
        float diffX = Mathf.Abs(targetToMove.position.x - Context.transform.position.x);
        if(diffX < .1f)
        {
            this.Context.transform.position = targetToMove.position;
            this.Context.SetIdle();
        }
    }
}
