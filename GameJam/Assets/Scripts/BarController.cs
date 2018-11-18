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

    Timer timer;


    void Start()
    {
        PanicValue = 0.5F;
        PolicValue = 0.5F;
        timer = new Timer();
        timer.Interval = 1000;
        timer.Elapsed += new ElapsedEventHandler(OnTimerElapsed);
        timer.Start();
    }

    private void OnTimerElapsed(object source, ElapsedEventArgs e)
    {
        PanicValue += 0.01F;
        PolicValue += 0.01F;
    }

    public float PanicValue
    {
        get { return panicValue; }
        set
        {
            if (value >= 0 && value <= 1)
                panicValue = value;
        }
    }

    public float PolicValue
    {
        get { return policValue; }
        set
        {
            if (value >= 0 && value <= 1)
                policValue = value;
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

    void Update()
    {
        Console.WriteLine(PanicValue.ToString());
        //Debug.Log(PanicValue.ToString());
        panicBar.value = PanicValue;
        policBar.value = PolicValue;

    }




}
