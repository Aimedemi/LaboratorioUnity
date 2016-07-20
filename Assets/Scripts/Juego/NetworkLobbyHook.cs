using UnityEngine;
using Prototype.NetworkLobby;
using System.Collections;
using UnityEngine.Networking;

public class NetworkLobbyHook : LobbyHook 
{
    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>(); //Obtenemos los datos del lobby
        ControladorBolaNet bola = gamePlayer.GetComponent<ControladorBolaNet>(); //Obtenemos la bola del jugador

        bola.name = lobby.name; //Le ponemos el nombre del lobby a la bola
        bola.inicioIndice = lobby.slot; //Seteamos su posicion de inicio
		bola.colorBola = lobby.playerColor; //Seteamos el color de la bola elegido en el lobby

		GameObject planeta = GameObject.FindWithTag ("Ground"); //Obtenemos el objeto planeta
		FauxGravityAttractor atractor = planeta.GetComponent<FauxGravityAttractor>(); //Obtenemos el script de gravedad del planeta
		FauxGravityBody cuerpo = gamePlayer.GetComponent<FauxGravityBody>(); //Obtenemos el script de gravedad de la bola
		cuerpo.attractor = atractor; //Le asignamos al cuerpo la fuerza gravitatoria a la que debe responder (Planeta)

        //Eliminamos la bola de single player
        GameObject go = GameObject.FindWithTag("Player"); //Obtenemos el objeto con el tag "Player" (O sea, el jugador)
		if (go != null) { //Si todavia existe
			go.SetActive(false); //Lo desactivamos
		}


		Objetivo objetivoPuntos = new ObjetivoPuntos(20); //Juntar 20 puntos
		GameController.Instance.addObjetivo(objetivoPuntos);

		Objetivo objetivoTiempo = new ObjetivoTiempo(60.0F); //En menos de 60 segundos
		GameController.Instance.addObjetivo(objetivoTiempo);

		//Si uno de los objetivos es por tiempo, iniciamos el timer
		if (GameController.Instance.isPorTiempo())
		{
			GameController.Instance.timer = GameObject.FindGameObjectWithTag ("Timer").GetComponent<Timer>();
			GameController.Instance.restartTimer();
		}
    }
}
