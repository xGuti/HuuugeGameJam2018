using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour {
    int lvl = 1;
    public int time;
    public float police;
    public float panic;

    GameObject gameController = GameObject.Find("GameController");
    // Use this for initialization
    void Start()
    {
        lvl = gameController.GetComponent<GameController>().ropeLVL;

        switch (lvl)
        {
            case 1:
                time = 25;
                police = 0f;
                panic = 0.05f;
                break;
            case 2:
                time = 10;
                police = 0f;
                panic = 0.1f;
                break;
            case 3:
                time = 5;
                police = 0f;
                panic = 0.1f;
                break;
        }
    }
}
