using UnityEngine;
using UnityEngine.UI;
using System;

public class ControladorBola : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text winText;
		
	private int count;
	private Rigidbody rb;
	public Vector3 originalPos;
    PhysicsController fisica = new PhysicsController();

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody>();
		count = 0;

        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

		//Al inicio, registramos la bola en el GameController
		GameController.Instance.addJugador(this);
    }
	
	// Update is called once per frame
	// void Update () {}

	// Despues de los calculos de la fisica del objeto
	void FixedUpdate()
    {
      fisica.moverse(rb, speed);
    }

	void LateUpdate(){
		//Pedimos a GameController que valide el estado del juego
		GameController.Instance.verificarEstadoJugadores();
	}

	void Stop(){
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void Update() {

        //Estoy casi seguro que esto no deberia ir

		//if (Input.GetKey (KeyCode.Escape)) {
		//	Application.Quit ();
		//}
		//if (Input.GetKey (KeyCode.LeftControl)) {
		//	Stop ();
		//}
	}

	void SetCountText ()
	{
		countText.text = "Cubos: " + count.ToString ();
		if (count >= 8)
		{
			winText.text = "¡Ganaste!";
		}
	}

    public int getCount()
    {
        return count;
    }
}
