using UnityEngine;
using System.Collections;

public class respawnPoint : MonoBehaviour 
{
	public Vector2 position;
	
	void Start()
	{
		position = this.transform.position;
	}
}
