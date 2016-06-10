using UnityEngine;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using UnityEngine.SceneManagement; // neded in order to load scenes
 
public class Menu : MonoBehaviour 
{
    public Canvas quitMenu;
    public Button startBtn;
    public Button exitBtn;
    public Button multiBtn;

    void Start ()
 
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startBtn = startBtn.GetComponent<Button> ();
        exitBtn = exitBtn.GetComponent<Button> ();
        multiBtn = multiBtn.GetComponent<Button>();
        quitMenu.enabled = false;
 
    }
 
    public void ExitPress() //this function will be used on our Exit button
 
    {
        quitMenu.enabled = true; //enable the Quit menu when we click the Exit button
        startBtn.enabled = false; //then disable the Play and Exit buttons so they cannot be clicked
        exitBtn.enabled = false;
        multiBtn.enabled = false;

    }
 
    public void NoPress() //this function will be used for our "NO" button in our Quit Menu
 
    {
        quitMenu.enabled = false; //we'll disable the quit menu, meaning it won't be visible anymore
        startBtn.enabled = true; //enable the Play and Exit buttons again so they can be clicked
        exitBtn.enabled = true;
        multiBtn.enabled = true;

    }
 
    public void StartLevel (string name)
 
    {
        SceneManager.LoadScene (name);
 
    }
 
    public void ExitGame () //This function will be used on our "Yes" button in our Quit menu
 
    {
    Application.Quit(); //this will quit our game. Note this will only work after building the game
 
    }
 
}
