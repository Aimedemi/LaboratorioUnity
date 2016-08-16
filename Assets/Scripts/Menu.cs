using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // se necesita para cargar las escenas
 
public class Menu : MonoBehaviour{
    public Canvas quitMenu;
	public Canvas difficultyMenu;
    public Button singleBtn;
    public Button exitBtn;
    public Button multiBtn;
    public Button creditBtn;
	public string nivelInicial;

    void Start (){
        quitMenu = quitMenu.GetComponent<Canvas>();
        singleBtn = singleBtn.GetComponent<Button> ();
        exitBtn = exitBtn.GetComponent<Button> ();
        multiBtn = multiBtn.GetComponent<Button>();
        creditBtn = creditBtn.GetComponent<Button>();
        quitMenu.enabled = false;
		difficultyMenu.enabled = false;
    }

    public void ExitPress(){ //Esta funcion hace visible el menu para confirmar la salida
        quitMenu.enabled = true; //Muestra el QuitMenu cuando se presiona Salir
        singleBtn.enabled = false; //Desaparece la opcion de hacer click en los demas botones
        exitBtn.enabled = false;
        multiBtn.enabled = false;
		creditBtn.enabled = false;
    }

    public void NoPress(){ //Esta funcion hace invisible el QuitMenu
        quitMenu.enabled = false;
        singleBtn.enabled = true;
        exitBtn.enabled = true;
        multiBtn.enabled = true;
		creditBtn.enabled = true;
    }

	public void singlePlayer(){
		difficultyMenu.enabled = true;
		singleBtn.enabled = false; //Desaparece la opcion de hacer click en los demas botones
		exitBtn.enabled = false;
		multiBtn.enabled = false;
		creditBtn.enabled = false;
	}

	public void backPressed(){
		difficultyMenu.enabled = false;
		singleBtn.enabled = true;
		exitBtn.enabled = true;
		multiBtn.enabled = true;
		creditBtn.enabled = true;
	}

	public void facil(){
		Setup.puntosObjetivo = 30;
		Setup.tiempoObjetivo = 150.0F;

		this.StartLevel (nivelInicial);
	}

	public void normal(){
		Setup.puntosObjetivo = 40;
		Setup.tiempoObjetivo = 120.0F;

		this.StartLevel (nivelInicial);
	}

	public void dificil(){
		Setup.puntosObjetivo = 50;
		Setup.tiempoObjetivo = 90.0F;

		this.StartLevel (nivelInicial);
	}

    public void StartLevel (string nivel){ //Este funcion sirve para que un boton cargue cualquier escena ya que se le pasa el nombre de la escena
		SceneManager.LoadScene (nivel);
    }
 
    public void ExitGame (){ //Esta funcion es utilizada cuando se hace click en SI en el QuitMenu
        Application.Quit(); 
    }
 
}
