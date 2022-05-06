using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerStateArriving : CustomerStateBase
{
    Transform targetToArrive;

    public CustomerStateArriving(CustomerStateManager context, Transform targetToArrive)
    {
        this.Context = context;
        this.targetToArrive = targetToArrive;
    }

    public override void EnterState()
    {
        this.Context.Animator.SetBool("IsWalking", true);
    }

    public override void ExitState()
    {
        
    }

    public override void AwakeState()
    {
        
    }

    public override void StartState()
    {
        
    }

    public override void UpdateState()
    {
        MoveToTarget();
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    void MoveToTarget()
    {
        Vector3 movementDirection = (targetToArrive.position - Context.transform.position).normalized;
        Context.gameObject.transform.Translate(movementDirection * Context.MovementSpeed * Time.deltaTime, Space.World);
        CheckTargetReached();
    }

    void CheckTargetReached()
    {
        float diffX = Mathf.Abs(targetToArrive.position.x - Context.transform.position.x);
        if(diffX < .1f)
        {
            this.Context.transform.position = targetToArrive.position;
            PotionItem selectedPotionItem = GameEvents.GetInstance().OnCustomerReachedSpot();
            this.Context.SetWaiting(selectedPotionItem);
        }
    }
}
