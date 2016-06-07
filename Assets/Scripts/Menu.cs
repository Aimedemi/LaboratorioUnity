using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void Jugar(string name){
		SceneManager.LoadScene (name);
	}
    public void Salir(){
        Application.Quit();
    }
}
