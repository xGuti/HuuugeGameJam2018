using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int police;
    public int panic;
    public int money;

    public bool ICameraTrigger;

	// Use this for initialization
	void Start () {
        police = 50;
        panic = 50;
        money = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
