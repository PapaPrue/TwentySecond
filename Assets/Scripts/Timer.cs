using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI timeText;
    [SerializeField]
    float time=20;
    byte x;
   public bool timeUp;
    public delegate void TimeEvent();
    public static event TimeEvent TimeUp;
    public Shift shift;
    public bool playing;
   

    // Update is called once per frame
    public IEnumerator Countdown()
    {
        playing = false;
        for (float i = 0; i <= time; i++)
        {
            yield return Yielders.Get(1);
            timeText.SetText("" +(time-i));
            if(i>=14)
            {
                if (shift.customerQuota > shift.customerFulfilled||shift.satisfaction<=25)
                {
                    if (shift.musicHandler.source.clip != shift.musicHandler.sounds[2])
                    {
                        shift.musicHandler.source.clip = shift.musicHandler.sounds[2];
                        shift.musicHandler.source.Play();
                        playing = true;
                    }
                    
                }
                else
                {
                    if (shift.musicHandler.source.clip != shift.musicHandler.sounds[1])
                    {
                        shift.musicHandler.source.clip = shift.musicHandler.sounds[1];
                        shift.musicHandler.source.Play();
                        playing = false;
                    }
                    
                }

            }
            
            //Debug.Log(i);
        }
        if(shift.satisfaction>0)
            shift.EndShift();
    }
    public void ResetTimer()
    {
        timeUp = false;
        time = 20;
        Countdown();
    }
}
