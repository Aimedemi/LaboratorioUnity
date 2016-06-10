using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;

    private GameController(){
    }

    public static GameController Instance{
        get{
            if (instance == null){
                instance = new GameController();
            }

            return instance;
        }
    }

    // Add your game mananger members here
    public void Pause(bool paused){
    }

}
