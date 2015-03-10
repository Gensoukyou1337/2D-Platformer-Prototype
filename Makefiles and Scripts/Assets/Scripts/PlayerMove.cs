using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public float moveSpeed;
	private float moveVelo;
	public float jumpHeight;

	public LevelManager levelManager;

	private Animator anim;

	//variables below for ground collision check
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	private bool doubleJump;

	// Use this for initialization
	void Start ()
	{
		levelManager = FindObjectOfType<LevelManager> ();
		anim = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		anim.SetBool ("Grounded", grounded);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (grounded)
		{
			doubleJump = false;
		}
		if ((Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) && grounded)
		{
			Jump ();
		}
		if ((Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) && !grounded && !doubleJump)
		{
			Jump ();
			doubleJump = true;
		}
		moveVelo = 0f;
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow))
		{
			//rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
			moveVelo = moveSpeed;
		}
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow))
		{
			moveVelo = -moveSpeed;
		}
		rigidbody2D.velocity = new Vector2(moveVelo, rigidbody2D.velocity.y);
		if (transform.position.y < -10)
		{
			levelManager.RespawnPlayer ();
		}
		anim.SetFloat ("Speed", Mathf.Abs(rigidbody2D.velocity.x));
		if (rigidbody2D.velocity.x > 0)
		{
			transform.localScale = new Vector3(1f,1f,1f);
		}
		else if(rigidbody2D.velocity.x < 0)
		{
			transform.localScale = new Vector3(-1f,1f,1f);
		}
		//transform.localScale = new Vector3(xScale, yScale, zScale);
		//negative values invert the sprite along each axis. If you're making a 2D game, DO NOT USE -1f for the Z AXIS.
	}

	public void Jump()
	{
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpHeight);
	}
}
