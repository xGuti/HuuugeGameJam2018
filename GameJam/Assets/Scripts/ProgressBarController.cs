using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour {

    public float duration;
    public bool triggered;
    public bool stop=false;
    public bool release = false;
    private bool timerStart = true;

    public float policePoint;
    public float panicPoint;
    public float money;

    public Slider progressBar;
    public Slider panicSlider;
    public Slider policeSldier;

    private BarController barcontroller;

    private float panicValue = 0.0F;

    Timer timer;


    // Use this for initialization
    void Start () {

        timeValue = 0.0F;
        timer = new Timer();
        timer.Interval = 1000;
        timer.Elapsed += new ElapsedEventHandler(OnTimerElapsed);
        timer.Start();

        
    }
    private void Awake()
    {
        barcontroller = GameObject.Find("BarController").GetComponent<BarController>();

    }

    public float timeValue
    {
        get { return panicValue; }
        set
        {
            if (panicValue >= 0 && panicValue < 1)
                panicValue = value;
        }
    }

    private void OnTimerElapsed(object source, ElapsedEventArgs e)
    {
        timeValue +=0.2f;
    }

    // Update is called once per frame
    void Update () {

        if (triggered == true && stop == false)
        {
            if (timerStart)
            {
                Debug.Log("timerStart");
                timer.Start();
                timerStart = false;
            }
            progressBar.value = timeValue;
        }




        else if (triggered==false&&stop==true)
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

        if (panicValue >= 1)
        {
            barcontroller.addPanic(panicPoint);
            barcontroller.addPolicy(policePoint);
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
