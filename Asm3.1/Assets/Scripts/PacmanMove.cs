using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        //make sure it won't change at the begaining of 
        dest = transform.position;
    }


    void FixedUpdate()
    {
        // Move Pacman!
        Vector2 pos = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        // Get input
        if ((Vector2)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.W) && canMove(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            else if (Input.GetKey(KeyCode.D) && canMove(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            else if (Input.GetKey(KeyCode.S) && canMove(-Vector2.up))
                dest = (Vector2)transform.position - Vector2.up;
            else if (Input.GetKey(KeyCode.A) && canMove(-Vector2.right))
                dest = (Vector2)transform.position - Vector2.right;
        }

        // Add Animation into it
        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("X-axis", dir.x);
        GetComponent<Animator>().SetFloat("Y-axis", dir.y);
    }

    bool canMove(Vector2 dir)
    {
        // check if Panman is facing the wall or not
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
}
