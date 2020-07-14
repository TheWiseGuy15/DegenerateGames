using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class player : MonoBehaviour {

	bool left;
	bool right;
	bool up;
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
        }

		if (left)
        {
			// apply force to left
			UpdateVelocity(-velocity, -maxVelocity, -acceleration);
			UpdatePosition();
        }

            // jump
        if (IsGrounded() && Input.GetKeyDown(KeyCode.UpArrow))
        {
				float jumpVelocity = 50f;
				rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
			
        
	}
	//removes infinite jump
	private bool IsGrounded()
    {
		RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
		Debug.Log(raycastHit2d.collider);
		return raycastHit2d.collider != null;
    }

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