using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class YouWinNotif : MonoBehaviour {
	
	public static bool exitReachedQuery;
	Text text;
	
	void Start()
	{
		text = GetComponent<Text> ();
	}

	void Update()
	{
		if (!exitReachedQuery) {
			return;
		} else {
			text.text = "YOU WIN!";
		}
	}
}
