using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CustomerPool : MonoBehaviour
{
    public static CustomerPool instance;
    public List<Customer> items;
    public Customer customerToPool;
    public int amountToPool;
    void Awake()
    {
        items = new List<Customer>();
        Customer temp;

        for (int i = 0; i < amountToPool; i++)
        {
            temp = Instantiate(customerToPool);
            temp.gameObject.SetActive(false);
            //temp.GetComponent<SpriteRenderer>().enabled= false;
            items.Add(temp);
           


        }
    }
}
