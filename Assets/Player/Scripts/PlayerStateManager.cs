using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    [SerializeField] public float MovementSpeed;
    [SerializeField] List<Transform> Spots;
    [SerializeField] public Animator Animator;
    [SerializeField] public SpriteRenderer SpriteRenderer;
    [SerializeField] public AudioSource furnaceSoundEffect;

    public bool FacingRight { get; private set; }

    PlayerStateBase currentState;
    int currentSpotIndex;

    public PlayerStateManager()
    {
        currentState = new PlayerStateIdle(this);
        currentSpotIndex = 0;
        FacingRight = true;
    }

    private void Awake()
    {
        this.currentState.AwakeState();
        UIEvents.GetInstance().UIButtonPressed += Button_Click;
    }

    private void OnDestroy()
    {
        UIEvents.GetInstance().UIButtonPressed -= Button_Click;
    }
    
    void Start()
    {
        this.currentState.StartState();
    }

    void Update()
    {
        this.currentState.UpdateState();
    }

    void Button_Click(string buttonName)
    {
        if(buttonName == "BtnRight" && currentSpotIndex < (Spots.Count - 1 ))
        {
            currentSpotIndex++;
            FacingRight = true;
        }
        else if(buttonName == "BtnLeft" && currentSpotIndex > 0)
        {
            currentSpotIndex--;
            FacingRight = false;
        }

        Transform currentSpot = Spots[currentSpotIndex];
        SetState(new PlayerStateMoving(this, currentSpot));
        if (currentSpot.gameObject.name == "SpotHorno")
        {
            furnaceSoundEffect.Play();
        }
        else
        {
            furnaceSoundEffect.Stop();
        }

    }

    public void SetState(PlayerStateBase newState)
    {
        this.currentState.ExitState();
        this.currentState = newState;
        this.currentState.Context = this;
        this.currentState.EnterState();
    }

    public void SetIdle()
    {
        SetState(new PlayerStateIdle(this));
    }
}
