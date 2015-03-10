using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathCountDisplay : MonoBehaviour {

	public static int deathCount;
	
	Text text;
	
	void Start()
	{
		text = GetComponent<Text> ();
		deathCount = 0;
	}
	
	void Update()
	{
		if (deathCount < 0)
		{deathCount = 0;}
		text.text = "" + deathCount;
	}
	
	public static void AddDeathCounter()
	{
		deathCount++;
	}
	
	public static void DeathReset()
	{deathCount = 0;}
}
