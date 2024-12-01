using UnityEngine;
using System.Collections;

public class groundDistroyer : MonoBehaviour {

	public GameObject destroyer_position;

	// Use this for initialization
	void Start () {
	
		destroyer_position=GameObject.Find("destroyPosition");
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.position.x<destroyer_position.transform.position.x)
		{
			Destroy(gameObject);
		}
	}
}
