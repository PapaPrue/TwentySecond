using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Rendering;
using UnityEngine.Animations;

public class Shift : MonoBehaviour
{

    public static Shift instance;

    // Start is called before the first frame update
    public Manager manager;
    [SerializeField]
    float BreakTime;
    bool gameStarted;


    [SerializeField]
    TextMeshProUGUI AlertText;
    [SerializeField]
    GameObject[] AlertUI; 
    [SerializeField]
    TextMeshProUGUI QuotaText;
    [SerializeField]
    TextMeshProUGUI ShiftText;
    [SerializeField]
    TextMeshProUGUI SetupTimer;


    bool lunchRush;
    Queue<Customer> customerQueue;
    Queue<Customer> servedQueue;

    public CustomerPool customerPool;
    bool shiftStillGoing;
    int rand;
    bool shiftClear;
    [HideInInspector]
    public byte customerQuota;
    [HideInInspector]
    public byte customerFulfilled;
    public float satisfaction;
    int roundNo;
    public InputHandler input;
    bool win;



    int shiftsCleared;
    [SerializeField]
    int maxShifts;

    [SerializeField]
    Transform centerPoint;
    [SerializeField]
    Transform secondPoint;
    [SerializeField]
    Transform thirdPoint;
    [SerializeField]
    Transform initialPoint;
    [SerializeField]
    Animator anim2;
    
    

    int shiftVariant;
    public bool regularRush;
    public bool fatCatRush;
    public bool inspectorRush;
    public bool takeout;
    bool setup;
    [SerializeField]
    GameObject background;
    [SerializeField]
    Image[] foodSprites;
    [SerializeField]
    Sprite takeoutBag;
    [SerializeField]
    Sprite forgetSprite;
    [HideInInspector]
    public int TotalServed;
    public int TotalShifts;
    [SerializeField]
    Animator anim;
    [SerializeField]
    SceneLoader loader;
    [SerializeField]
    StatHolder statHolder;

    [SerializeField]
    TextAsset txt;
    string[] lines;

    [SerializeField]
    AudioManager audman;
    [SerializeField]
    public AudioManager musicHandler;

    private void Start()
    {
        musicHandler.source.clip = musicHandler.sounds[0];
        musicHandler.source.Play();
        lines = txt.text.Split('\n');
       

        //anim.Play("FadeOut",0,5);
        //anim.speed = -1;
        anim2.enabled= false;
       
        if(UniversalManager.instance!= null) 
        {
           
            if(UniversalManager.instance.gameType==0)
            {
                maxShifts = 1;
                //customerQuota = 12;
            }
           else if (UniversalManager.instance.gameType == 1)
            {
                maxShifts = 3;
                //customerQuota = 15;
            }
           else if (UniversalManager.instance.gameType == 2)
            {
                maxShifts = 9999;
                //customerQuota = 15;
            }

        }
        //anim.enabled = false;
        TotalServed = 0;
        background.GetComponent<Animator>().StopPlayback();
        shiftsCleared = 0;
        customerQueue= new Queue<Customer>();
        servedQueue = new Queue<Customer>();
        ShiftText.SetText(""+ shiftsCleared + "/" + maxShifts);
        // inputs= new PlayerInputActions();
        StartCoroutine(ShiftBreak());
      
    }
    private void OnEnable()
    {
     //   Timer.TimeUp += EndShift();
    }
    private void OnDisable()
    {
        //Timer.TimeUp -= EndShift();
    }


