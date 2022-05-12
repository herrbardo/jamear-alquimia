using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerStateWaiting : CustomerStateBase
{
    PotionItem potionItem;

    public CustomerStateWaiting(CustomerStateManager context, PotionItem potionItem)
    {
        this.Context = context;
        this.potionItem = potionItem;
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

    public override void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Potion")
        {
            PotionScript potionScript = other.gameObject.GetComponent<PotionScript>();
            if(potionScript != null)
            {
                string name = ConvertName(this.potionItem.Type);
                //TODO ARREGLAR ESTO!!
                // if(potionScript.potionType == name)
                // {       
                //     this.Context.DestroyAnything(other.gameObject);
                //     GameEvents.GetInstance().OnRequestNewCustomer();
                //     this.Context.SetLeaving();
                // }
                // else
                // {
                //     this.Context.VoiceManager.PlayRandomClip();
                // }
            }
        }
    }

    string ConvertName(Potions potion)
    {
        switch(potion)
        {
            case Potions.Health:
                return "Healing";
            
            default:
                return potion.ToString();
        }
    }
}
