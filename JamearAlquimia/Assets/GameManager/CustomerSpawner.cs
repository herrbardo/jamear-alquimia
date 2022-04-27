using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] GameObject CustomerPrefab;
    [SerializeField] Transform SpotToBuy;

    void Start()
    {
        Invoke("SpawnCustomer", 2f);
    }

    
    void Update()
    {
        
    }

    void SpawnCustomer()
    {
        GameObject newCustomer = Instantiate(CustomerPrefab, this.transform.position, Quaternion.identity);
        CustomerStateManager manager = newCustomer.GetComponent<CustomerStateManager>();
        manager.SpotToBuy = this.SpotToBuy;
        manager.SetArriving();
    }
}
