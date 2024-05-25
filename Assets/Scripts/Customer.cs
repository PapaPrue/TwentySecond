using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Customer : MonoBehaviour
{
    public bool glutton;
    public bool HealthInspector;
    public bool forgetful;
    public Sprite[] foods;
    public Sprite[] customerSprites;

    public Shift shift;
    
    int randomCust;
    public int number;
    public int number2;
    public SpriteRenderer bubble;
    public bool firstOrdServed;
   
    public GameObject holder;
    public Animator anim;
    public AnimatorOverrideController[] animOver;

    // Start is called before the first frame update
    public void Tart()
    {
        GetComponent<SpriteRenderer>().sprite = null;
        firstOrdServed = false;
        glutton= false;
        HealthInspector= false;
        forgetful= false;
        number = Random.Range(1, 5);
        if (shift.regularRush)
        {
           
            randomCust = Random.Range(0, 6);
            
            switch(randomCust)
            {
                case 0:
                    GetComponent<SpriteRenderer>().sprite = customerSprites[0];
                    anim.runtimeAnimatorController = animOver[0];
                    break;
                case 1:
                    GetComponent<SpriteRenderer>().sprite = customerSprites[1];
                    anim.runtimeAnimatorController= animOver[1];
                    break;
                case 2:
                    GetComponent<SpriteRenderer>().sprite = customerSprites[2];
                    glutton = true;
                    number2 = Random.Range(1, 5);
                    anim.runtimeAnimatorController = animOver[2];
                    break;
                case 3:
                    GetComponent<SpriteRenderer>().sprite = customerSprites[3];
                    glutton = true;
                    number2 = Random.Range(1, 5);
                    anim.runtimeAnimatorController = animOver[3];
                    break;
                case 4:
                    GetComponent<SpriteRenderer>().sprite = customerSprites[4];
                    anim.runtimeAnimatorController = animOver[4];
                    HealthInspector = true;
                    break;
                case 5:
                    GetComponent<SpriteRenderer>().sprite = customerSprites[5];
                    anim.runtimeAnimatorController = animOver[5];
                    HealthInspector = true;
                    break;
                default:
                    break;

            }

        }
       else if(shift.fatCatRush)
        {

            randomCust = Random.Range(2, 4);
            GetComponent<SpriteRenderer>().sprite = customerSprites[randomCust];
            anim.runtimeAnimatorController = animOver[randomCust];
            number2 = Random.Range(1, 5);
            glutton = true;
        }

        else if(shift.inspectorRush)
        {
            randomCust= Random.Range(4, 6);
            GetComponent<SpriteRenderer>().sprite = customerSprites[randomCust];
            anim.runtimeAnimatorController = animOver[randomCust];
            HealthInspector = true;
           
        }
        if(shift.takeout)
        {
            randomCust = Random.Range(6, 8);
            GetComponent<SpriteRenderer>().sprite = customerSprites[number2];
            anim.runtimeAnimatorController = animOver[randomCust];
        }
      
        
        bubble.sprite = foods[number-1];
        


    }
    private void OnDisable()
    {
        GetComponent<SpriteRenderer>().sprite = null;
        firstOrdServed = false;
        glutton = false;
        HealthInspector = false;
        forgetful = false;
    }
    public void Clear()
    {
        GetComponent<SpriteRenderer>().sprite = null;
        anim.runtimeAnimatorController= null;
        firstOrdServed = false;
        glutton = false;
        HealthInspector = false;
        forgetful = false;
    }
}
