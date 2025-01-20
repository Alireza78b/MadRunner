using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine.SceneManagement;(need unity version up to 5.3)

public class main_menu : MonoBehaviour {

	public string game_scene;

	public void PlayGame()
	{
		Application.LoadLevel(game_scene);
		//SceneManager.LoadScene(game_scene);(for unity version up to 5.3)
	}
	public void QuitGame()
	{
		Application.Quit();
	}
}
