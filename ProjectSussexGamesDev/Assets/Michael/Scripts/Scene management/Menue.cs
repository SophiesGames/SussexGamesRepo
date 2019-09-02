using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menue : MonoBehaviour
{
   
	public void Play()
	{
		SceneManager.LoadScene("Game");
	}

	public void Options()
	{
		SceneManager.LoadScene("Options");
	}

	public void BackToMenue()
	{
		SceneManager.LoadScene("Menu");
	}

	public void Quit()
	{
		Application.Quit();
		Debug.Log("Would quit on android");
	}

}
