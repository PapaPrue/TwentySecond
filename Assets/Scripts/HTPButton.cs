using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTPButton : MonoBehaviour
{
    [SerializeField]
    GameObject[] objectToEnable;
    [SerializeField]
    GameObject[] objectToDisable;
   public void OnClick()
    {
        if (objectToEnable.Length > 0)
        {
            for (int i = 0; i < objectToEnable.Length; i++)
            {
                objectToEnable[i].SetActive(true);
            }
        }
        if(objectToDisable.Length > 0)
        {
            for(int i=0;i<objectToDisable.Length;i++)
            {
                objectToDisable[i].SetActive(false);
            }
        }
    }
}
