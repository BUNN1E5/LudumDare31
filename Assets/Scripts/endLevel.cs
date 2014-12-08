using UnityEngine;
using System.Collections;

public class endLevel : MonoBehaviour {

	public bool LevelEnded = false;
	public TextMesh playerText;
	[Range(0, 5)]
	public float counter = 6f;
	int viewCounter;
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		viewCounter = (int)counter;
		playerText.text = viewCounter.ToString();
		if(viewCounter <= 0)
		{
			LevelEnded = true;
		}
		counter -= Time.deltaTime;
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		counter = 6f;
		playerText.text = " ";
	}
}
