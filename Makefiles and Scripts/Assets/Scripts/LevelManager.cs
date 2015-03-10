using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public GameObject currentCheckpoint;
	private PlayerMove player;
	public GameObject deathParticles;
	public GameObject respawnParticles;
	public float respawnDelay;
	public int reductionPoints;
	private float defaultGravScale;

	// Use this for initialization
	void Start ()
	{
		player = FindObjectOfType<PlayerMove> ();
		defaultGravScale = player.rigidbody2D.gravityScale;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void VictoryNotif()
	{
		print ("Exit Door Reached");
		StartCoroutine ("VictoryNotifCo");
	}

	public IEnumerator VictoryNotifCo()
	{
		YouWinNotif.exitReachedQuery = true;
		yield return new WaitForSeconds (5);
		Application.LoadLevel (Application.loadedLevel+1);
		YouWinNotif.exitReachedQuery = false;
	}
	//The delay thing needs a coroutine
	//Coroutines ALLOW YOU TO PAUSE WITH THE yield THING.
	public void RespawnPlayer()
	{
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo()
	{
		Instantiate (deathParticles, player.transform.position, player.transform.rotation);
		player.rigidbody2D.velocity = Vector2.zero;
		player.rigidbody2D.gravityScale = 0f;
		ScoreManager.AddPoints (-reductionPoints);
		player.enabled = false;
		player.renderer.enabled = false;
		player.collider2D.enabled = false;
		yield return new WaitForSeconds (respawnDelay); //the delay in seconds function
		player.enabled = true;
		player.renderer.enabled = true;
		player.collider2D.enabled = true;
		player.rigidbody2D.gravityScale = defaultGravScale;
		player.transform.position = currentCheckpoint.transform.position;
		DeathCountDisplay.AddDeathCounter();
		Instantiate (respawnParticles, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
	}
}
