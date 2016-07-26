using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
	private float secondsFinish;
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
			countDownFinishText.text = "Tiempo : " + Mathf.Round (secondsFinish);
			if (secondsFinish < 0) {
				countDownFinishText.text = "";
				contar = false;
				GM.Pause (true);
			}
		}
	}

	public void setContar(bool contar){
		this.contar = contar;
	}
	
	public float getSecondsFinish(){
		return secondsFinish;
	}

	public void setSecondsFinish(float secondsFinish){
		this.secondsFinish = secondsFinish;
	}
}