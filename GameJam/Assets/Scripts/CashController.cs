using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashController : MonoBehaviour
{

    private int cash;
    public Text text;
    

    public int Cash
    {
        get { return cash; }

        set
        {
            if (value > 0)
                cash = value;
        }
    }
    // Use this for initialization

    public void AddCash(int cash)
    {
        Cash += cash;

    }
    void Start()
    {
        Cash = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Cash.ToString() + '$';
    }
}
