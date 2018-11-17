using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICameraController : MonoBehaviour {

    private bool iCameraTrigger=false;

    public GameObject gameController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (iCameraTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                // fast reaction
                

                
            }
            else if(Input.GetKeyDown(KeyCode.X))
            {
                //slow reaction
            }
        }
        
		
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            iCameraTrigger = true;
        }
    }
}
