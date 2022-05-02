using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerStateWaiting : CustomerStateBase
{
    public CustomerStateWaiting(CustomerStateManager context)
    {
        this.Context = context;
    }

    public override void EnterState()
    {
        this.Context.Animator.SetBool("IsWalking", false);
        this.Context.VoiceManager.PlayRandomClip();
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
        
    }
}
