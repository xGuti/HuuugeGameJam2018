using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;
    private int money;
    private BarController barController;
    private TimeController timeController;
    public int drillLVL=1, tntLVL=1, gunLVL=1, bagLVL=1, ropeLVL=1, cameqLVL=1;
    // Use this for initialization
    void Awake()
    {
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script
        //barController = GameObject.Find("BarController").GetComponent<BarController>();

        //timeController = GameObject.Find("TimeController").GetComponent<TimeController>();

    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

}
