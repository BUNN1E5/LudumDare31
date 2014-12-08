using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public LocalLevelManager[] Level;
	public endLevel[] endLevel;
	public int thisLevel = 0;
	public bool nextLevel;

	// Use this for initialization
	void Start () 
	{
		Level[thisLevel].levelStarted = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{	
		if(endLevel[thisLevel].LevelEnded)
		{
			nextLevel = true;
		}
		
		if(nextLevel == true)
		{
			Level[thisLevel].levelEnded = true;
			thisLevel++;
			nextLevel = false;
			Level[thisLevel].levelStarted = true;
		}
	}
}
