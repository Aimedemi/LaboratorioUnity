using UnityEngine;
using System.Collections;

public class Coleccionable : MonoBehaviour {

	private bool enabled = true;

	void Update () 
	{
		if (enabled)
			transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player") && enabled) {
			this.gameObject.SetActive (false);
			ControladorBola bola = other.GetComponent<ControladorBola> ();
			bola.actualizarPuntuacion ();
		}
	}

	public void desactivar(){
		this.enabled = false;
	}
}
