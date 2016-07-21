using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public Canvas gameOver;
	public Button siBtn;
	public Button noBtn;

    void Start () {
        gameOver = gameOver.GetComponent<Canvas>();
		siBtn = siBtn.GetComponent<Button>();
		noBtn = noBtn.GetComponent<Button>();
		gameOver.enabled = false;
    }

	public void reiniciarNivel (string name){
		SceneManager.LoadScene (name);
	}

	public void volverMenu (string name){ 
		SceneManager.LoadScene (name);
	}

	public void activarGO () {
		gameOver.enabled = true;
	}
}
