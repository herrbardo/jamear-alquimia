using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle: PlayerStateBase
{
    public PlayerStateIdle(PlayerStateManager context)
    {
        this.Context = context;
    }

    public override void EnterState()
    {
        this.Context.SpriteRenderer.flipX = false;
    }

    public override void ExitState(){}


    public override void AwakeState(){}
    public override void StartState(){}
    public override void UpdateState(){}
}
