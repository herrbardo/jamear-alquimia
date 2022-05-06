using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerStateLeaving : CustomerStateBase
{
    public CustomerStateLeaving(CustomerStateManager context)
    {
        this.Context = context;
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
        Context.gameObject.transform.Translate(Vector3.right * Context.MovementSpeed * Time.deltaTime, Space.World);
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
