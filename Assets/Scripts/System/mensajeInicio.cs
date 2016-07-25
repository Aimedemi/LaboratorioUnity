using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mensajeInicio : MonoBehaviour {

	public Text objetivoTiempo;
	public Text objetivoCubos;

	void Start () {
		objetivoTiempo = objetivoTiempo.GetComponent<Text>();
		objetivoCubos = objetivoCubos.GetComponent<Text>();
		objetivoCubos.text = "Juntar " + " cubos";
		objetivoTiempo.text = "en " + " segundos";
		StartCoroutine(Mensaje());
	}
	
	IEnumerator Mensaje() {
		objetivoCubos.enabled = true; // Muestra el texto
		objetivoTiempo.enabled = true;
		yield return new WaitForSeconds(3); //Espera 3 segundos
		objetivoCubos.enabled = false; // Esconde el texto
		objetivoTiempo.enabled = false;
	}
}
