using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // se necesita para cargar las escenas
 
public class Menu : MonoBehaviour{
    public Canvas quitMenu;
    public Button singleBtn;
    public Button exitBtn;
    public Button multiBtn;
    public Button creditBtn;

    void Start (){
        quitMenu = quitMenu.GetComponent<Canvas>();
        singleBtn = singleBtn.GetComponent<Button> ();
        exitBtn = exitBtn.GetComponent<Button> ();
        multiBtn = multiBtn.GetComponent<Button>();
        creditBtn = creditBtn.GetComponent<Button>();
        quitMenu.enabled = false;
    }

    public void ExitPress(){ //Esta funcion hace visible el menu para confirmar la salida
        quitMenu.enabled = true; //Muestra el QuitMenu cuando se presiona Salir
        singleBtn.enabled = false; //Desaparece la opcion de hacer click en los demas botones
        exitBtn.enabled = false;
        multiBtn.enabled = false;
    }

    public void NoPress(){ //Esta funcion hace invisible el QuitMenu
        quitMenu.enabled = false;
        singleBtn.enabled = true;
        exitBtn.enabled = true;
        multiBtn.enabled = true;
    }

    public void StartLevel (string name){ //Este funcion sirve para que un boton cargue cualquier escena ya que se le pasa el nombre de la escena
        SceneManager.LoadScene (name);
    }
 
    public void ExitGame (){ //Esta funcion es utilizada cuando se hace click en SI en el QuitMenu
        Application.Quit(); 
    }
 
}
