using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerSpeed;
    public float jumpForce;

    public bool onGround;
    public LayerMask IsGround;

    private Rigidbody2D playerBody;
    private Collider2D playerCollider;

	// Use this for initialization
	void Start () {
        playerBody = GetComponent<Rigidbody2D>();

        playerCollider = GetComponent<Collider2D>(); 
		
	}
	
	// Update is called once per frame
	void Update()
    {
        onGround = Physics2D.IsTouchingLayers(playerCollider, IsGround);

        playerBody.velocity = new Vector2(playerSpeed, playerBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (onGround)
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
            }
        }
	}
}
