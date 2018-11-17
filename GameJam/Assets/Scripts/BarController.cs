using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    private float policValue = 0.5F;
    private float panicValue = 0.5F;
    public Slider panicBar;
    public Slider policBar;

    GameObject barPanic;

    public BarController(float policyValue, float panicValue)
    {
        this.policValue = policyValue;
        this.panicValue = panicValue;

    }

    public float PanicVaue
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

    public void addPolicy(float value) {

        float tempValue = PolicValue;

        tempValue += value;

        if (tempValue >= 1)
        {
            PolicValue = 1;
        }
        else {
            PolicValue = tempValue;
        }

    }

    public void decreasePolic(float value) {

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

    public void addPanic(float value) {
        float tempValue = PanicVaue;

        tempValue += value;

        if (tempValue >= 1)
        {
            PanicVaue = 1;
        }
        else
        {
            PanicVaue = tempValue;
        }

    }

    public void decreasePanic(float value)
    {

        float tempValue = PanicVaue;

        tempValue -= value;

        if (tempValue <= 0)
        {
            PanicVaue = 0;
        }
        else
        {
            PanicVaue = tempValue;
        }

    }

    void Update()
    {
        PanicVaue += 0.01F;
        PolicValue += 0.01F;

        panicBar.value = PanicVaue;
        policBar.value = PolicValue;


    }




}
