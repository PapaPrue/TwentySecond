using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalManager : MonoBehaviour
{
    public static UniversalManager instance{ get; private set; }
    public byte gameType;


    // Start is called before the first frame update
    void Awake()
    {
        if( instance != null && instance != this)
        {
            Destroy(instance);
        }
        instance= this;
        DontDestroyOnLoad(gameObject);
    }

    
}
