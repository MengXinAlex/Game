using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 dest = Vector2.zero;
	private Vector2 nextDest;
	private Node currentNode;
	private Node previousNode;
	private Node targetNode;

	public AudioClip eatDotSound;
	public AudioSource audio;

    void Awake()
	{
		audio = transform.GetComponent<AudioSource>();
	}

	// Start is called before the first frame update
	void Start()
    {
		
        //Set current Node position from board
		currentNode = GameObject.Find("Game").GetComponent<GameBoard>()
            .board[(int)transform.localPosition.x, (int)transform.localPosition.y]
                .GetComponent<Node>();

		dest = Vector2.right;
		ChangePosition(dest);


	}


    void Update()
    {


		// Get input
		if (Input.GetKey(KeyCode.A))
		{
			ChangePosition(Vector2.left);

		}
		else if (Input.GetKey(KeyCode.D))
		{

			ChangePosition(Vector2.right);

		}
		else if (Input.GetKey(KeyCode.W))
		{

			ChangePosition(Vector2.up);

		}
		else if (Input.GetKey(KeyCode.S))
		{

			ChangePosition(Vector2.down);
		}

		//Now we move!
		if (targetNode != currentNode && targetNode != null)
		{
            // Change the direction during even though not arrived the node
			if (nextDest == dest * -1)
			{

				dest *= -1;

				Node tempNode = targetNode;

				targetNode = previousNode;

				previousNode = tempNode;
			}

            //Check if touched the waall
			if (OverShotTarget())
			{
				currentNode = targetNode;

				transform.localPosition = currentNode.transform.position;

				Node moveToNode = CanMove(nextDest);

				if (moveToNode != null)
					dest = nextDest;

				if (moveToNode == null)
					moveToNode = CanMove(dest);

				if (moveToNode != null)
				{

					targetNode = moveToNode;
					previousNode = currentNode;
					currentNode = null;

				}
				else
				{

					dest = Vector2.zero;
				}

			}
			else
			{

				transform.localPosition += (Vector3)(dest * speed) * Time.deltaTime;
			}
		}




		// Add Animation into it with direction
		if (GameObject.Find("Game").GetComponent<GameBoard>().isStage2 == 1)
		{
			GetComponent<Animator>().SetFloat("X-axis", dest.x);
			GetComponent<Animator>().SetFloat("Y-axis", dest.y);
		}

	}


	void ChangePosition(Vector2 dir)
	{

		if (dir != dest)
			nextDest = dir;

		if (currentNode != null)
		{

			Node moveToNode = CanMove(dir);

			if (moveToNode != null)
			{

				dest = dir;
				targetNode = moveToNode;
				previousNode = currentNode;
				currentNode = null;
			}
		}
	}

	//Check if PacMan can move
	Node CanMove(Vector2 d)
	{

		Node moveToNode = null;

		for (int i = 0; i < currentNode.neighbors.Length; i++)
		{

			if (currentNode.directions[i] == d)
			{

				moveToNode = currentNode.neighbors[i];
				break;
			}
		}

		return moveToNode;
	}


	bool OverShotTarget()
	{

		float nodeToTarget = LengthFromNode(targetNode.transform.position);
		float nodeToSelf = LengthFromNode(transform.localPosition);
		return nodeToSelf > nodeToTarget;
	}

    
	float LengthFromNode(Vector2 targetPosition)
	{

		Vector2 vec = targetPosition - (Vector2)previousNode.transform.position;
		return vec.sqrMagnitude;
	}


}
