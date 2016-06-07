using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {

	public Text timeDownText;
	public float seconds;
	public int waitTime;
	// Use this for initialization
	void Start () {
		timeDownText = GetComponent<Text> () as Text;
	}
	
	// Update is called once per frame
	void Update () {
		GetCountDown ();
		seconds = waitTime-(int)(Time.time % 60f);
	}

	void GetCountDown ()
	{
		if (seconds < 0) {
			timeDownText.text = "";
		}
		else if (seconds < 1) {
			timeDownText.text = "Go!";
		} 
		else {
			timeDownText.text = seconds.ToString("00");
		}

	}
}
