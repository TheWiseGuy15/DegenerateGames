using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : MonoBehaviour
{

	//Integers
	public int curHealth;
	public int maxHealth;

	//Floats
	public float distance;
	public float wakeRange;
	public float speed;

	//Booleans
	public bool awake = false;
	private bool movingRight = true;

	//References
	public Transform target;
	//public Transform groundDetection;

	void Start()
	{
		curHealth = maxHealth;
	}

	void Update()
	{
		RangeCheck();
		Aggro();
		if (curHealth <= 0)
		{
			Destroy(gameObject);
		}
	}

	void RangeCheck()
	{
		//Enemy Vision
		distance = Vector3.Distance(transform.position, target.transform.position);

		if (distance < wakeRange)
		{
			awake = true;
		}
		if (distance > wakeRange)
		{
			awake = false;
		}
	}

	void Aggro()
	{
		if (awake)
		{
			//movement
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, .03f);
			Vector3 direction = target.transform.position - transform.position;
			direction = direction.normalized;
			GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * speed, GetComponent<Rigidbody2D>().velocity.y);

			//transform.Translate(Vector2.right * speed * Time.deltaTime);
			//
			//RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
			//if (groundInfo.collider == false)
			//{
			//if (movingRight == true)
			//{
			//transform.eulerAngles = new Vector3(0, -180, 0);
			//movingRight = false;
			//}
			//else
			//{
			//transform.eulerAngles = new Vector3(0, 0, 0);
			//movingRight = true;
			//}
			// }
		}
	}

	public void Damaged(int dmg)
	{
		curHealth -= dmg;
	}

}