using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    private float speed = .1f;

    void FixedUpdate()
    {
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        animator.SetFloat("Speed", dir.y);
        animator.SetFloat("SpeedX", dir.x);

        Vector2 p = Vector2.MoveTowards(transform.position,
            new Vector2(transform.position.x + dir.x, transform.position.y + dir.y),
            speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("colision");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      //  Debug.Log("exit");
    }


}
