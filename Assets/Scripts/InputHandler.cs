using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


public class InputHandler : MonoBehaviour
{
   public int item;
    [SerializeField]
    Shift shift;
    public void OnSelect(InputAction.CallbackContext select)
    {
        //print(select.ToString());
        if (select.performed)
        {
            switch (select.action.name)
            {
                case "Item1":
                    item = 1;
                    break;
                case "Item2":
                    item = 2;
                    break;
                case "Item3":
                    item = 3;
                    break;
                case "Item4":
                    item = 4;
                    break;
            }
            shift.CompleteOrder();
            item = 0;
        }
    }
}
