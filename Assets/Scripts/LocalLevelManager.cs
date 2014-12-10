using UnityEngine;
using System.Collections;

public class LocalLevelManager : MonoBehaviour {
	
	public Rigidbody2D[] rigidbodyObjects;
	
	public bool levelStarted;
	public bool levelEnded;
	
	public Component[] Platforms;
	public EnemyAI[] Enemies;
	
	public Collider2D[] colliders;
	
	// Use this for initialization
	void Start () 
	{
		Platforms = GetComponentsInChildren<MovingPlatform>();
		rigidbodyObjects = gameObject.GetComponentsInChildren<Rigidbody2D>();
		colliders = gameObject.GetComponentsInChildren<Collider2D>();
		Enemies = gameObject.GetComponentsInChildren<EnemyAI>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(levelEnded)
		{
			endLevel();
		}
		
		if(levelStarted)
		{
			startLevel();
		}
	}
	
	void endLevel()
	{

		Destroy(this.gameObject, 3f);
		transform.Translate(Vector2.right * 5 *  Time.deltaTime);
	}
	
	void startLevel()
	{
		foreach(MovingPlatform platform in Platforms)
		{
			platform.enabled = true;
		}
		
		foreach(EnemyAI enemy in Enemies)
		{
			enemy.enabled = true;
		}
		
		foreach(Collider2D collider in colliders)
		{
			collider.enabled = true;
		}
		
		foreach(Rigidbody2D rigidbody in rigidbodyObjects)
		{
			rigidbody.WakeUp();
		}
		
		GetComponentInChildren<characterMotion>().enabled = true;
	}
}
