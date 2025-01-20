using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text Score_Text;
	public Text Record_Text;
	public Text Coin_text;
	public float Score_number;
	public float Record_Number;
	public float coin_number;
	public genarator ground_generator;

	// Use this for initialization
	void Start () {
		Record_Number=0;
	}
	
	// Update is called once per frame
	void Update () {
		Score_number=ground_generator.GetComponent<genarator>().land_counter;
		if(Score_number>Record_Number)
		{
			Record_Number=Score_number;
		}
		Score_Text.text="Score: "+Score_number;
		Record_Text.text="Record: "+Record_Number;

	}

	public void coin_increase()
	{
		coin_number+=1;
		Coin_text.text=" "+coin_number;
	}
	
}