    public IEnumerator ShiftBreak()
    {
       
        SetupTimer.enabled = true;
        customerFulfilled = 0;
        win = false;
        //anim.speed = -1;
        
        for(int i=0;i<foodSprites.Length;i++)
        {
            foodSprites[i].sprite = customerPool.items[i].foods[i];
        }
      
       if(servedQueue.Count>0)
            servedQueue.Clear();
        rand = Random.Range(0, 6);
        shiftClear = false;
        shiftStillGoing = false;
        satisfaction = 100;
        yield return Yielders.Get(.3f);
        background.GetComponent<Animator>().enabled=false;
        regularRush = false;
        fatCatRush= false;
        inspectorRush= false;
        takeout = false;
        //background.GetComponent<Animator>().speed = 1;
        for (int i = 0; i < AlertUI.Length; i++)
        {
            AlertUI[i].SetActive(false);
           
        }
        switch(rand)
        {
            case 1:
                fatCatRush = true;
                break;
            case 2:
                inspectorRush= true;
                break;
            case 3:
                takeout = true;
                background.GetComponent<Animator>().enabled=true;
                //background.GetComponent<Animator>().StartPlayback();
                break;
            default:
                regularRush = true;
                break;
        }
        if (TotalShifts == 0)
        {
            customerQuota = 18;
            if(fatCatRush)
            {
                customerQuota = 11;
            }
        }
        else if (TotalShifts == 1)
        {
            customerQuota = 20;
            if(fatCatRush)
            {
                customerQuota = 13;
            }
        }
        else if (TotalShifts >= 2)
        {
            customerQuota = 22;
            if(fatCatRush)
            {
                customerQuota = 15;
            }
        }
        else if (TotalShifts >= 5)
        {
            customerQuota = 25;
            if(fatCatRush)
            {
                customerQuota = 18;
            }
        }
        QuotaText.SetText("" + customerFulfilled + "/" + customerQuota);

        for (float i=0;i<BreakTime;i++)
        {
            SetupTimer.SetText(10-i+"");
            yield return Yielders.Get(.75f);
           
           
            gameStarted = false;
            if(i==BreakTime/2)
            {
               
                for (int j = 0; j < AlertUI.Length; j++)
                {
                    AlertUI[j].SetActive(true);
                    AlertText.SetText("");
                }

                if (regularRush)
                {
                    
                    StartCoroutine(Test(lines[0]));
                }
                else if(fatCatRush)
                {
                    StartCoroutine(Test(lines[1]));

                }
                else if(inspectorRush)
                {
                    StartCoroutine(Test(lines[2]));

                }
                else if(takeout)
                {
                    for (int j = 0; j < foodSprites.Length; j++)
                    {
                        foodSprites[j].sprite = takeoutBag;
                    }
                    StartCoroutine(Test(lines[3]));

                    background.GetComponent<Animator>().enabled = true;
                    background.GetComponent<Animator>().speed= 1;
                }
                
                //AlertText.SetText("Hey, this is a test run");
                for (int j = 0; j < customerPool.items.Count; j++)
                {
                    customerPool.items[j].shift = this;
                    customerPool.items[j].bubble.enabled = true;
                    customerQueue.Enqueue(customerPool.items[j]);
                    //customerQueue.ElementAt(0).gameObject.transform.position=centerPoint.position;
                }
               
               
            }
        }
       
        for (int k = 0; k < 5; k++)
        {
          customerQueue.ElementAt(k).gameObject.SetActive(true);
          customerQueue.ElementAt(k).Tart();
            if (k > 0)
                customerQueue.ElementAt(k).holder.SetActive(false);
          customerQueue.ElementAt(k).gameObject.transform.position = initialPoint.transform.position;


        }
       
        setup = true;

        gameStarted = true;
        //customerQueue.ElementAt(0).anim.Play("AngryWalk");
        StartShift();
    }
  

    public void StartShift()
    {
        audman.source.clip = audman.sounds[5];
        audman.source.Play();
        customerQueue.ElementAt(0).holder.SetActive(true);
        customerQueue.ElementAt(0).anim.Play("Talk");
        musicHandler.source.clip = musicHandler.sounds[1];
        musicHandler.source.Play();
        SetupTimer.enabled = false;
        for (int i = 0; i < AlertUI.Length; i++)
        {
            AlertUI[i].SetActive(false);
        }
        shiftStillGoing = true;
        StartCoroutine(manager.timer.Countdown());
        //AlertText.SetText("");
       
    }
    IEnumerator Test(string x)
    {
       
       foreach(char c in x)
       {
            AlertText.SetText(AlertText.text += c);
            audman.source.clip=audman.sounds[0];
            audman.source.Play();
            yield return Yielders.Get(.015f);
        }
        audman.source.Stop();
       
    }


