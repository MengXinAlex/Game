using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
		InputManage();


	}
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
	public void LoadHelpLevel()
	{
		SceneManager.LoadScene(3);
	}
	public void LoadStartLevel()
	{
		SceneManager.LoadScene(0);
	}

	void QuitMethod()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void InputManage()
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
