using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamEqScript : MonoBehaviour
{
    int lvl = 1;
    public int time;
    public float police;
    public float panic;

    GameObject gameController;
    // Use this for initialization
    void Start()
    {
        gameController = GameObject.Find("GameController");
        lvl = gameController.GetComponent<GameController>().cameqLVL;

        switch (lvl)
        {
            case 1:
                time = 15;
                police = -0.2f;
                panic = 0f;
                break;
            case 2:
                time = 5;
                police = -0.25f;
                panic = 0.1f;
                break;
            case 3:
                time = 25;
                police = -0.4f;
                panic = 0;
                break;
        }
    }
}
