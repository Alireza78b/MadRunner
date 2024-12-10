using UnityEngine;
using System.Collections;

public class ground_check : MonoBehaviour {

	Collider2D foot_collider;
	public LayerMask ground_layer;
	public bool player_is_grounded;

	// Use this for initialization
	void Start () {

		foot_collider=GetComponent<Collider2D>();
	
	}
	
	// Update is called once per frame
	void Update () {

		player_is_grounded=Physics2D.IsTouchingLayers(foot_collider,ground_layer);
		
	
	}
}
