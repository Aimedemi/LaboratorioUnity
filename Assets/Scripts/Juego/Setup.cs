using UnityEngine;
using System.Collections;

public class Setup : MonoBehaviour {

	public static int puntosObjetivo;
	public static float tiempoObjetivo;

	// Esto deberia estar en el load de la escena. 
	// Originalmente lo puse en menu, pero el singleton de GameController no funcionaba entre escenas, asi que inicializo todo aca.
	void Start () {
		//Definimos objetivos

		Objetivo objetivoPuntos = new ObjetivoPuntos(puntosObjetivo);
		GameController.Instance.addObjetivo(objetivoPuntos);

		Objetivo objetivoTiempo = new ObjetivoTiempo(tiempoObjetivo);
		GameController.Instance.addObjetivo(objetivoTiempo);


		//Si uno de los objetivos es por tiempo, iniciamos el timer
		if (GameController.Instance.isPorTiempo())
		{
			GameController.Instance.timer = GameObject.FindGameObjectWithTag ("Timer").GetComponent<Timer>();
			GameController.Instance.restartTimer();
		}

		GameController.Instance.gameOver = GameObject.FindGameObjectWithTag ("Finish").GetComponent<Canvas>();
		//siBtn = siBtn.GetComponent<Button>();
		//noBtn = noBtn.GetComponent<Button>();
		GameController.Instance.gameOver.enabled = false;


		//Camera.main.transform = transform;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
