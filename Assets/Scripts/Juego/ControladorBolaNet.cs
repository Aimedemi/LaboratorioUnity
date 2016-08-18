using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ControladorBolaNet : NetworkBehaviour
{
    private NetworkStartPosition[] inicios;
    public int inicioIndice;
    private Vector3 originalPos;
	[SyncVar] public Color colorBola;

	private readonly Vector3 NORTE = new Vector3(0, 0, 0);
	private readonly Vector3 SUR = new Vector3(180, 0, 0);
	private readonly Vector3 ESTE = new Vector3(0, 0, 270);
	private readonly Vector3 OESTE = new Vector3(0, 0, 90);
	private readonly Vector3 FRENTE = new Vector3(90, 0, 0);
	private readonly Vector3 ATRAS = new Vector3(270, 0, 0);

    // Use this for initialization
    void Start () {
        if (isLocalPlayer)
        {
            Vector3 inicioDefault = Vector3.zero;

            inicios = FindObjectsOfType<NetworkStartPosition>();

            // Si hay algun inicio en el array, le setea el indice
            if (inicios != null && inicios.Length > 0)
            {
                inicioDefault = inicios[inicioIndice].transform.position;

				Transform posicion = this.gameObject.GetComponent<Transform> ();
				Vector3 rotacion = posicion.rotation.eulerAngles;


				switch (inicioIndice) {
				case 0:
					rotacion = NORTE;
					break;
				case 1:
					rotacion = SUR;
					break;
				case 2:
					rotacion = ESTE;
					break;
				case 3:
					rotacion = OESTE;
					break;
				case 4:
					rotacion = FRENTE;
					break;
				case 5:
					rotacion = ATRAS;
					break;
				default:
					break;
				}

            }

            // Set the player’s position to the chosen spawn point
            originalPos = inicioDefault;

			//Coloreamos su bola de acuerdo al color elegido en el lobby
			Material material = this.gameObject.GetComponent<Renderer>().material; //Extraemos el material de la bola
			material.color = colorBola; //Le aplicamos el color elegido en el lobby
        }
    }

	// Update is called once per frame
	void Update () {
	
	}

	public void actualizarPuntuacion (int valor)
	{
		string puntuaciones = "";
		GameObject[] jugadores = GameObject.FindGameObjectsWithTag("NetPlayer");

		foreach (GameObject jugador in jugadores) {
			ControladorBola bola = jugador.GetComponent<ControladorBola> ();
			bola.count = bola.count + valor;
			puntuaciones = puntuaciones + "Rocas : " + bola.count.ToString () + "\n";
		}

		GameObject canvas = GameObject.FindGameObjectWithTag ("Canvas");
		Text[] textos = canvas.GetComponentsInChildren<Text> ();

		foreach (Text texto in textos) {
			if (texto.name == "Cubos") {
				texto.text = puntuaciones;
			}
		}
	}
}