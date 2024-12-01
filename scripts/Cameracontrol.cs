using UnityEngine;
using System.Collections;

public class Cameracontrol : MonoBehaviour {

	public Jackcontroler player_access;
	Vector3 last_position_of_player;
	float postion_diference;

	// Use this for initialization
	void Start () {
		player_access=FindObjectOfType<Jackcontroler>();
		last_position_of_player=player_access.transform.position;
		postion_diference=last_position_of_player.x-transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player_access.transform.position.x-postion_diference ,transform.position.y,transform.position.z);

	}
}
