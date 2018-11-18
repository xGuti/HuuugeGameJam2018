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
    public GameObject interactiveController;

    private GameObject pgbar;

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
                switch (gameObject.tag)
                {
                    case "ICamera":
                        interactiveController.GetComponent<ICameraController>().fastReact();
                        break;
                    case "Hostage":
                        interactiveController.GetComponent<HostageController>().fastReact();
                        break;
                    case "CashDesk":
                        interactiveController.GetComponent<CashDeskController>().fastReact();
                        break;
                    case "Safe":
                        interactiveController.GetComponent<SafeController>().fastReact();
                        break;
                }
                Debug.Log("Fast Option Has Been Chosen");
                Destroy(GameObject.Find("FastOption(Clone)"));
                Destroy(GameObject.Find("SlowOption(Clone)"));
                pgbar = Instantiate(progressBar, transform.position, Quaternion.identity);
                pgbar.transform.parent = gameObject.transform;
                used = true;
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                //slow reaction
                switch (gameObject.tag)
                {
                    case "ICamera":
                        interactiveController.GetComponent<ICameraController>().slowReact();
                        break;
                    case "Hostage":
                        interactiveController.GetComponent<HostageController>().slowReact();
                        break;
                    case "CashDesk":
                        interactiveController.GetComponent<CashDeskController>().slowReact();
                        break;
                    case "Safe":
                        interactiveController.GetComponent<SafeController>().slowReact();
                        break;
                }
                Debug.Log("Slow Option Has Been Chosen");
                Destroy(GameObject.Find("FastOption(Clone)"));
                Destroy(GameObject.Find("SlowOption(Clone)"));
                pgbar = Instantiate(progressBar, transform.position, Quaternion.identity);
                pgbar.transform.parent = gameObject.transform;
                used = true;
            }

        }

        else if (objectTrigger && (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z)))
        {
            //pgbar.GetComponentInChildren<ProgressBarScript>().startTimer();
        }
        else if (used == true) ;
            //pgbar.GetComponentInChildren<ProgressBarScript>().pauseTimer();
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
        if (used == false)
        {
            Destroy(GameObject.Find("FastOption(Clone)"));
            Destroy(GameObject.Find("SlowOption(Clone)"));
        }
    }
}
