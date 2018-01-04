using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScontroller : MonoBehaviour {

//=== Moving Variables============
	public float topSpeed = 2.0f;
	public float baseSpeed = 1.5f;
	public float jumpForce = 10.0f;
	float speed = 1.5f;
//=== Jumping Variables	==========
	public bool jumping = false;	
	public Transform groundCheck;
	public bool grounded = false;			
	public GameObject jumpTarget;
//=== Unity Variables ============
	private Rigidbody rb;
	public GameObject camera;
//================================

	void Start ()
	{
		// gets rigidbody component and puts it into a variable
		rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
	{
		Jump();
		Attack();
		TurnWithMouse();
	}
	
    void FixedUpdate ()
    {
		Movement();
		Jump();
	}

	// Turns the player object so the object is facing and turns the same way as the camera
	void TurnWithMouse ()
	{
		float movement = Mathf.Abs(Input.GetAxis ("Horizontal")) + Mathf.Abs(Input.GetAxis ("Vertical"));
		if(movement > 0)
		{
			Quaternion deltaRotation = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0);
			rb.MoveRotation(deltaRotation);	
		}
	}
	
	void Jump()
	{
		// this checks if there is a line between two invisible gameobjects, and if the line intersects any layers named "Ground" and returns a boolean
		grounded = Physics.Linecast(jumpTarget.transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		// sets it so the player can only jump when on the ground, prevents infinite jumping
		if (Input.GetButtonDown("Jump") && grounded)
		{
			print("Grounded");
			jumping = true;
		}

		// adds an amount of force to the y-axis of the player
		if (jumping)
		{
			rb.AddRelativeForce(0, jumpForce, 0, ForceMode.Impulse);
			jumping = false;
		}
	}
	
	void Movement()
	{
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        float moveVertical = Input.GetAxisRaw ("Vertical");

		// prevents multiplicative acceleration
		if (moveHorizontal > 0 && moveVertical > 0 || moveHorizontal > 0 && moveVertical < 0) {
			moveHorizontal *= 0.5f;
		}
		if (moveHorizontal < 0 && moveVertical > 0 || moveHorizontal < 0 && moveVertical < 0) {
			moveVertical *= 0.5f;
		}

		// adds force relative to the character's facing direction
        rb.AddRelativeForce (moveHorizontal * speed, 0, moveVertical * speed,  ForceMode.VelocityChange);	

		// if shift is held down, allows player to run by adding additional acceleration
		if (Input.GetButton("Sprint") && moveVertical > 0)
			speed = topSpeed;
		else
			speed = baseSpeed;
	}
	
	// in progress
	void Attack ()
	{

	}

}