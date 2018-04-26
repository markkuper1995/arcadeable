using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerSpeed;
    public float jumpForce;

    private int characterInt;

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

        characterInt = PlayerPrefs.GetInt("CurrentCharacter");

        if (characterInt == 0)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Trump_1");
            playerAnimator.runtimeAnimatorController = Resources.Load("Animations/Trump") as RuntimeAnimatorController;
        }
        else if (characterInt == 1)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Bolt_1");
            playerAnimator.runtimeAnimatorController = Resources.Load("Animations/Bolt") as RuntimeAnimatorController;
        }
	}
	
	// Update is called once per frame
	void Update()
    {
        //onGround = Physics2D.IsTouchingLayers(playerCollider, IsGround);

        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, IsGround);

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
