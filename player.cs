using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class player : MonoBehaviour {

	bool left;
	bool right;
	public bool IsGrounded;
	public float mass = 1.0f;
	public Vector3 velocity;
	public Vector3 maxVelocity;
	public Vector3 acceleration;
	public KeyCode moveRight = KeyCode.RightArrow;
	public KeyCode moveLeft = KeyCode.LeftArrow;

	[SerializeField] private LayerMask platformsLayerMask;
	private Rigidbody2D rigidbody2d;
	private BoxCollider2D boxCollider2d;

	// Use this for initialization
	void Start () 
	{
		rigidbody2d = transform.GetComponent<Rigidbody2D>();
		boxCollider2d = transform.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetKeys();
        if (right)
        {
			// apply force to right
			UpdateVelocity(velocity, maxVelocity, acceleration);
			UpdatePosition();
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		
        }

		else if (left)
        {
			// apply force to left
			UpdateVelocity(-velocity, -maxVelocity, -acceleration);
			UpdatePosition();
			transform.localRotation = Quaternion.Euler(0, 180, 0);

		}

			// jump
        /*if (IsGrounded())
        {
			DrawGround();
        }*/
 
        if (IsGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 2000));
			/*float jumpVelocity = 50f;
			rigidbody2d.velocity = Vector2.up * jumpVelocity;*/
        }
			
	}
	//removes infinite jump ground
	/*private bool IsGrounded()
    {
		RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size/2, 0f, Vector2.down, 2.0f, platformsLayerMask);
		Debug.Log(raycastHit2d.collider);
		return raycastHit2d.collider != null;
    }

	//show ground collison
	void DrawGround()
    {
		Debug.DrawLine(new Vector3(boxCollider2d.bounds.center.x - (boxCollider2d.bounds.size.x / 2), boxCollider2d.bounds.center.y - (boxCollider2d.bounds.size.y / 2)),
					   new Vector3(boxCollider2d.bounds.center.x + (boxCollider2d.bounds.size.x / 2), boxCollider2d.bounds.center.y - (boxCollider2d.bounds.size.y / 2)));
	}*/
	void GetKeys()
    {
		if (Input.GetKey(moveLeft))
		{
			left = true;
		}
        else
        {
			left = false;
        }
		if (Input.GetKey(moveRight))
		{
			right = true;
		}
        else
        {
			right = false;

        }
	}

	void UpdateVelocity(Vector3 vel, Vector3 maxVel, Vector3 acc)
    {
		if (vel.x < Math.Abs(maxVel.x))
		{
			velocity += acc;
		}
    }

	void UpdatePosition()
    {
		transform.position += velocity;
	}
}