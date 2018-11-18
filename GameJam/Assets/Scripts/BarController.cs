using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    private float policValue = 0.5F;
    private float panicValue = 0.5F;
    public Slider panicBar;
    public Slider policBar;

    private bool setRun = true;

    private float panicInsrease = 0.01f;
    private float policeIncrease = 0.01f;

    private TimeController timeController;

    Timer timer;


    void Start()
    {
        timeController = GameObject.Find("TimeController").GetComponent<TimeController>();
        PanicValue = 0.5F;
        PolicValue = 0.1F;
        timer = new Timer();
        timer.Interval = 1000;
        timer.Elapsed += new ElapsedEventHandler(OnTimerElapsed);
        timer.Start();
    }

    private void OnTimerElapsed(object source, ElapsedEventArgs e)
    {
       // Debug.Log(PanicValue);
        PanicValue -= panicInsrease;
        PolicValue += policeIncrease;
    }

    public float PanicValue
    {
        get { return panicValue; }
        set
        {
            if (value <= 0.0f)
                panicValue = 0.0f;
            else if (value > 1.0f)
                panicValue = 1.0f;
            else panicValue = value;

        }
    }

    public float PolicValue
    {
        get { return policValue; }
        set
        {
            if (value <= 0.0f)
                policValue = 0.0f;
            else if (value > 1.0f)
                policValue = 1.0f;
            else policValue = value;
        }
    }

    public void addPolicy(float value)
    {

        float tempValue = PolicValue;

        tempValue += value;

        if (tempValue >= 1)
        {
            PolicValue = 1;
        }
        else
        {
            PolicValue = tempValue;
        }

    }

    public void decreasePolic(float value)
    {

        float tempValue = PolicValue;

        tempValue -= value;

        if (tempValue <= 0)
        {
            PolicValue = 0;
        }
        else
        {
            PolicValue = tempValue;
        }

    }

    public void addPanic(float value)
    {
        float tempValue = PanicValue;

        tempValue += value;

        if (tempValue >= 1)
        {
            PanicValue = 1;
        }
        else
        {
            PanicValue = tempValue;
        }

    }

    public void decreasePanic(float value)
    {

        float tempValue = PanicValue;

        tempValue -= value;

        if (tempValue <= 0)
        {
            PanicValue = 0;
        }
        else
        {
            PanicValue = tempValue;
        }

    }

    public void StopTimer()
    {
        timer.Stop();
    }

    void Update()
    {
        panicBar.value = PanicValue;
        policBar.value = PolicValue;

        if (PolicValue >= 0.95 && setRun)
        {
            timeController.setRun();
            setRun = false;
        }

        if (PanicValue <= 0.3 || PanicValue >= 0.8)
        {
            policeIncrease = 0.05f;
        };

    }
}
