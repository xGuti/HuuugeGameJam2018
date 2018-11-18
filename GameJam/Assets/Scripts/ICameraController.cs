using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICameraController : MonoBehaviour
{

    private bool objectTrigger;
    private bool used;

    private Transform target;

    //public GameObject gameController;
    GameController gameController;

    public GameObject fastOption;
    public GameObject slowOption;
    public GameObject progressBar;

    BarController barController;



    // Use this for initialization
    void Start()
    {
        objectTrigger = false;
        used = false;
        

    }
    private void Awake()
    {
        barController = GameObject.Find("BarController").GetComponent<BarController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectTrigger == true && used==false)
        {
            
  
            if (Input.GetKeyDown(KeyCode.Z))
            {
                // fast reaction

                barController.addPanic(0.1f);

               // Instantiate(progressBar, this.gameController.transform.position,Quaternion.identity);

                Debug.Log("Fast Option Has Been Chosen");
                Destroy(GameObject.Find("FastOption(Clone)"));
                Destroy(GameObject.Find("SlowOption(Clone)"));
                used = true;



            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                //slow reaction

                Debug.Log("Slow Option Has Been Chosen");
                Destroy(GameObject.Find("FastOption(Clone)"));
                Destroy(GameObject.Find("SlowOption(Clone)"));
                used = true;
            }

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
        if (used == false)
        {
            Destroy(GameObject.Find("FastOption(Clone)"));
            Destroy(GameObject.Find("SlowOption(Clone)"));
        }
    }

    

}
