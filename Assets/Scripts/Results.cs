using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI shiftsCleared;
    [SerializeField]
    TextMeshProUGUI CustomersServed;
    [SerializeField]
    TextMeshProUGUI GameMode;

    private void Start()
    {
        
        shiftsCleared.SetText("Shifts Completed: " + StatHolder.instance.shiftsCleared);
        CustomersServed.SetText("Customers Served: " +StatHolder.instance.customersServed);
        switch(StatHolder.instance.mode)
        {
            case 0:
                GameMode.SetText("Part Time");
                break;
            case 1:
                GameMode.SetText("Full Time");
                break;
            case 2:
                GameMode.SetText("All you can eat");
                    break;
             default:
                break;
            
        }

    }
}
