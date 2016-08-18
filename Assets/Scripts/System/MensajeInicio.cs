using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MensajeInicio : MonoBehaviour {

	public Text objetivoTiempo;
	public Text objetivoCubos;

	public void mostrarObjetivos(Objetivo[] objetivos){
		objetivoTiempo = objetivoTiempo.GetComponent<Text>();
		objetivoCubos = objetivoCubos.GetComponent<Text>();
		int puntos = 0;
		float tiempo = 0.0f;

		//Buscamos los objetivos
		foreach (Objetivo o in objetivos)
		{
			if (o is ObjetivoTiempo)
			{
				tiempo = ((ObjetivoTiempo) o).getTiempoObjetivo();
			}
			if (o is ObjetivoPuntos) 
			{
				puntos = ((ObjetivoPuntos)o).getPuntosObjetivo();
			}
		}

		objetivoCubos.text = "Juntar " + puntos + " rocas";
		objetivoTiempo.text = "en " + tiempo + " segundos";
		StartCoroutine(Mensaje(3)); //Muestra el mensaje por 3 segundos
	}
	
	IEnumerator Mensaje(int segundos) {
		objetivoCubos.enabled = true; // Muestra el texto
		objetivoTiempo.enabled = true;
		yield return new WaitForSeconds(segundos); //Espera X segundos
		objetivoCubos.enabled = false; // Esconde el texto
		objetivoTiempo.enabled = false;
	}
}
