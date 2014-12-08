using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	public float Speed = 0.5f;
	public float timer = 2f;
	public bool goingLeft = true;
	private float counter;
	private Collision2D lastObject = new Collision2D();
	
	public void Start()
	{
		counter = timer;
	}
	
	public void Update() 
	{
		if(counter < 0)
		{
			goingLeft = false;
		}
		else if(counter > timer)
		{
			goingLeft = true;
		}
		if(goingLeft)
		{
			transform.Translate(Vector2.right * Speed * Time.deltaTime * -1);
			counter -= Time.deltaTime;
		}
		else if(!goingLeft)
		{
			transform.Translate(Vector2.right * Speed * Time.deltaTime);
			counter += Time.deltaTime;
		}
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{	
		if(other.transform.tag == "Platform")
		{
			this.transform.parent = other.transform;
			lastObject = other;
		}
	}
	
	void OnCollisionExit2D(Collision2D other)
	{	
		this.transform.parent = lastObject.transform.parent;
	}
}
