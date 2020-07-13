using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementIGuess : MonoBehaviour
{
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveLeft = KeyCode.A;
    public float moveSpeed = 10.0f;
    public float boundY = 2.25f;
    //public KeyCode;
    private Rigidbody2D rb2d;
    private Rigidbody2D rigidbody2d;
    //private Player_Base playerBase;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //playerBase = gameObject.GetComponent<Player_Base>();
        


    }

   
    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
      

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    float jumpVelocity = 100f;
        //    rigidbody2d.velocity = Vector2.up * jumpVelocity;
        //}
    }

    void Movement()
    {
        var vel = rb2d.velocity;
        if (Input.GetKey(moveRight))
        {
            vel.x = moveSpeed;
        }
        else if (Input.GetKey(moveLeft))
        {
            vel.x = -moveSpeed;
        }
        else
        {
            vel.x = 0;
        }
        rb2d.velocity = vel;
    }
    void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
       
    }
}
