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

			if (this.name == "Pick Up S") {
				bola.actualizarPuntuacion (25);
			} else {
				bola.actualizarPuntuacion (1);
			}

		}
	}

	public void desactivar(){
		this.enabled = false;
	}
}
