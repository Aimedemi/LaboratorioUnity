using UnityEngine;
using System.Collections;

abstract public class Objetivo : MonoBehaviour {

    public enum TipoObjetivo { Solo, Multi }

	protected TipoObjetivo tipo;

	protected bool cumplido;

	public abstract bool verificarObjetivo (ObjetivoDTO dto);

	public abstract string getNombreClase ();
}
