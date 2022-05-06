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

    private void OnCollisionEnter2D(Collision2D other)
    {
        this.currentState.OnCollisionEnter2D(other);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        this.currentState.OnTriggerEnter2D(other);
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

    public void SetWaiting(PotionItem potionItem)
    {
        SetState(new CustomerStateWaiting(this, potionItem));
    }

    public void SetLeaving()
    {
        SetState(new CustomerStateLeaving(this));
    }

    public void DestroyAnything(GameObject anything)
    {
        Destroy(anything);
    }
}
