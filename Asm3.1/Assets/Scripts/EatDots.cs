using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatDots : MonoBehaviour
{
	// Eat the dots
	private bool eated = false;
	void OnTriggerEnter2D(Collider2D co)
    {   
        if (co.name == "pacman" && eated == false)
		{
			GetComponent<SpriteRenderer>().enabled = false;
            eated = true;
            //calculate score
			GameObject.Find("Game").GetComponent<GameBoard>().score += 1;
			//print(GameObject.Find("Game").GetComponent<GameBoard>().score);
			//print(gameObject);
			GameObject.Find("pacman").GetComponent<AudioSource>().Play();
		}

	}
}