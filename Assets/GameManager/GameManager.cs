using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] float DelayToStart;
    [SerializeField] public bool EnableCheats;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
