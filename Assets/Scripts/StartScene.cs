using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartScene : MonoBehaviour {

	public Text HighScore;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("HIGHSCORE")) {
			HighScore.text = "最短記録:" + PlayerPrefs.GetInt("HIGHSCORE").ToString()+"日";
		} else {
			HighScore.text = "最短記録:なし";
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (PlayerPrefs.HasKey ("HIGHSCORE")) {
			HighScore.text = "最短記録:" + PlayerPrefs.GetInt("HIGHSCORE").ToString()+"日";
		} else {
			HighScore.text = "最短記録:なし";
		}
	
	}
	public void Reset(){
		PlayerPrefs.DeleteKey ("HIGHSCORE");
		HighScore.text = "最短記録:なし";
		ScoreManager.instance.HighScore = -1;
	}
	public void StartButton(){
		Application.LoadLevel ("Main");
	}
}
