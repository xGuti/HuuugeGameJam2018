using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashDeskController : MonoBehaviour {

    private bool cashDeskTrigger;
    private bool used;

    GameController gameController;

    public GameObject fastOption;
    public GameObject slowOption;

    // Use this for initialization
    void Start()
    {
        cashDeskTrigger = false;
        used = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cashDeskTrigger == true&&used==false)
        {


            if (Input.GetKeyDown(KeyCode.Z))
            {
                // fast reaction
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
        cashDeskTrigger = true;
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
        cashDeskTrigger = false;
        if (used == false)
        {
            Destroy(GameObject.Find("FastOption(Clone)"));
            Destroy(GameObject.Find("SlowOption(Clone)"));
        }
    }
}
