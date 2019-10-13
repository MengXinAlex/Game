using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //Save neighbor nodes and their x,y direction
	public Node[] neighbors;
	public Vector2[] directions;
    public 

	// Start is called before the first frame update
	void Start()
	{
        
		directions = new Vector2[neighbors.Length];

		for (int i = 0; i < neighbors.Length; i++)
		{

			Node neighbor = neighbors[i];

			Vector2 tempVector = neighbor.transform.localPosition - transform.localPosition;

			directions[i] = tempVector.normalized;
		}
	}
}