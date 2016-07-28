using UnityEngine;
using UnityEngine.SceneManagement; // neded in order to load scenes
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    public ControladorBola[] jugadores;
    public Objetivo[] objetivos;
    public Timer timer;
	public Canvas gameOver;
	public Button siBtn;
	public Button noBtn;
	public Button pausa;

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

		MensajeInicio mensaje = this.gameObject.GetComponent<MensajeInicio> ();
		mensaje.mostrarObjetivos(this.objetivos);
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
		if (jugadores != null && objetivos != null) {
			bool tiempo = false;
			bool puntos = false;

			foreach (ControladorBola j in jugadores) {
				ObjetivoDTO dto = new ObjetivoDTO (j.getCount (), timer.getSecondsFinish ());
				foreach (Objetivo o in objetivos) {
					if (o is ObjetivoTiempo) {
						tiempo = o.verificarObjetivo (dto);
					}
					if (o is ObjetivoPuntos) {
						puntos = o.verificarObjetivo (dto);
					}

					//Si llego a los puntos, ganó
					if (puntos) {
						finJuego (j, true);
					} else if (tiempo) { //Si se acabó el tiempo, perdio
						finJuego (j, false);
					}
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

	private void finJuego(ControladorBola jugador, bool gano)
    {
		timer.setContar(false);
		//Desactivamos el movimiento de la bola
		jugador.bloquearMovimiento();

		//Desactivamos los coleccionables
		GameObject[] coleccionables = GameObject.FindGameObjectsWithTag("Pick Up");
		foreach (GameObject go in coleccionables) {
			Coleccionable coleccionable = go.GetComponent<Coleccionable> ();
			coleccionable.desactivar();
		}

		gameOver.enabled = true;
		pausa.enabled = false;
		Text texto = gameOver.transform.Find ("Resultado").GetComponent<Text> ();
		string mensaje;
		if (gano) {
			mensaje = "¡GANASTE!\n";
			texto.color = Color.green;
		} else {
			mensaje = "¡PERDISTE!\n";
			texto.color = Color.red;
		}
		//mensaje = mensaje + "¿Volver a jugar?";
		texto.text = mensaje;
    }

	public void cargarEscena (string name){
		this.reiniciarControlador ();
		SceneManager.LoadScene (name);
	}

	public void restartCurrentScene(){
		this.reiniciarControlador ();
		Scene scene = SceneManager.GetActiveScene(); 
		SceneManager.LoadScene(scene.name);
	}

	private void reiniciarControlador(){
		this.jugadores = null;
		this.objetivos = null;
		this.timer = null;
	}

	//hay que sacarlo de aca
	void Start () {
		gameOver = gameOver.GetComponent<Canvas>();
		siBtn = siBtn.GetComponent<Button>();
		noBtn = noBtn.GetComponent<Button>();
		gameOver.enabled = false;
	}


}
