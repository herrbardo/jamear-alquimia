using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomerStateBase
{
    public CustomerStateManager Context{ get; set;}

    public abstract void EnterState();
    public abstract void ExitState();


    public abstract void AwakeState();
    public abstract void StartState();
    public abstract void UpdateState();
}
