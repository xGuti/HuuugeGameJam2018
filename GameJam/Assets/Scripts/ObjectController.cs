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
    public ParticleSystem smoke;

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

                switch (gameObject.tag)
                {
                    case "ICamera":
                        basicFastDuration = 5;
                        policePoints = -0.3f;
                        panicPoints = 0.3f;

                        pgbar.GetComponentInChildren<ProgressBarController>().policePoint = policePoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().panicPoint = panicPoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().duration = basicFastDuration;

                        break;
                    case "Hostage":
                        basicFastDuration = 5;
                        policePoints = -0.3f;
                        panicPoints = 0.3f;

                        pgbar.GetComponentInChildren<ProgressBarController>().policePoint = policePoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().panicPoint = panicPoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().duration = basicFastDuration;
                        break;
                    case "CashDesk":
                        basicFastDuration = 5;
                        policePoints = -0.3f;
                        panicPoints = 0.3f;
                        money = 5;

                        pgbar.GetComponentInChildren<ProgressBarController>().policePoint = policePoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().panicPoint = panicPoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().duration = basicFastDuration;
                        break;
                    case "Safe":
                        basicFastDuration = 5;
                        policePoints = -0.3f;
                        panicPoints = 0.3f;

                        pgbar.GetComponentInChildren<ProgressBarController>().policePoint = policePoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().panicPoint = panicPoints;
                        pgbar.GetComponentInChildren<ProgressBarController>().duration = basicFastDuration;
                        break;
                }
                




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
                pgbar.GetComponentInChildren<ProgressBarController>().duration = basicSlowDuration - playerTimeBonus;

                used = true;
                smoke.Play();
                
            }

        }

        if (pgbar && objectTrigger == true && Input.GetKeyUp(KeyCode.Z))
        {
            pgbar.GetComponentInChildren<ProgressBarController>().triggered = false;
            pgbar.GetComponentInChildren<ProgressBarController>().stop = true;
            GetComponentInChildren<ParticleSystem>().Stop();
        }
        else if (pgbar && objectTrigger == true && Input.GetKeyUp(KeyCode.X))
        {
            pgbar.GetComponentInChildren<ProgressBarController>().triggered = false;
            pgbar.GetComponentInChildren<ProgressBarController>().stop = true;
            GetComponentInChildren<ParticleSystem>().Stop();
        }

        else if (pgbar && objectTrigger == true && Input.GetKeyDown(KeyCode.Z))
        {
            pgbar.GetComponentInChildren<ProgressBarController>().triggered = true;
            pgbar.GetComponentInChildren<ProgressBarController>().stop = false;
            pgbar.GetComponentInChildren<ProgressBarController>().release = true;
            GetComponentInChildren<ParticleSystem>().Play();
        }
        else if (pgbar && objectTrigger == true && Input.GetKeyDown(KeyCode.X))
        {
            pgbar.GetComponentInChildren<ProgressBarController>().triggered = true;
            pgbar.GetComponentInChildren<ProgressBarController>().stop = false;
            pgbar.GetComponentInChildren<ProgressBarController>().release = true;
            GetComponentInChildren<ParticleSystem>().Play();
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

        //GetComponentInChildren<ParticleSystem>().Play();


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
        GetComponentInChildren<ParticleSystem>().Pause();
        GetComponentInChildren<ParticleSystem>().Clear();
    }
}
