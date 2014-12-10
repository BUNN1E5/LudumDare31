using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	public float jumpHight = 50;
	public float normalWalkSpeed = 10;
	public float slowWalkSpeed = 4;
	public float slowDownTime = 0.4F;
	public Light redLight;
	public Light blueLight;
	public Light normalLight;
	public bool gravityReverse = false;
	public bool killLightOnStart = false;
	public bool pause = false;
	public float timeSpeed;
	public bool paused;
	public int counter = 0;
	float walkSpeed;
	
	// Use this for initialization
	void Start () 
	{
		Instantiate(normalLight);
		rigidbody.freezeRotation = true;
		Physics.gravity = new Vector3(0, -9.8F, 0);
		if(killLightOnStart == true)
		{
			Destroy(GameObject.Find("MapLight(Clone)"));
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		Control();
		WorldControl();
	}
	
	//Control
	void Control()
	{
		if(Input.GetButton("Right"))
		{
			transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
		}
		else if(Input.GetButton("Left"))
		{
			transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
		}
		
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
			if (GUI.Button(new Rect(10, 30, 90, 30), "Main Menu"))
			{
				Application.LoadLevel("MainMenu");
			}
			
			if (GUI.Button(new Rect(10, 60, 90, 30), "Mute"))
			{
				audio.mute = true;
			}
			else if (GUI.Button(new Rect(110, 60, 90, 30), "Un-Mute"))
			{
				audio.mute = false;
			}
			
			if (GUI.Button(new Rect(10, 90, 90, 30), "Restart"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
				
			if (GUI.Button(new Rect(10, 120, 90, 30), "Quit"))
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
	
	void WorldControl()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			Destroy(GameObject.Find("MapLight(Clone)"));
			Instantiate(redLight);
			Time.timeScale = 1F; 
			Physics.gravity = new Vector3(0, 9.8F, 0);
			gravityReverse = true;
			timeSpeed = Time.timeScale;
			walkSpeed = normalWalkSpeed;
		}
		else if(Input.GetButtonDown("Fire2"))
		{
			Destroy(GameObject.Find("MapLight(Clone)"));
			Instantiate(blueLight);
			Time.timeScale = slowDownTime;
			Physics.gravity = new Vector3(0, -9.8F, 0);
			gravityReverse = false;
			timeSpeed = Time.timeScale;
			walkSpeed = slowWalkSpeed;
		}
		else if(Input.GetButtonDown("Fire3"))
		{
			Destroy(GameObject.Find("MapLight(Clone)"));
			Instantiate(normalLight);
			Time.timeScale = 1F;
			Physics.gravity = new Vector3(0, -9.8F, 0);
			gravityReverse = false;
			timeSpeed = Time.timeScale;
			walkSpeed = normalWalkSpeed;
		}
	}
}
