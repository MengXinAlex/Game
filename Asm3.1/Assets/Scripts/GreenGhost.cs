using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GreenGhost : MonoBehaviour
{
	public float moveSpeed = 4.5f;

	private Node currentNode, targetNode, previousNode;
	private Vector2 direction;



	void Start()
	{
		// Find Pacman and ran away from him

		Node node = GetNodeAtPosition(transform.localPosition);

		if (node != null)
		{

			currentNode = node;
		}

		direction = Vector2.right;

		previousNode = currentNode;

		targetNode = ChooseNextNode();


	}


	void Update()
	{

		if (targetNode != currentNode && targetNode != null)
		{

			if (OverShotTarget())
			{

				currentNode = targetNode;

				transform.localPosition = currentNode.transform.position;

				targetNode = ChooseNextNode();

				previousNode = currentNode;

				currentNode = null;

			}
			else
			{


				transform.localPosition += (Vector3)direction * moveSpeed * Time.deltaTime;
			}
		}

		// Add Animation into it with direction
		GetComponent<Animator>().SetFloat("X-axis", direction.x);
		GetComponent<Animator>().SetFloat("Y-axis", direction.y);
	}


	Node ChooseNextNode()
	{

		Vector2 targetTile = Vector2.zero;
		int temp = Random.Range(0, currentNode.neighbors.Length);
		Node moveToNode = currentNode.neighbors[temp];
		direction = currentNode.directions[temp];

		return moveToNode;
	}

	Node GetNodeAtPosition(Vector2 pos)
	{

		GameObject tile = GameObject.Find("Game").GetComponent<GameBoard>().board[(int)pos.x, (int)pos.y];

		if (tile != null)
		{
			if (tile.GetComponent<Node>() != null)
			{

				return tile.GetComponent<Node>();
			}
		}

		return null;
	}



	float LengthFromNode(Vector2 targetPosition)
	{

		Vector2 vec = targetPosition - (Vector2)previousNode.transform.position;
		return vec.sqrMagnitude;
	}

	bool OverShotTarget()
	{

		float nodeToTarget = LengthFromNode(targetNode.transform.position);
		float nodeToSelf = LengthFromNode(transform.localPosition);

		return nodeToSelf > nodeToTarget;
	}
	void OnTriggerEnter2D(Collider2D co)
	{
		if (co.name == "pacman")
			SceneManager.LoadScene(2);
	}
}
