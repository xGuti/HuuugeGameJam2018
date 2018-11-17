using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int police;
    private int panic;
    private int money;

	// Use this for initialization
	void Start () {
        police = 50;
        panic = 50;
        money = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddPolice(int point)
    {
        police += point;
    }
    public void AddPanic(int point)
    {
        panic += point;
    }
    public void AddMoney(int point)
    {
        money += point;
    }
}
