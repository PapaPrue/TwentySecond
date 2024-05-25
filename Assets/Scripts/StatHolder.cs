using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHolder : MonoBehaviour
{
    public static StatHolder instance { get; private set; }
    public int shiftsCleared;
    public int customersServed;
    public byte mode;
    private void Awake()
    {
        if(instance!=null&&instance!=this)
        {
            Destroy(instance);
        }
        instance= this;
        DontDestroyOnLoad(gameObject);
        mode = UniversalManager.instance.gameType;
    }

}
