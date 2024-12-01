using UnityEngine;
using System.Collections;

public class fire_destroy : MonoBehaviour {

	public GameObject player;
	Transform player_transform;
	// Use this for initialization
	void Start () {
	
		player=GameObject.Find("player_fire_position");
		player_transform=player.transform;

	}
	
	// Update is called once per frame
	void Update () {

		gameObject.transform.position=new Vector3(player_transform.position.x,player_transform.position.y,player_transform.position.z);

	    if(Input.GetKeyUp(KeyCode.Space))
		{
			Destroy(gameObject);
		}
	}
}
