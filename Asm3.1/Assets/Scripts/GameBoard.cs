using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameBoard : MonoBehaviour
{
    // this is to store node on board
	private static int boardWidth = 28;
	private static int boardHeight = 36;
	public int score = 0;
    public int isStage2;
	public int kills = 0;
	public GameObject[,] board = new GameObject[boardWidth, boardHeight];
	public GameObject Gun;
	private bool settle = false;
	// Start is called before the first frame update
	void Awake()
	{

		isStage2 = 1;
	}
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

    void Update()
	{
        if(score == 330)
		{
			Vector3 pos = GameObject.Find("Pink").transform.position;

			Instantiate(Gun, pos, gameObject.transform.rotation);
			score += 1;
		}
        if(isStage2 == 2 && !settle)
		{
			settle = true;
			GameObject.Find("Red").GetComponent<Animator>().SetBool("Stage2", true);
			GameObject.Find("Blue").GetComponent<Animator>().SetBool("Stage2", true);
			GameObject.Find("Pink").GetComponent<Animator>().SetBool("Stage2", true);
			GameObject.Find("Green").GetComponent<Animator>().SetBool("Stage2", true);
			GameObject.Find("pacman").GetComponent<Animator>().SetBool("Stage2", true);
		}

        if(kills == 4)
			SceneManager.LoadScene(4);
	}

}
