using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ControladorBolaNet : NetworkBehaviour
{
    private NetworkStartPosition[] inicios;
    public int inicioIndice;
    private Vector3 originalPos;

    // Use this for initialization
    void Start () {
        if (isLocalPlayer)
        {
            Vector3 inicioDefault = Vector3.zero;

            inicios = FindObjectsOfType<NetworkStartPosition>();

            // Si hay algun inicio en el array, elige uno al azar.
            if (inicios != null && inicios.Length > 0)
            {
                inicioDefault = inicios[inicioIndice].transform.position;
            }

            // Set the player’s position to the chosen spawn point
            originalPos = inicioDefault;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
