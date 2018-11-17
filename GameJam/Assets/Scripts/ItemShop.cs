using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    private bool itemTrigger = false;
    public float policePoints = 0f;
    public float panicPoints = 0f;
    public float speed = 0f;
    public enum interactiveItemName { Safe, CashDesk, Hostage, ICamera, None };
    public int timeReduce = 0;
    public string description = "";
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(itemTrigger)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                //jak sławek doda to sie zobaczy co tu wpisac

                Destroy(this);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            itemTrigger = true;
        }
    }
}
