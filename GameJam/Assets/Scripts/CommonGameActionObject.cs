using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonGameActionObject : MonoBehaviour
{

    private float time;
    private float policEffort;

    private float panicEffort;

    private int cashEffort;

    public BarController barController;

    public TimeController timeController;

    void Start()
    {
        barController = GameObject.Find("BarController").GetComponent<BarController>();

        timeController = GameObject.Find("TimeController").GetComponent<TimeController>();
    }
    public CommonGameActionObject(float time, float policEffort, float panicEffort, int cashEffort)
    {
        this.time = time;
        this.policEffort = policEffort;
        this.panicEffort = panicEffort;
        this.cashEffort = cashEffort;
    }
    public float Time
    {
        get { return time; }

    }

    // Use this for initialization
    // void Start()
    // {

    // }

    // Update is called once per frame
    void Update()
    {

    }
}
