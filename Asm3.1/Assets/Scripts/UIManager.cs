using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject innerHealthBar;
    private GameObject HealthBar;
    private GameObject player;
    private Transform playerTransform;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
		reload();


	}
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    void QuitMethod()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void reload()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			
			SceneManager.LoadScene(1);
		}
		if (Input.GetKeyDown(KeyCode.Q))
		{
			
			SceneManager.LoadScene(0);
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (Time.timeScale == 0f)
				Time.timeScale = 1f;
			else
				Time.timeScale = 0f;
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			UnityEditor.EditorApplication.isPlaying = false;
			Application.Quit();
		}
	}

    
}
