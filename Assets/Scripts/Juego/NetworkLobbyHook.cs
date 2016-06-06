using UnityEngine;
using Prototype.NetworkLobby;
using System.Collections;
using UnityEngine.Networking;

public class NetworkLobbyHook : LobbyHook 
{
    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
		ControladorBola bola = gamePlayer.GetComponent<ControladorBola>();

        bola.name = lobby.name;
		bola.inicioIndice = lobby.slot;
		Material material = bola.GetComponent<Renderer> ().material;
		material.color = lobby.playerColor;
    }
}
