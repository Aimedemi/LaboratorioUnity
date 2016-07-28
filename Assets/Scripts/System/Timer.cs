using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
	private float secondsFinish;
	public Text countDownFinishText;
	private GameController GM;
	private bool contar=true;
	private bool pausa = false;
	public Sprite imgPausa;
	public Sprite imgPlay;
	public Image imgEstado;


	void Awake(){
		GM = GameController.Instance;
	}

	public void swapPausa (){
		pausa = (!pausa) ? true : false;
		Time.timeScale = (pausa) ? 0 : 1;
		imgEstado.sprite = (pausa) ? imgPlay : imgPausa;

	}
	void Start ()
	{
		imgEstado = imgEstado.GetComponent<Image>();
		imgEstado.sprite = imgPausa;
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