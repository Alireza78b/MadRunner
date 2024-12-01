using UnityEngine;
using System.Collections;

public class genarator : MonoBehaviour {

	//public GameObject the_ground;
	public GameObject[] the_grounds;
	int ground_selector;
	public Transform next_ground_pointer;
    float distance_from_prevous;
	float ground_width;
	public float max_distance;
	public float min_distance;
	float initial_hight;
	public GameObject max_hight_index;
    float max_hight_allowded;
    float added_hight;
	float prevous_added_hight;
	public float land_counter;

	//bellow is for jetpack
	public GameObject jetpack;
	public float jet_generate_chance;
	float jet_random_num;
	Vector3 jet_position;
	

	//public float[] widths;

	// Use this for initialization
	void Start () {
	
		ground_width=the_grounds[ground_selector].GetComponent<BoxCollider2D>().size.x;
		max_hight_allowded=max_hight_index.transform.position.y;
		initial_hight=transform.position.y;
		// widths=new float[the_grounds.Length];
		// for(int i=0;i < the_grounds.Length;i++)
		// {
		// 	widths[i]=the_grounds[i].GetComponent<BoxCollider2D>().size.x;
		// }

		//bellow is for jetpack
		if(jet_generate_chance<=0 || jet_generate_chance>100)
		{
			jet_generate_chance=20;
		}




	}
	
	// Update is called once per frame
	void Update () {

		ground_selector=Random.Range(0,the_grounds.Length);

		if(transform.position.x<next_ground_pointer.position.x)
		{
			added_hight=Random.Range(0,(max_hight_allowded-initial_hight));
		Instantiate(/*the_ground*/the_grounds[ground_selector],transform.position,transform.rotation);
		land_counter=land_counter+1;

			//for jetpack
			jet_random_num=Random.Range(0,100);
			if(jet_generate_chance>jet_random_num)
			{
				jet_position=new Vector3(transform.position.x+(Random.Range(1,the_grounds[ground_selector].GetComponent<BoxCollider2D>().size.x-1)),transform.position.y+Random.Range(1,3),transform.position.z);
				Instantiate(jetpack,jet_position,transform.rotation);
			}


		distance_from_prevous=Random.Range(min_distance,max_distance);
			if(added_hight-prevous_added_hight>0.5&distance_from_prevous>4)
			{
				distance_from_prevous=distance_from_prevous-2;
			}
			else if (added_hight-prevous_added_hight<(-0.5))
			{
				distance_from_prevous=distance_from_prevous+1;
			}
			while(added_hight-prevous_added_hight>1.8)
			{
				added_hight=added_hight-1;
			}
		ground_width=the_grounds[ground_selector].GetComponent<BoxCollider2D>().size.x;
		transform.position=new Vector3(transform.position.x+distance_from_prevous+ground_width,initial_hight+added_hight,transform.position.z);
			prevous_added_hight=added_hight;
		
		}
	}
}
