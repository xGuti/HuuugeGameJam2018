using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float speed = .1f;
    //public Transform smoke;

    void FixedUpdate()
    {
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 p = Vector2.MoveTowards(transform.position,
            new Vector2(transform.position.x + dir.x, transform.position.y + dir.y),
            speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponentInChildren<ParticleSystem>().Play();
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            GetComponentInChildren<ParticleSystem>().Pause();
            GetComponentInChildren<ParticleSystem>().Clear();
        }

        //smoke.GetComponent<ParticleSystem>().enableEmission = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("colision");
        //  Play effect when player hit the action key
        //  if statement?
       

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
      //  Debug.Log("exit");
    }


}
