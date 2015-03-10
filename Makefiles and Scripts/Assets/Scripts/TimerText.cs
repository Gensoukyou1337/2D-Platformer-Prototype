using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerText : MonoBehaviour {

	public static float seconds;
	public static int minutes;
	public static bool pausedQuery;
	
	Text text;
	
	void Start()
	{
		text = GetComponent<Text> ();
		seconds = 0;
		minutes = 0;
		pausedQuery = false;
	}
	
	void Update()
	{
		if (!pausedQuery) {
			seconds += Time.deltaTime;
		} else {
			return;
		}

		if (seconds > 60)
		{
			seconds = 0;
			minutes++;
		}

		if (seconds < 10) {
			text.text = minutes + ":0" + string.Format("{0:F1}", seconds);
		} else {
			text.text = minutes + ":" + string.Format("{0:F1}", seconds);
		}
	}
	
	public static void Reset()
	{seconds = 0; minutes = 0;}
}
