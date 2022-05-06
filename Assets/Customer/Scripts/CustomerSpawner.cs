using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] GameObject CustomerPrefab;
    [SerializeField] Transform SpotToBuy;
    [SerializeField] float DelayToStart;

    private void Awake()
    {
        GameEvents.GetInstance().RequestNewCustomer += SpawnCustomer;
    }

    private void OnDestroy()
    {
        GameEvents.GetInstance().RequestNewCustomer -= SpawnCustomer;
    }

    void Start()
    {
        Invoke("SpawnCustomer", DelayToStart);
    }

    
    void Update()
    {
        
    }

    public void SpawnCustomer()
    {
        GameObject newCustomer = Instantiate(CustomerPrefab, this.transform.position, Quaternion.identity);
        CustomerStateManager manager = newCustomer.GetComponent<CustomerStateManager>();
        manager.SpotToBuy = this.SpotToBuy;
        manager.SetArriving();
    }
}
