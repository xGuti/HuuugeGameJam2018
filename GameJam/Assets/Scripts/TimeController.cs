using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{

    // Use this for initialization
    private Timer timer;
    private TimeSpan baseTime = new TimeSpan();

    public Text timeText;

    void Start()
    {
        baseTime = TimeSpan.FromMinutes(2);
        timer = new Timer();
        timer.Interval = 1000;
        timer.Elapsed += new ElapsedEventHandler(OnTimerElapsed);
        timer.Start();
    }

    private void OnTimerElapsed(object source, ElapsedEventArgs e)
    {
        if (baseTime > TimeSpan.Zero)
            baseTime -= TimeSpan.FromSeconds(1);
    }

    public void addTime(int seconds)
    {
        baseTime += TimeSpan.FromSeconds(seconds);

    }

    public void decreaseTime(int seconds)
    {
        if (baseTime > TimeSpan.Zero)
            baseTime -= TimeSpan.FromSeconds(seconds);

    }

    public void setRun()
    {
        baseTime = TimeSpan.FromSeconds(30);
    }

    // Update is called once per frame
    void Update()
    {
        string text = new DateTime(baseTime.Ticks).ToString("mm:ss");

        timeText.text = text;

    }
}
