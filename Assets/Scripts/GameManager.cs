using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	bool left = false;
	bool right = false;
	public Text message;
	public Text shintyokuMess;
	public Text dayLabel;
	public GameObject bar;
	public GameObject TimeBar;
	public GameObject RedPull;

	int sintyoku = 0;
	float percent;
	float timer = -1;
	int day = 1;
	int count = 0;
	int redtiming = 50;
	int renzoku = 0;
	int redcount = 0;


	// Use this for initialization
	void Start () {

		left = false;
		right = false;
		timer = -1;
		day = 1;
		RedPull.SetActive (false);
		redtiming = Random.Range (18,23);

		renzoku = 0;
		redcount = 0;
		ScoreManager.instance.RenzokScore = 0;
		ScoreManager.instance.RedPullScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= 0) {
			timer += Time.deltaTime;
			TimeBar.GetComponent<Image> ().fillAmount = timer / 10.0f;
		}
		percent = sintyoku / 500f;
		bar.GetComponent<Image> ().fillAmount = percent;
		shintyokuMess.text = "進捗"+((percent * 100)).ToString ("f0")+"%";
		if (percent * 100 >= 100) {
			
			if(PlayerPrefs.HasKey("HIGHSCORE")){
				int nowScore = PlayerPrefs.GetInt ("HIGHSCORE");
				if (day < nowScore) {
					PlayerPrefs.SetInt ("HIGHSCORE",day);
					ScoreManager.instance.HighScore = day;
				}
			}else{
				PlayerPrefs.SetInt("HIGHSCORE",day);
			}
			ScoreManager.instance.Sound ("finish");
			ScoreManager.instance.ScoreDay = day;
			Application.LoadLevel ("Result");
			
		}
		if (timer >= 10) {
			timer = 0;
			day++;
		}
		dayLabel.text = day.ToString()+"日目";

		if (count > ScoreManager.instance.RenzokScore) {
			ScoreManager.instance.RenzokScore = count;
		}
		
		
	}

	public void LeftButton(){
		if (timer < 0) {
			timer = 0;
		}
		if (!left) {
			sintyoku++;
			count++;
			ScoreManager.instance.Sound ("left");
			if (count % redtiming == 0) {
				RedPull.SetActive (true);
				Invoke ("DeleteRed",0.75f);
			} else {
				
			}
		} else {
			ScoreManager.instance.Sound ("sippai");
			MessageChange ();
			count = 0;
		}

		left = true;
		right = false;
		
	}
	public void RightButton(){
		if (timer < 0) {
			timer = 0;
		}
		if (!right) {
			sintyoku++;
			count++;
			ScoreManager.instance.Sound ("right");
			if (count % redtiming == 0) {
				RedPull.SetActive (true);
				Invoke ("DeleteRed",0.75f);
			} else {
				
			}
		} else {
			ScoreManager.instance.Sound ("sippai");
			count = 0;
			MessageChange ();
		}

		left = false;
		right = true;

	}
	public void RedButton(){
		sintyoku += 50;
		count = 0;
		GetComponent<AudioSource> ().clip = ScoreManager.instance.redpull;
		GetComponent<AudioSource> ().Play ();
		//ScoreManager.instance.Sound ("redpull");
		RedPull.SetActive (false);
		redtiming = Random.Range (40,50);
		ScoreManager.instance.RedPullScore++;
	}

	public void DeleteRed(){
		RedPull.SetActive (false);
	}

	void MessageChange(){
		message.text = ScoreManager.instance.mes[Random.Range(0,ScoreManager.instance.mes.Length)];
	}
}
