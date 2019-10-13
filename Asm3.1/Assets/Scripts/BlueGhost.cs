using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BlueGhost : MonoBehaviour
{
	public float moveSpeed = 4.5f;

	private GameObject pacMan;

	private Node currentNode, targetNode, previousNode;
	private Vector2 direction;



	void Start()
	{
		// Find Pacman and ran away from him
		pacMan = GameObject.FindGameObjectWithTag("PacMan");

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

		Vector2 pacmanPosition = pacMan.transform.position;
		targetTile = new Vector2(Mathf.RoundToInt(pacmanPosition.x), Mathf.RoundToInt(pacmanPosition.y));

		Node moveToNode = null;

		Node[] foundNodes = new Node[4];
		Vector2[] foundNodesDirection = new Vector2[4];

		int nodeCounter = 0;

		for (int i = 0; i < currentNode.neighbors.Length; i++)
		{

			if (currentNode.directions[i] != direction * -1)
			{

				foundNodes[nodeCounter] = currentNode.neighbors[i];
				foundNodesDirection[nodeCounter] = currentNode.directions[i];
				nodeCounter++;
			}
		}

		if (foundNodes.Length == 1)
		{

			moveToNode = foundNodes[0];
			direction = foundNodesDirection[0];
		}

		if (foundNodes.Length > 1)
		{

			float leastDistance = -1f;

			for (int i = 0; i < foundNodes.Length; i++)
			{

				if (foundNodesDirection[i] != Vector2.zero)
				{

					float distance = GetDistance(foundNodes[i].transform.position, targetTile);

					if (distance > leastDistance)
					{

						leastDistance = distance;
						moveToNode = foundNodes[i];
						direction = foundNodesDirection[i];
					}
				}
			}
		}

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

	float GetDistance(Vector2 posA, Vector2 posB)
	{

		float dx = posA.x - posB.x;
		float dy = posA.y - posB.y;

		float distance = Mathf.Sqrt(dx * dx + dy * dy);

		return distance;
	}
	void OnTriggerEnter2D(Collider2D co)
	{
		if (co.name == "pacman")
			SceneManager.LoadScene(2);
	}
}
