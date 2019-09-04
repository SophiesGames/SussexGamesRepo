using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   
	public void Play()
	{
		SceneManager.LoadScene("Game");
        Debug.Log("Loading game");
	}

	public void Options()
	{
		SceneManager.LoadScene("Options");
	}

	public void BackToMenu()
	{
		SceneManager.LoadScene("Menu");
	}

    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

	public void Quit()
	{
		Application.Quit();
		Debug.Log("Would quit on android");
	}

}
