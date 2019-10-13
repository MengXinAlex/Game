using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    // this is to store node on board
	private static int boardWidth = 28;
	private static int boardHeight = 36;

	public GameObject[,] board = new GameObject[boardWidth, boardHeight];
	// Start is called before the first frame update
	void Start()
    {

		Object[] objects = GameObject.FindObjectsOfType(typeof(GameObject));

		foreach (GameObject o in objects)
		{

			Vector2 pos = o.transform.position;
			//pos.x += 14.5f;
			//pos.y += 14.5f;

			if (o.name != "pacman" && o.name != "Red")
				board[(int)pos.x, (int)pos.y] = o;

		}
	}

}
