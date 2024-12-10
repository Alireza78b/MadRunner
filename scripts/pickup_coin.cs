using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class pickup_coin : MonoBehaviour {

	public LayerMask player_layer;
	Collider2D coin_collider;
	ScoreManager ScoreManager;
    bool coin_tuched;
	float job_order=0;
	AudioSource coin_sound;
	float refresh=0;


	// Use this for initialization
	void Start () {
		coin_collider=GetComponent<Collider2D>();
		ScoreManager=FindObjectOfType<ScoreManager>();
		//coin_sound=GameObject.Find("pick_coin_sound").GetComponent<AudioSource>();
		coin_sound=gameObject.GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {

		coin_tuched=Physics2D.IsTouchingLayers(coin_collider,player_layer);
		
			
		
		if (coin_tuched&job_order==0)
		{
			coin_sound.Play();
			ScoreManager.coin_increase();
			job_order+=1;
		}
		if(job_order==1)
		{
            refresh+=Time.deltaTime;
			if(refresh>0.2f)
			{
				gameObject.SetActive(false);
			}
		}
	
	}
}
