using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Timer timer;
    public bool gameClear;
    //public byte strikes;
    //float orderInterval;
    public float CustomerSatisfaction;
    

    private void OnEnable()
    {
        Timer.TimeUp += GameCheck;
    }
    private void OnDisable()
    {
        Timer.TimeUp -= GameCheck;
    }
    


    void GameCheck()
    {
        if (gameClear)
            print("");//LoadNextScene
    }

}
