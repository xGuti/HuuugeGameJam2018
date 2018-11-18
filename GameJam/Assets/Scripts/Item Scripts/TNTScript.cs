using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTScript : MonoBehaviour {
    int lvl = 1;
    public int time;
    public float police;
    public float panic;

    GameObject gameController = GameObject.Find("GameController");
    // Use this for initialization
    void Start()
    {
        lvl = gameController.GetComponent<GameController>().tntLVL;

        switch (lvl)
        {
            case 1:
                time = 30;
                police = 0.5f;
                panic = 0.5f;
                break;
            case 2:
                time = 20;
                police = 0.5f;
                panic = 0.6f;
                break;
            case 3:
                time = 30;
                police = 0.4f;
                panic = 0.3f;
                break;
        }
    }
}
