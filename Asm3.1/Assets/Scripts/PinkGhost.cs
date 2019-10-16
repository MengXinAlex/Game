﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PinkGhost : MonoBehaviour
{
    //Store pink ghost pass
	public Transform[] turnPoints;
	public float speed = 0.5f;
    //count which point of pass
	private int index = 0;
    

    void FixedUpdate()
    {
		//pink are going with scheduling route
		if (transform.position != turnPoints[index].position)
		{
			Vector2 temp = Vector2.MoveTowards(transform.position, turnPoints[index].position, speed);
			GetComponent<Rigidbody2D>().MovePosition(temp);
		}
		else
		{
			index = (index + 1) % turnPoints.Length;
		}
		Vector2 dest = turnPoints[index].position - transform.position;

		if (GameObject.Find("Game").GetComponent<GameBoard>().isStage2 == 1)
		{
			GetComponent<Animator>().SetFloat("X-axis", dest.x * speed);
			GetComponent<Animator>().SetFloat("Y-axis", dest.y * speed);
		}
	}

	void OnTriggerEnter2D(Collider2D co)
	{
		if (co.name == "pacman")
			SceneManager.LoadScene(2);
		if (co.tag == "Bullet")
		{
			GameObject.Find("Game").GetComponent<GameBoard>().kills += 1;
			Destroy(gameObject);
		}
	}
}
