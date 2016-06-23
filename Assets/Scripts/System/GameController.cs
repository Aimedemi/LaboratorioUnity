using UnityEngine;
using UnityEngine.SceneManagement; // neded in order to load scenes

public class GameController : Singleton<GameController>
{
    public ControladorBola[] jugadores;
    public Objetivo[] objetivos;
    public Timer timer;

	protected GameController(){}

    public void restartTimer()
    {
		foreach (Objetivo o in objetivos)
		{
			if (o is ObjetivoTiempo)
			{
				timer.setSecondsFinish(((ObjetivoTiempo)o).getTiempoObjetivo());
			}
		}
    }

    public void addObjetivo(Objetivo objetivo)
    {
		if (objetivos == null) { //Si no hay objetivos, agrego el que llega
			objetivos = new Objetivo[1];
			objetivos [0] = objetivo;
		} else { //Si los hay, redimensiono el vector y agrego uno
			int indice = objetivos.Length; //Obtengo la longitud actual
			Objetivo[] objetivoTemp = new Objetivo[indice + 1]; //Redimensiono con un lugar mas
			int i = 0;
			foreach (Objetivo o in objetivos) //Copio los ya existentes al nuevo vector
			{
				objetivoTemp[i] = o;
				i++;
			}
			objetivoTemp[i] = objetivo; //Agregamos el que recibimos al nuevo vector.

			objetivos = objetivoTemp; //Sobrescribo el anterior vector.
		}
    }

    public void addJugador(ControladorBola jugador)
    {
		if (jugadores == null) { //Si no hay jugadores, agrego el que llega
			jugadores = new ControladorBola[1];
			jugadores [0] = jugador;
		} else { //Si los hay, redimensiono el vector y agrego uno
			int indice = jugadores.Length; //Obtengo la longitud actual
			ControladorBola[] jugadoresTemp = new ControladorBola[indice + 1]; //Redimensiono con un lugar mas
			int i = 0;
			foreach (ControladorBola j in jugadores) //Copio los ya existentes al nuevo vector
			{
				jugadoresTemp[i] = j;
				i++;
			}
			jugadoresTemp[i] = jugador; //Agregamos el que recibimos al nuevo vector.

			jugadores = jugadoresTemp; //Sobrescribo el anterior vector.
		}
    }

    // Add your game mananger members here
    public void Pause(bool paused){
    }

	//Verificara cuando alguno de los objetivos se haya cumplido. En ese caso, terminara el juego.
    public void verificarEstadoJugadores()
    {
        foreach (ControladorBola j in jugadores)
        {
            bool cumplido = false;
			ObjetivoDTO dto = new ObjetivoDTO(j.getCount(), timer.getSecondsFinish());
            foreach (Objetivo o in objetivos)
            {
                cumplido = o.verificarObjetivo(dto);

                if (cumplido)
                {
                    //Al acabarse el tiempo se desactivan todos los pick ups
                    if (o is ObjetivoTiempo)
                    {
                        GameObject[] pickUps = GameObject.FindGameObjectsWithTag("Pick Up");
                        foreach (GameObject pickUp in pickUps)
                        {
                            pickUp.SetActive(false);
                        }
                    }

                    //Al recolectar todos los puntos se detiene el tiempo
                    if (o is ObjetivoPuntos)
                    {
                        timer.setContar(false);
                    }

                    finJuego(j);
                }
            }
        }
    }

    public bool isPorTiempo()
    {
        bool tiempo = false;
        foreach (Objetivo o in objetivos)
        {
			if (o is ObjetivoTiempo)
            {
                tiempo = true;
            }
        }

        return tiempo;
    }

    private void finJuego(ControladorBola jugador)
    {
        //Logica de fin de juego.
        //TEMPORAL: Invoca al menu principal al pasar 5 segundos.
        this.jugadores = null;
        this.objetivos = null;

        SceneManager.LoadScene("MainMenu");
        //Invoke("invocarMenu", 5);
    }

	/*Llamado con el Invoke, rehacer.
	private void invocarMenu(){
		SceneManager.LoadScene ("MainMenu");
	}*/

}
