using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour {

	public Text result;
	public GameObject button;


	// Use this for initialization
	void Start () {
		button.SetActive (false);
		Invoke ("ReStartButton",3.0f);
	
	}
	
	// Update is called once per frame
	void Update () {
		string kekka;
		kekka = "執筆期間:" + ScoreManager.instance.ScoreDay.ToString () + "日\n\n";
		kekka += "連続成功プッシュ回数:"+ScoreManager.instance.RenzokScore.ToString ()+"回\n\n";
		kekka += "レッドプル回数:"+ScoreManager.instance.RedPullScore.ToString ()+"";
		result.text = kekka;
			
	
	}
	void ReStartButton(){
		button.SetActive (true);
	}

	public void ToStart(){
		Application.LoadLevel ("Start");
	}
}
