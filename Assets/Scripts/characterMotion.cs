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
		}
	}
	
	void OnCollisionExit2D(Collision2D other)
	{	
		this.transform.parent = lastObject.transform.parent;
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.transform.tag == "Lava")
		{
			counter-= Time.deltaTime;
			if(counter <= 0)
			{
				transform.position = respawn.position;
				counter = 0.1f;
				life = 2;
			}
		}
		else
		{
			counter = 0.1f;
		}
	}
}

