using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkGhost : MonoBehaviour
{
    //Store pink ghost pass
	public Transform[] turnPoints;
	public float speed = 0.4f;
    //count which point of pass
	private int index = 0;
    

    void FixedUpdate()
    {
        if(transform.position != turnPoints[index].position)
		{
			Vector2 temp = Vector2.MoveTowards(transform.position, turnPoints[index].position, speed);
			GetComponent<Rigidbody2D>().MovePosition(temp);
		}
		else
		{
			index = (index + 1) % turnPoints.Length;
		}
		Vector2 dest = turnPoints[index].position - transform.position;
		GetComponent<Animator>().SetFloat("X-axis", dest.x * speed);
		GetComponent<Animator>().SetFloat("Y-axis", dest.y * speed);
	}
}
