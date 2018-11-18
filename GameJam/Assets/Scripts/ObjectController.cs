using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{

    private bool objectTrigger;
    private bool used;

    //public GameObject gameController;
    GameController gameController;

    public GameObject fastOption;
    public GameObject slowOption;
    public GameObject progressBar;
    private GameObject pgbar;

    public Component script;

    private float basicFastDuration = 5;
    private float basicSlowDuration = 10;
    private float playerTimeBonus=0;

    private float policePoints;
    private float panicPoints;
    private float money;

    // Use this for initialization
    void Start()
    {
        objectTrigger = false;
        used = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (objectTrigger == true && used == false)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                // fast reaction
                
                

                Debug.Log("Fast Option Has Been Chosen");
                Destroy(GameObject.Find("FastOption(Clone)"));
                Destroy(GameObject.Find("SlowOption(Clone)"));

                pgbar = Instantiate(progressBar, transform.position, Quaternion.identity) as GameObject;
                pgbar.transform.parent = gameObject.transform;

               /* switch (gameObject.tag)
                {
                    case "ICamera":
                        basicFastDuration = GameObject.Find("Gun").GetComponent<GunScript>().time;
                        policePoints = GameObject.Find("Gun").GetComponent<GunScript>().police*(-1);
                        panicPoints = GameObject.Find("Gun").GetComponent<GunScript>().panic;

                        pgbar.GetComponentInChildren<ProgressBarController>().policePoint = policePoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().panicPoint = panicPoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().time = basicFastDuration;

                        break;
                    case "Hostage":
                        basicFastDuration = GameObject.Find("Gun").GetComponent<GunScript>().time;
                        policePoints = GameObject.Find("Gun").GetComponent<GunScript>().police;
                        panicPoints = GameObject.Find("Gun").GetComponent<GunScript>().panic*1.5f;

                        pgbar.GetComponentInChildren<ProgressBarController>().policePoint = policePoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().panicPoint = panicPoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().time = basicFastDuration;
                        break;
                    case "CashDesk":
                        basicFastDuration = GameObject.Find("Gun").GetComponent<GunScript>().time;
                        policePoints = GameObject.Find("Gun").GetComponent<GunScript>().police;
                        panicPoints = GameObject.Find("Gun").GetComponent<GunScript>().panic;
                        money = GameObject.Find("Bag").GetComponent<BagScript>().money;

                        pgbar.GetComponentInChildren<ProgressBarController>().policePoint = policePoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().panicPoint = panicPoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().time = basicFastDuration;
                        pgbar.GetComponentInChildren<ProgressBarController>().money = money;
                        break;
                    case "Safe":
                        basicFastDuration = GameObject.Find("TNT").GetComponent<TNTScript>().time;
                        policePoints = GameObject.Find("TNT").GetComponent<TNTScript>().police;
                        panicPoints = GameObject.Find("TNT").GetComponent<TNTScript>().panic;

                        pgbar.GetComponentInChildren<ProgressBarController>().policePoint = policePoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().panicPoint = panicPoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().time = basicFastDuration;
                        break;
                }*/
                




                used = true;
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                //slow reaction

                Debug.Log("Slow Option Has Been Chosen");
                Destroy(GameObject.Find("FastOption(Clone)"));
                Destroy(GameObject.Find("SlowOption(Clone)"));
                pgbar = Instantiate(progressBar, transform.position, Quaternion.identity);
                pgbar.transform.parent = gameObject.transform;

               /* switch (gameObject.tag)
                {
                    case "ICamera":
                        basicFastDuration = GameObject.Find("Cameq").GetComponent<CamEqScript>().time;
                        policePoints = GameObject.Find("Cameq").GetComponent<CamEqScript>().police;
                        panicPoints = GameObject.Find("Cameq").GetComponent<CamEqScript>().panic;

                        pgbar.GetComponentInChildren<ProgressBarController>().policePoint = policePoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().panicPoint = panicPoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().time = basicFastDuration;

                        break;
                    case "Hostage":
                        basicFastDuration = GameObject.Find("Rope").GetComponent<RopeScript>().time;
                        policePoints = GameObject.Find("Rope").GetComponent<RopeScript>().police;
                        panicPoints = GameObject.Find("Rope").GetComponent<RopeScript>().police;

                        pgbar.GetComponentInChildren<ProgressBarController>().policePoint = policePoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().panicPoint = panicPoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().time = basicFastDuration;
                        break;
                    case "CashDesk":
                        basicFastDuration = GameObject.Find("Bag").GetComponent<BagScript>().time;
                        policePoints = GameObject.Find("Bag").GetComponent<BagScript>().police;
                        panicPoints = GameObject.Find("Bag").GetComponent<BagScript>().panic;
                        money = GameObject.Find("Bag").GetComponent<BagScript>().money;

                        pgbar.GetComponentInChildren<ProgressBarController>().policePoint = policePoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().panicPoint = panicPoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().time = basicFastDuration;
                        pgbar.GetComponentInChildren<ProgressBarController>().money = money;
                        break;
                    case "Safe":
                        basicFastDuration = GameObject.Find("Drill").GetComponent<DrillScript>().time;
                        policePoints = GameObject.Find("Drill").GetComponent<DrillScript>().police;
                        panicPoints = GameObject.Find("Drill").GetComponent<DrillScript>().panic;

                        pgbar.GetComponentInChildren<ProgressBarController>().policePoint = policePoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().panicPoint = panicPoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().time = basicFastDuration;
                        break;
                }*/

                used = true;
            }

        }

        if (pgbar && objectTrigger == true && Input.GetKeyUp(KeyCode.Z))
        {
            pgbar.GetComponentInChildren<ProgressBarController>().triggered = false;
            pgbar.GetComponentInChildren<ProgressBarController>().stop = true;
        }
        else if (pgbar && objectTrigger == true && Input.GetKeyUp(KeyCode.X))
        {
            pgbar.GetComponentInChildren<ProgressBarController>().triggered = false;
            pgbar.GetComponentInChildren<ProgressBarController>().stop = true;
        }

        else if (pgbar && objectTrigger == true && Input.GetKeyDown(KeyCode.Z))
        {
            pgbar.GetComponentInChildren<ProgressBarController>().triggered = true;
            pgbar.GetComponentInChildren<ProgressBarController>().stop = false;
            pgbar.GetComponentInChildren<ProgressBarController>().release = true;
        }
        else if (pgbar && objectTrigger == true && Input.GetKeyDown(KeyCode.X))
        {
            pgbar.GetComponentInChildren<ProgressBarController>().triggered = true;
            pgbar.GetComponentInChildren<ProgressBarController>().stop = false;
            pgbar.GetComponentInChildren<ProgressBarController>().release = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectTrigger = true;
        if (used == false)
        {
            Instantiate(fastOption, new Vector2(this.gameObject.transform.position.x - this.gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2,
                this.gameObject.transform.position.y + this.gameObject.GetComponent<SpriteRenderer>().bounds.size.y), Quaternion.identity);

            Instantiate(slowOption, new Vector2(this.gameObject.transform.position.x + this.gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2,
                this.gameObject.transform.position.y + this.gameObject.GetComponent<SpriteRenderer>().bounds.size.y), Quaternion.identity);
        }

    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exited");
        objectTrigger = false;

        if (pgbar)
        {
            pgbar.GetComponentInChildren<ProgressBarController>().triggered = false;
            pgbar.GetComponentInChildren<ProgressBarController>().stop = true;
        }

        if (used == false)
        {
            Destroy(GameObject.Find("FastOption(Clone)"));
            Destroy(GameObject.Find("SlowOption(Clone)"));
        }
    }
}
