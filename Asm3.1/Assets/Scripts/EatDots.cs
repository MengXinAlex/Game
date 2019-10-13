using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatDots : MonoBehaviour
{
    // Eat the dots
    void OnTriggerEnter2D(Collider2D co)
    {   
        if (co.name == "pacman")
			GetComponent<SpriteRenderer>().enabled = false;
	}
}
