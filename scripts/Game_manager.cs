using UnityEngine;
using System.Collections;

public class Game_manager : MonoBehaviour {

	public GameObject player;
	Vector3 player_start_position;
	public Transform groundgenerator;
	Vector3 generator_start_position;

	// Use this for initialization
	void Start () {
	player_start_position=player.transform.position;
	generator_start_position=groundgenerator.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}			
}
