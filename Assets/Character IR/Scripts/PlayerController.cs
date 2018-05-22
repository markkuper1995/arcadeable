using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerSpeed;
    public float startPlayerSpeed;

    public float increaseSpeed;
    public float increaseSpeedMilestone;
    public float startIncreaseSpeedMilestone;
    private float speedMilestoneCount;

    public float jumpForce;

    public bool onGround;
    public LayerMask IsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    private Rigidbody2D playerBody;
    //private Collider2D playerCollider;
    private Animator playerAnimator;
    private SpriteRenderer spriteRenderer;

    public GameManager gameManager;



	// Use this for initialization
	void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();

        //playerCollider = GetComponent<Collider2D>(); 

        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        speedMilestoneCount = increaseSpeedMilestone;
        startPlayerSpeed = playerSpeed;
        startIncreaseSpeedMilestone = increaseSpeedMilestone;
	}
	
	// Update is called once per frame
	void Update()
    {
        if (StartGame.afterThreeTwoOne == false)
            return;
        //onGround = Physics2D.IsTouchingLayers(playerCollider, IsGround);
	
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, IsGround);

        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += increaseSpeedMilestone;
            increaseSpeedMilestone = increaseSpeedMilestone * increaseSpeed;
            playerSpeed = playerSpeed * increaseSpeed;
        }

        playerBody.velocity = new Vector2(playerSpeed, playerBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (onGround)
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
            }
        }

       

        playerAnimator.SetFloat("Speed", playerBody.velocity.x);
        playerAnimator.SetBool("Grounded", onGround);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Killbox")
        {
            gameManager.Death();
        }
    }
}
