using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D co)
	{
		if (co.name == "pacman")
		{
			GameObject.Find("Game").GetComponent<GameBoard>().isStage2 = 2;
			Destroy(gameObject);
		}
	}
}
