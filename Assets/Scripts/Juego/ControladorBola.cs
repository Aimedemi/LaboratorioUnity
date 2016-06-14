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
		winText.text = "";
		countText.text = "";
		SetCountText ();
		*/

        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

    }
	
	// Update is called once per frame
	// void Update () {}

	// Despues de los calculos de la fisica del objeto
	void FixedUpdate()
	{
        //Movimientos en PC
		if (SystemInfo.deviceType == DeviceType.Desktop) 
		{
			float y =  0.0f;
			Vector3 pos = transform.position;
			if (pos.y >= 0.0f) {
				if (Input.GetKey (KeyCode.Space) && pos.y <= 0.8f) {
					y = 8.0f;
				}

				float moveHorizontal = Input.GetAxis ("Horizontal");
				float moveVertical = Input.GetAxis ("Vertical");

				Vector3 movement = new Vector3 (moveHorizontal, y, moveVertical);

				rb.AddForce (movement * speed);
			} else {
				transform.position = originalPos;
				Stop ();
			}
		}
        // Movimiento en dispositivos mobile
        else
        {
            speed = speed * 10;
            float moveH = Input.acceleration.x;
            float moveV = Input.acceleration.y;

            Vector3 movement = new Vector3(moveH, 0.0f, moveV);

            rb.AddForce(movement * speed * Time.deltaTime);            
        }
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
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}
		if (Input.GetKey (KeyCode.LeftControl)) {
			Stop ();
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
}
