using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{

    public float time;

    public bool triggered;
    public bool stop = false;
    public bool release = false;
    private bool timerStart = true;

    public float policePoint;
    public float panicPoint;
    public int money;

    public Slider progressBar;
    public Slider panicSlider;
    public Slider policeSldier;

    private BarController barcontroller;
    private CashController cashController;

    private float timeValue = 0.0F;

    Timer timer;


    // Use this for initialization
    void Start()
    {

        TimeValue = 0.0F;
        timer = new Timer();
        timer.Interval = 1000;
        timer.Elapsed += new ElapsedEventHandler(OnTimerElapsed);
        timer.Start();


    }
    private void Awake()
    {
        barcontroller = GameObject.Find("BarController").GetComponent<BarController>();
        cashController = GameObject.Find("CashController").GetComponent<CashController>();

    }

    public float TimeValue
    {
        get { return timeValue; }
        set
        {
            if (timeValue >= 0 && timeValue < 1)
                timeValue = value;
        }
    }

    private void OnTimerElapsed(object source, ElapsedEventArgs e)
    {
        //Debug.Log("asaddsa");
        TimeValue += 1 / time;
    }

    // Update is called once per frame
    void Update()
    {

        if (triggered == true && stop == false)
        {
            if (timerStart)
            {
                Debug.Log("timerStart");
                timer.Start();
                timerStart = false;
            }
            progressBar.value = TimeValue;
        }

        else if (triggered == false && stop == true)
        {
            timerStart = true;
            timer.Stop();
            progressBar.value += 0;
        }

        else if (release)
        {
            timer.Start();
            release = false;
        }

        if (TimeValue >= 1)
        {
            barcontroller.addPanic(panicPoint);
            barcontroller.addPolicy(policePoint);
            cashController.AddCash(money);
            Destroy(transform.gameObject.GetComponentInParent<Canvas>().gameObject);
        }




        /* else if (release == true)
         {
             timer.Start();
             Debug.Log("bar Released");
             release = false;

         }*/

        /* gameObject.GetComponent<Slider>
         this.value = PanicValue;
         policBar.value = PolicValue;*/

    }
}
