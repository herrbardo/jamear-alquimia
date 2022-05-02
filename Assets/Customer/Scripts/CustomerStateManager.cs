using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerStateManager : MonoBehaviour
{
    [SerializeField] public float MovementSpeed;
    [SerializeField] public Transform SpotToBuy;
    [SerializeField] public Animator Animator;
    [SerializeField] public SoundManager VoiceManager;
    CustomerStateBase currentState;

    public CustomerStateManager()
    {
        
    }

    private void Awake()
    {
        if(this.SpotToBuy != null)
            SetArriving();
    }

    void Start()
    {
        this.currentState.StartState();
    }

    
    void Update()
    {
        this.currentState.UpdateState();
    }

    public void SetState(CustomerStateBase newState)
    {
        if(this.currentState != null)
            this.currentState.ExitState();
        
        this.currentState = newState;
        this.currentState.EnterState();
    }

    public void SetArriving()
    {
        SetState(new CustomerStateArriving(this, SpotToBuy));
    }

    public void SetWaiting()
    {
        SetState(new CustomerStateWaiting(this));
    }
}
