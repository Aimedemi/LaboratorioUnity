using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text winText;
	public Text timeText;
	public Text countDown;
	public float secondsStart;
	public float secondsFinish;
	public int waitTimeStart;
	public int waitTimeFinish;


	private int count;
	private Rigidbody rb;
	private Vector3 originalPos;

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeRight;
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
		timeText.text = "";
		originalPos = transform.position;
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            speed = 500.0f;
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
		GetCountDown ();
		secondsStart = waitTimeStart-(int)(Time.time % 60f);
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
			winText.text = "Ganaste!";

		}
	}

	void GetCountDown ()
	{
		if (secondsStart < 0) {
			timeText.text = "";
			secondsFinish = waitTimeFinish+secondsStart;
			if (secondsFinish < 0) {
				countDown.text = "Time over";
			} else {
				
				countDown.text = "Tiempo: "+secondsFinish.ToString("00");
			}
		}
		else if (secondsStart < 1) {
			timeText.text = "Go!";
		} 
		else {
			timeText.text = secondsStart.ToString("00");
		}

	}

}
