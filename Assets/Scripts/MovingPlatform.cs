using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public Transform point1;
	public Transform point2;
	
	public Transform platformPosition;
	
	public float Speed = 0.5f;
	
	public bool goingLeft = true;
	
	public void Update() 
	{
	
		if(transform.position == point1.position)
		{
			goingLeft = false;
		}
		else if(transform.position == point2.position)
		{
			goingLeft = true;
		}
		if(goingLeft)
		{
			transform.position = Vector3.MoveTowards(platformPosition.position, point1.position, Speed * Time.deltaTime);
		}
		else if(!goingLeft)
		{
			transform.position = Vector3.MoveTowards(platformPosition.position, point2.position, Speed * Time.deltaTime);
		}
	}
}