    public void CompleteOrder()
    {
        //print(customerQueue.ElementAt(0));
        if (!shiftStillGoing)
            return;
        if (input.item == 0)
            return;
        if (!customerQueue.ElementAt(0).glutton)
        {
            if (input.item == customerQueue.ElementAt(0).number)
            {
                customerQueue.ElementAt(0).holder.SetActive(false);
                customerQueue.ElementAt(0).anim.Play("HappyWalk");

            }
            else
            {
                customerQueue.ElementAt(0).anim.Play("AngryWalk");
                customerQueue.ElementAt(0).holder.SetActive(false);
            }
            servedQueue.Enqueue(customerQueue.ElementAt(0));
            //customerQueue.Dequeue();
        }
        
        if (input.item == customerQueue.ElementAt(0).number)
        {
           
        audman.source.clip = audman.sounds[1];
        audman.source.Play();
            if(customerQueue.ElementAt(0).glutton)
            {
                if (!customerQueue.ElementAt(0).firstOrdServed)
                {
                   
                    customerQueue.ElementAt(0).firstOrdServed = true;
                    customerQueue.ElementAt(0).number = customerQueue.ElementAt(0).number2;
                    customerQueue.ElementAt(0).bubble.sprite = customerQueue.ElementAt(0).foods[customerQueue.ElementAt(0).number-1];
                    return;
                }
                else
                {
                    customerQueue.ElementAt(0).anim.Play("HappyWalk");
                    customerQueue.ElementAt(0).holder.SetActive(false);
                    servedQueue.Enqueue(customerQueue.ElementAt(0));
                    
                  
                }
            }
           
            //customerQueue.ElementAt(0).gameObject.SetActive(false);
            customerQueue.Dequeue();
            satisfaction += 5;
            if (satisfaction > 100)
                satisfaction = 100;
            TotalServed++;
            customerFulfilled++;
            QuotaText.SetText("" + customerFulfilled + "/" + customerQuota);
        }
        else
        {
            audman.source.clip = audman.sounds[2];
            audman.source.Play();
            customerQueue.ElementAt(0).holder.SetActive(false);
            customerQueue.ElementAt(0).anim.Play("AngryWalk");
            if (customerQueue.ElementAt(0).glutton)
                servedQueue.Enqueue(customerQueue.ElementAt(0));
            //customerQueue.ElementAt(0).gameObject.SetActive(false);
            if (!customerQueue.ElementAt(0).HealthInspector)
                satisfaction -= 10;
            else
                satisfaction -= 22;
            customerQueue.Dequeue();
            
           
           
        }
        customerQueue.ElementAt(0).holder.SetActive(true);
        customerQueue.ElementAt(0).anim.Play("Talk");
        customerQueue.ElementAt(4).gameObject.SetActive(true);
        customerQueue.ElementAt(4).enabled=true;
        customerQueue.ElementAt(4).Tart();
        customerQueue.ElementAt(4).holder.SetActive(false);
        customerQueue.ElementAt(4).gameObject.transform.position = initialPoint.position;
       
    }
    
    public void EndShift()
    {
        
        shiftStillGoing= false;

        if (customerFulfilled >= customerQuota) win = true;
        else
            win = false;
        if (satisfaction <= 0) win = false;
        if (win == true)
        {
           

            shiftClear = true;
            shiftsCleared++;
            TotalShifts++;
            ShiftText.SetText("" +shiftsCleared +"/" + maxShifts);
            for(int i=0;i<customerQueue.Count;i++)
            {
                servedQueue.Enqueue(customerQueue.ElementAt(i));
                servedQueue.ElementAt(i).enabled = false;
            }
            
            customerQueue.Clear();
            if (shiftsCleared == maxShifts)
            {
                StartCoroutine(clearGame());
                return;
            }
            else
            {
                audman.source.clip = audman.sounds[6];
                audman.source.Play();
                musicHandler.source.clip = musicHandler.sounds[0];
                musicHandler.source.Play();
                background.GetComponent<Animator>().speed=-1;
                StartCoroutine(Transition());
                //background.GetComponent<Animator>().StartPlayback();
                //ShiftBreak();
            }
        }
        else
        {
            
            customerQueue.Clear();
            shiftClear = false;
            anim.enabled = true;
            StartCoroutine(gameOver());
            //AlertText.SetText("That's A Wrap!");
        }
       
    }
    IEnumerator gameOver()
    {
        musicHandler.source.Stop();
        audman.source.clip = audman.sounds[3];
        audman.source.Play();
        for(int i=0;i<customerPool.items.Count;i++)
        {
            customerPool.items[i].gameObject.SetActive(false);
        }
        loader.onCall();
        yield return Yielders.Get(2f);
        for(int i=0;i<AlertUI.Length;i++)
        {
            AlertUI[i].gameObject.SetActive(true);
        }
        AlertText.SetText("");
        StartCoroutine(Test(lines[5]));
       
        statHolder.shiftsCleared = TotalShifts;
        statHolder.customersServed = TotalServed;
        yield return Yielders.Get(2f);
        StartCoroutine(loader.Load());
    }


