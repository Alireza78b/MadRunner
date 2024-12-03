using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game_manager : MonoBehaviour {

	public GameObject player;
	Vector3 player_start_position;
	public Transform groundgenerator;
	Vector3 generator_start_position;
	float initial_speed;

	//for destroy grounds during restart
	groundDistroyer[] remained_grounds_array;

	// Use this for initialization
	void Start () {
	player_start_position=player.transform.position;
	generator_start_position=groundgenerator.position;
	initial_speed=player.GetComponent<Jackcontroler>().speed;

	//for restart
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}		

	public void restart()
	{
		player.transform.position=player_start_position;
		groundgenerator.position=generator_start_position;
		
		
		remained_grounds_array=FindObjectsOfType<groundDistroyer>();
		for(int i=0;i<remained_grounds_array.Length;i++)
		{
			Destroy(remained_grounds_array[i].gameObject);
		}
		
	}	
}
