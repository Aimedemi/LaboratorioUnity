using UnityEngine;
using System.Collections;

public class Setup : MonoBehaviour {

	// Esto deberia estar en el load de la escena. 
	// Originalmente lo puse en menu, pero el singleton de GameController no funcionaba entre escenas, asi que inicializo todo aca.
	void Start () {
		//Definimos objetivos

		Objetivo objetivoPuntos = new ObjetivoPuntos(8); //Juntar 8 puntos
		GameController.Instance.addObjetivo(objetivoPuntos);

		Objetivo objetivoTiempo = new ObjetivoTiempo(30.0F); //En menos de 30 segundos
		GameController.Instance.addObjetivo(objetivoTiempo);

		//Si uno de los objetivos es por tiempo, iniciamos el timer
		if (GameController.Instance.isPorTiempo())
		{
			GameController.Instance.timer = GameObject.FindGameObjectWithTag ("Timer").GetComponent<Timer>();
			GameController.Instance.restartTimer();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
