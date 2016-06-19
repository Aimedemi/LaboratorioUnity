using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
	public float secondsFinish;
	public Text countDownFinishText;
	private GameController GM;
	private bool contar=true;

	void Awake(){
		GM = GameController.Instance;

	}
	void Start ()

	{
		countDownFinishText = countDownFinishText.GetComponent<Text>();

	}

	void Update ()
	{
		if (contar) {
			secondsFinish -= Time.deltaTime;
			countDownFinishText.text = "Time Left:" + Mathf.Round (secondsFinish);
			if (secondsFinish < 0) {
				countDownFinishText.text = "";
				contar = false;
				GM.Pause (true);
			}
		}
	}
}