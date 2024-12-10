using UnityEngine;
using UnityEngine.UI;
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

	//for time pass
	public Jackcontroler kill_check;
	bool killed1;
	public float stop_time=1;
	float passed_time=0;

	//for death sound
    public AudioSource death_sound;

	// Use this for initialization
	void Start () {
	player_start_position=player.transform.position;
	generator_start_position=groundgenerator.position;
	initial_speed=player.GetComponent<Jackcontroler>().speed;
	kill_check=player.GetComponent<Jackcontroler>();
	
	
	

	}
	
	// Update is called once per frame
	void Update () {
		
		killed1=kill_check.killed;
		if(killed1)
		{

			if(passed_time==0)
			{
				death_sound.Play();
			}else if(passed_time>=stop_time)
			{
				death_sound.Stop(); 
			}
			
		    if(passed_time<stop_time)
			{
				player.SetActive(false);
				passed_time+=Time.deltaTime;
				
				
			}else
		    {
				player.SetActive(true);
				kill_check.after_kill();
				
		    }
	
	    }
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
		passed_time=0;
		
	}	
}
