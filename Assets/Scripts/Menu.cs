using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public void Jugar(string name){
        Application.LoadLevel(name);
    }
    public void Salir(){
        Application.Quit();
    }
}
