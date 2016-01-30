using UnityEngine;
using System.Collections;
using System.IO;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance = null;
	public int HighScore = -1;
	public int ScoreDay = 0;
	public int RenzokScore = 0;
	public int RedPullScore = 0;

	public AudioSource source;
	public AudioClip left,right,redpull,sippai,finish;
	public string[] mes;

	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
			TextAsset csv = Resources.Load("message") as TextAsset;
			StringReader reader = new StringReader(csv.text);
			while (reader.Peek() > -1) {
				string line = reader.ReadLine();
				string[] values = line.Split(',');
				mes = new string[values.Length];
				for (int i = 0; i < values.Length; i++) {
					mes [i] = values [i];
					Debug.Log (mes[i]);
				}

			}
		} else {
			Destroy (this.gameObject);
		}
		source = GetComponent<AudioSource> ();
	}
	public void Sound(string key){
		switch (key) {
		case "left":
			source.clip = left;
			source.volume = 0.2f;
			source.Play ();
			break;
		case "right":
			source.clip = right;
			source.volume = 0.2f;
			source.Play ();
			break;
		case "redpull":
			source.clip = redpull;
			source.volume = 1.0f;
			source.Play ();
			break;
		case "sippai":
			source.clip = sippai;
			source.volume = 0.5f;
			source.Play ();
			break;
		case "finish":
			source.clip = finish;
			source.volume = 1.0f;
			source.Play ();
			break;
		default:
			break;
		}
	}

}
