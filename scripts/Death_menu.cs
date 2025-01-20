using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Death_menu : MonoBehaviour {

	public string main_menu_scene;

	public Game_manager game_manager;

	public void To_main_menu()
	{
		Time.timeScale = 1f;
		Application.LoadLevel(main_menu_scene);
	}
	public void Restart()
	{
		//FindObjectOfType<>(game_manager).restart();
		//game_manager=game_manager_object.GetComponent<Game_manager>();
		Time.timeScale = 1f;
		game_manager.restart();
	}
	public void Resume()
	{
		game_manager.Resume_Manage();
	}
}
