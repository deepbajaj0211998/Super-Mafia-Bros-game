using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int playerSpeed = 10;
    private bool facingRight = false;
    public int playerJumpSpeed = 1250;
    private float moveX;
    public bool isGrounded;

    // Start is called before the first frame update
    //void Start()
    //{
    //    
    //}

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
	{
        moveX = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown("Jump") && isGrounded == true)
		{
            Jump();
		}
        if(moveX < 0.0f && facingRight == false)
		{
            FlipPlayer();
		}
        else if(moveX > 0.0f && facingRight == true)
		{
            FlipPlayer();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

    void Jump()
	{
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpSpeed);
        isGrounded = false;
    }

    void FlipPlayer()
	{
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
        Debug.Log("Player has collided with" + collision.collider.name);
        if(collision.gameObject.tag == "ground")
		{
            isGrounded = true;
		}
	}

}