    float second;
    float second2;
    IEnumerator clearGame()
    {
        SetupTimer.enabled = true;
        SetupTimer.SetText("Clear!");
        musicHandler.source.Stop();
        musicHandler.source.loop= false;
        musicHandler.source.clip = audman.sounds[4];
        musicHandler.source.Play();
        audman.source.Play();
        yield return Yielders.Get(3f);
        for(int i=0;i<AlertUI.Length;i++)
        {
            AlertUI[i].SetActive(true);
        }
        AlertText.SetText("");
        StartCoroutine(Test(lines[6]));
        statHolder.shiftsCleared = TotalShifts;
        statHolder.customersServed = TotalServed;
        yield return Yielders.Get(3f);
        for(int i=0;i<AlertUI.Length;i++)
        {
            AlertUI[i].SetActive(false);
        }
        loader.onCall();
        StartCoroutine(loader.Load());


    }

    IEnumerator Transition()
    {
        SetupTimer.enabled = true;
        SetupTimer.SetText("Clear!");
        yield return Yielders.Get(1f);
        
        for (int i = 0; i < AlertUI.Length; i++)
        {
            AlertUI[i].SetActive(true);
        }
        AlertText.SetText("");
        StartCoroutine(Test(lines[4]));
        yield return Yielders.Get(2f);
        StartCoroutine(ShiftBreak());


    }

