using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    //Detect the bullet
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Bullet")
		{
			Destroy(col.gameObject);
		}
	}
}
