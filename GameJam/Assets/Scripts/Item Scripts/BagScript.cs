using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour
{
    int lvl = 1;
    public int time;
    public float police;
    public float panic;
    public int money;
    GameObject gameController;
    // Use this for initialization
    void Start()
    {
        gameController = GameObject.Find("GameController");
        lvl = gameController.GetComponent<GameController>().bagLVL;

        switch (lvl)
        {
            case 1:
                time = 20;
                police = 0f;
                panic = 0f;
                money = 500;
                break;
            case 2:
                time = 15;
                police = 0f;
                panic = 0f;
                money = 600;
                break;
            case 3:
                time = 10;
                police = 0f;
                panic = 0f;
                money = 750;
                break;
        }
    }
}
