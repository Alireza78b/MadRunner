using UnityEngine;
using System.Collections;

public class jetpack_destroyer : MonoBehaviour {

	public LayerMask player_layer;
	Collider2D jetpack_layer;
	bool collided;

	// Use this for initialization
	void Start () {
		jetpack_layer=GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		collided=Physics2D.IsTouchingLayers(jetpack_layer,player_layer);
		if(collided)
		{
			Destroy(gameObject);

		}
	}
}