    bool mad;
    bool animMad;
    bool playing;
    private void Update()
    {
        if (setup && shiftStillGoing)
        {
            if (customerQueue.ElementAt(0).gameObject.transform.position != centerPoint.transform.position)
            {
                if (customerQueue.ElementAt(0).gameObject.transform.position.x < centerPoint.transform.position.x)
                {
                    customerQueue.ElementAt(0).gameObject.transform.position = centerPoint.transform.position;

                    if (mad)
                    {
                        customerQueue.ElementAt(0).anim.Play("AngryTalk");
                      
                    }
                    else
                    {
                        customerQueue.ElementAt(0).anim.Play("Talk");
                    }
                    return;
                }
                if (mad)
                {
                    customerQueue.ElementAt(0).anim.Play("AngryTalk");

                }
                else
                {
                    customerQueue.ElementAt(0).anim.Play("Talk");
                }
                customerQueue.ElementAt(0).gameObject.transform.position = new Vector2(customerQueue.ElementAt(0).gameObject.transform.position.x - .5f, customerQueue.ElementAt(0).gameObject.transform.position.y);
            }
            else if (customerQueue.ElementAt(1).gameObject.transform.position != secondPoint.transform.position)
            {
                if (customerQueue.ElementAt(1).gameObject.transform.position.x < secondPoint.transform.position.x)
                {
                    customerQueue.ElementAt(1).gameObject.transform.position = secondPoint.transform.position;
                    if (mad)
                    {
                        customerQueue.ElementAt(1).anim.Play("AngryTalk");

                    }
                    else
                    {
                        customerQueue.ElementAt(1).anim.Play("Idle");
                    }

                    return;
                }
                if (mad)
                {
                    customerQueue.ElementAt(1).anim.Play("AngryTalk");

                }
                else
                {
                    customerQueue.ElementAt(1).anim.Play("Idle");
                }

                customerQueue.ElementAt(1).gameObject.transform.position = new Vector2(customerQueue.ElementAt(1).gameObject.transform.position.x - .5f, customerQueue.ElementAt(1).gameObject.transform.position.y);

            }
            else if (customerQueue.ElementAt(2).gameObject.transform.position != thirdPoint.transform.position)
            {
                if (customerQueue.ElementAt(2).gameObject.transform.position.x < thirdPoint.transform.position.x)
                {
                    if (mad)
                    {
                        customerQueue.ElementAt(2).anim.Play("AngryTalk");

                    }
                    else
                    {
                        customerQueue.ElementAt(2).anim.Play("Idle");
                    }
                    customerQueue.ElementAt(2).gameObject.transform.position = thirdPoint.transform.position;
                    
                    return;

                  
                }
                
                customerQueue.ElementAt(2).gameObject.transform.position = new Vector2(customerQueue.ElementAt(2).gameObject.transform.position.x - .5f, customerQueue.ElementAt(2).gameObject.transform.position.y);
                if (mad)
                {
                    customerQueue.ElementAt(2).anim.Play("AngryTalk");

                }
                else
                {
                    customerQueue.ElementAt(2).anim.Play("Idle");
                }

            }

            if (shiftStillGoing)
            {
                second += Time.deltaTime;
                //second2 += Time.deltaTime;

                if (second >= .5)
                {
                    second = 0;
                    if (TotalShifts < 3)
                        satisfaction -= 3;
                    else if (TotalShifts >= 3 && TotalShifts < 10)
                        satisfaction -= 4;
                    else
                        satisfaction -= 5;
                }
                if (satisfaction <= 25)
                {
                    mad = true;
                    if (musicHandler.source.clip != musicHandler.sounds[2])
                    {
                        musicHandler.source.clip = musicHandler.sounds[2];
                        musicHandler.source.Play();
                        //playing = true;
                    }
                    //playing = true;

                }
                else
                {
                    if (musicHandler.source.clip == musicHandler.sounds[2]&&!manager.timer.playing)
                    {
                        musicHandler.source.clip = musicHandler.sounds[1];
                        musicHandler.source.Play();
                        //playing = true;
                    }
                    mad = false;
                    playing= false;
                }
                if (satisfaction <= 0)
                {
                    shiftClear = false;
                    win = false;
                    shiftStillGoing = false;
                    EndShift();
                }

            }
            if (servedQueue.Count > 0)
            {
                //second2 = 0;
                //second2 += Time.deltaTime;
                for (int i = 0; i < servedQueue.Count; i++)
                {
                    servedQueue.ElementAt(i).gameObject.transform.position = new Vector2(servedQueue.ElementAt(i).gameObject.transform.position.x - .25f, servedQueue.ElementAt(i).gameObject.transform.position.y);
                    //servedQueue.ElementAt(0).gameObject.transform.position = new Vector2(servedQueue.ElementAt(0).gameObject.transform.position.x, servedQueue.ElementAt(0).gameObject.transform.position.y - .5f);
                    servedQueue.ElementAt(i).bubble.enabled = false;
                    //servedQueue.ElementAt(0).GetComponentInChildren<Spritre>
                }
                //servedQueue.ElementAt()
                if (servedQueue.ElementAt(0).gameObject.transform.position.x <= -15f)
                {
                    servedQueue.ElementAt(0).gameObject.SetActive(false);
                    servedQueue.Dequeue();
                }


            }

        }
        if(!shiftStillGoing)
        {
            if (servedQueue.Count > 0)
            {
                //second2 = 0;
                //second2 += Time.deltaTime;
                for (int i = 0; i < servedQueue.Count; i++)
                {
                    servedQueue.ElementAt(i).gameObject.transform.position = new Vector2(servedQueue.ElementAt(i).gameObject.transform.position.x - .25f, servedQueue.ElementAt(i).gameObject.transform.position.y);
                    //servedQueue.ElementAt(0).gameObject.transform.position = new Vector2(servedQueue.ElementAt(0).gameObject.transform.position.x, servedQueue.ElementAt(0).gameObject.transform.position.y - .5f);
                    servedQueue.ElementAt(i).bubble.enabled = false;
                    //servedQueue.ElementAt(0).GetComponentInChildren<Spritre>
                }
                //servedQueue.ElementAt()
                if (servedQueue.ElementAt(0).gameObject.transform.position.x <= -15f)
                {
                    //servedQueue.ElementAt(0).enabled = false;
                    servedQueue.ElementAt(0).Clear();
                    servedQueue.ElementAt(0).gameObject.SetActive(false);
                    servedQueue.Dequeue();
                }


            }
        }
    }





}
