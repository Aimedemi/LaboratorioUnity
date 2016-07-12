using UnityEngine;
using UnityEngine.UI;

public class ControladorBola : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text winText;

	private int count;
	private Rigidbody rb;
	private Vector3 originalPos;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		count = 0;

		/*
		if (SystemInfo.deviceType == DeviceType.Handheld)
		{
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
		}
*/
		//Al inicio, registramos la bola en el GameController
		GameController.Instance.addJugador(this);
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
		if (Input.GetKey(KeyCode.LeftControl) || Input.touchCount==1)
		{
			Stop();
		}
	}

	// Despues de los calculos de la fisica del objeto
	void FixedUpdate()
	{
		//Movimientos en PC
		if (SystemInfo.deviceType == DeviceType.Desktop) 
		{
			float y = 0.0f;

			float moveHorizontal = Input.GetAxisRaw("Horizontal");
			float moveVertical = Input.GetAxisRaw("Vertical");

			Vector3 movement = new Vector3(moveHorizontal, y, moveVertical);

			rb.AddForce(transform.TransformDirection(movement) * speed);

		}
		// Movimiento en dispositivos mobile
		else
		{
			speed = speed * 10;
			float moveH = Input.acceleration.x * 3;
			float moveV = Input.acceleration.y * 3;

			Vector3 movement = new Vector3(moveH, 0.0f, moveV);

			//rb.AddForce(transform.TransformDirection(movement) * speed * Time.deltaTime);
		}

	}

	void LateUpdate(){
		//Pedimos a GameController que valide el estado del juego
		GameController.Instance.verificarEstadoJugadores();
	}

	void Stop(){
		rb.velocity = rb.velocity - rb.velocity/10; //Usar Lerp
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
