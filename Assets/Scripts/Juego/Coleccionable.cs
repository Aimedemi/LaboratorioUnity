using UnityEngine;
using System.Collections;

public class Coleccionable : MonoBehaviour {

	private bool enabled = true;
	public int valor;

	//Funcion comentada por causar slow downs
	/*
	void Update () 
	{
		if (enabled)
			transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}*/

	void OnTriggerEnter(Collider other)
	{
		if ((other.gameObject.CompareTag ("Player") || other.gameObject.CompareTag ("NetPlayer")) && enabled) {
			this.gameObject.SetActive (false);

			ControladorBola bola = other.GetComponent<ControladorBola> ();
			ControladorBolaNet bolaNet = other.GetComponent<ControladorBolaNet> ();

			//Si es una partida multijugador, actualiza el total de puntos de este jugador
			if (bolaNet != null) {
				bolaNet.actualizarPuntuacion (valor);
			} else { //Si es offline, actualiza la puntuacion global
				bola.actualizarPuntuacion (valor);
			}
		}
	}

	public void desactivar(){
		this.enabled = false;
	}
}
