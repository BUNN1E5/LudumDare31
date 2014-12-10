using UnityEngine;
using System.Collections;

public class characterMotion : MonoBehaviour
{
		public bool grounded = true;
		public float jumpPower = 190;
		private bool hasJumped = false;
		public float Speed = 1;
		private Collision2D lastObject = new Collision2D();
		public int life = 2;
		public respawnPoint respawn;
		public float counter = 0.1f;
		public bool paused = false;
		TextMesh lives;
	
	void Start()
	{ 
		lives = gameObject.GetComponentInChildren<TextMesh>();
	}
		
		// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * Input.GetAxis ("Horizontal") * Speed * Time.deltaTime * -1);
		if(!grounded && rigidbody2D.velocity.y == 0) {
			grounded = true;
		}
		if (Input.GetAxis("Vertical") >= 0.1 && grounded == true || Input.GetKeyDown(KeyCode.Space) && grounded == true) {
			hasJumped = true;
		}
		
		if(life <= 0)
		{
			transform.position = respawn.position;
			counter = 0.1f;
			life = 2;
		}
		
		
		lives.text = life.ToString();
		
		if(Input.GetKeyDown("escape"))
		{
			paused = !paused;
		}
	}
	
	void OnGUI() 
	{
		if (paused == true)
		{
			counter = 0;
			Time.timeScale = 0F;
			GUI.Label(new Rect(13, 10, 180, 90), "Game paused");
			if (GUI.Button(new Rect(10, 30, 90, 30), "Restart"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
			
			if (GUI.Button(new Rect(10, 60, 90, 30), "Mute"))
			{
				audio.mute = true;
			}
			else if (GUI.Button(new Rect(110, 60, 90, 30), "Un-Mute"))
			{
				audio.mute = false;
			}
			
			if (GUI.Button(new Rect(10, 90, 90, 30), "Quit"))
			{
				Application.Quit();
			}
		}
		else
		{
			if(paused == false && counter == 0)
			{
				Time.timeScale = 1;
				counter = 1;
			}
		}
	}
	
	void OnApplicationPause(bool pauseStatus) 
	{
		paused = pauseStatus;
	}
	
	void FixedUpdate (){
		if(hasJumped){
			rigidbody2D.AddForce(transform.up*jumpPower);
			grounded = false;
			hasJumped = false;
		}
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{	
		if(other.transform.tag == "Platform")
		{
			this.transform.parent = other.transform;
			lastObject = other;
		}
		
		if(other.transform.tag == "Enemy")
		{
			life--;
			rigidbody2D.AddForce(Vector2.right * 50);
			rigidbody2D.AddForce(Vector2.up * 50);
		}
	}
	
	void OnCollisionExit2D(Collision2D other)
	{	
		this.transform.parent = lastObject.transform.parent.parent;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag == "Lava")
		{

			transform.position = respawn.position;
			counter = 0.1f;
			life = 2;
		}
	}
}

