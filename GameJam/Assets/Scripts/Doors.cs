using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour {

    private bool trigger;
    public GameObject fastOption;
    // Update is called once per frame
    void Update () {
        if (trigger)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log(SceneManager.GetActiveScene().name);
                if (SceneManager.GetActiveScene().name=="Shop") SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
                else if (SceneManager.GetActiveScene().name =="SampleScene")
                {
                    SceneManager.LoadScene("Shop", LoadSceneMode.Single);
                }
            }
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        trigger = true;
        Instantiate(fastOption, new Vector2(this.gameObject.transform.position.x - this.gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2,
            this.gameObject.transform.position.y + this.gameObject.GetComponent<SpriteRenderer>().bounds.size.y), Quaternion.identity);
        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        trigger = false;
        Destroy(GameObject.Find("FastOption(Clone)"));
    }
}
