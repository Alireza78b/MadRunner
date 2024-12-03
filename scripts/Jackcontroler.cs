using UnityEngine;
using System.Collections;

public class Jackcontroler : MonoBehaviour {

	public float speed;
	public float jumpheight;
	private Rigidbody2D rigid;
	//private bool is_grounded;
	public LayerMask ground_layer;
	private Collider2D player_layer;
	public float jump_allowded;
	private float jump_count;
	private Animator anim;

	//for ground check
	//public Transform player_foot_position;
	//public float foot_radios;
	public GameObject ground_check;
	bool is_grounded;

	//for jetpack
	public float full_feul;
	public float remained_feul=2;
	public GameObject feul_bar;
	public GameObject feul_bar_index;
	Transform bar_initial_pos;
	public LayerMask jetpack_leyer;
	bool jetpack_tuched;
	int space_push_count;
	bool jet_used;
	bool fire_created;

	//for fire
	public GameObject fire;
	Transform fire_position;
	float fire_x_diference;
	float fire_y_diference;

	//for max_jump
	public GameObject max_hight_pointer;
	float max_hight;
	Transform max_hight_pos;

	//for speed change
	public GameObject land_generator;
	public float current_land_number;
	float pre_land_number;
	public float acceleration;

	//for restart
	public GameObject game_manager_object;
    Game_manager game_manager;
	public LayerMask killerground; 
	public float stop_time=1;
	float passed_time=0;
	bool killed;
	float initial_speed;


	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D>();
		player_layer=GetComponent<Collider2D>();
		anim=GetComponent<Animator>();


		//for jetpack
		space_push_count=1;
		remained_feul=full_feul;
		bar_initial_pos=feul_bar_index.transform;


		//for fire
		fire_created=false;
		fire_x_diference=transform.position.x-fire.transform.position.x;
		fire_y_diference=transform.position.y-fire.transform.position.y;
		fire_position=fire.transform;

		//for max_jump
		max_hight_pointer=GameObject.Find("max_player_hight");
		max_hight=max_hight_pointer.transform.position.y;
		max_hight_pos=max_hight_pointer.transform;

		//for restart
		game_manager=game_manager_object.GetComponent<Game_manager>();
		initial_speed=speed;



	}
	
	// Update is called once per frame
	void Update () {
		//is_grounded=Physics2D.IsTouchingLayers(player_layer,ground_layer);
		//is_grounded=Physics2D.overlapcircle(player_foot_position,foot_radios,ground_layer);
		is_grounded=ground_check.GetComponent<ground_check>().player_is_grounded;
		
		rigid.velocity = new Vector2(speed ,rigid.velocity.y);

		if(Input.GetKeyDown(KeyCode.Space)& (is_grounded ))
		{

			rigid.velocity=new Vector2(rigid.velocity.x ,jumpheight);
		}
		if(is_grounded)
		{
			space_push_count=1;
		}


		anim.SetBool("landed",is_grounded);


		//for jetpack
		jetpack_tuched=Physics2D.IsTouchingLayers(player_layer,jetpack_leyer);
		if(jetpack_tuched)
		{
			remained_feul=full_feul;
		}
		if(Input.GetKeyDown(KeyCode.Space)&!is_grounded)
		{
			space_push_count+=space_push_count;
		}

		if(Input.GetKey(KeyCode.Space)&!is_grounded &space_push_count==2&remained_feul>0)
		{

			rigid.velocity=new Vector2(rigid.velocity.x,jumpheight);
			remained_feul-= Time.deltaTime;
			jet_used=true;
		}else
		{
			jet_used=false;
		}

		if(jet_used&!fire_created)
		{
			fire_position.position=new Vector3(transform.position.x-fire_x_diference,transform.position.y-fire_y_diference,transform.position.z);
			Instantiate(fire,fire_position.position,fire_position.rotation);
			fire_created=true;
		}
		if(Input.GetKeyUp(KeyCode.Space))
		{
			fire_created=false;
		}


		//for max_hight
		if(transform.position.y>max_hight)
		{
			gameObject.transform.position=new Vector3(transform.position.x,max_hight_pos.position.y,transform.position.z);
		}

		feul_bar.transform.position=new Vector3(bar_initial_pos.position.x+(remained_feul),bar_initial_pos.transform.position.y,bar_initial_pos.transform.position.z);

		//for speed change
		current_land_number=land_generator.GetComponent<genarator>().land_counter;
		if(current_land_number>pre_land_number)
		{
			speed+=acceleration;
			pre_land_number=current_land_number;
		}


		//for restart
		if(Physics2D.IsTouchingLayers(player_layer,killerground))
		{
			killed=true;
		}
		if(killed)
		{
			speed=0;
			if(passed_time<stop_time)
			{
				passed_time+=Time.deltaTime;
			}else
			{
				game_manager.restart();
				passed_time=0;
				speed=initial_speed;
				killed=false;
			}
		}


	}
	/*public void OnTriggerEnter2d(Collider2D other)
	{
		if(other.gameObject.tag=="killbox")
		{
			killed=true;
		}
	}*/
}
