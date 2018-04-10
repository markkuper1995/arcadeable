using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public float flapSpeed    = 100f;
	public float forwardSpeed = 1f;

	bool didFlap = false;

	Animator animator;

	public bool dead = false;
	float deathCooldown;

	public bool godMode = false;
	// Use this for initialization
	void Start () {
		animator = transform.GetComponentInChildren<Animator>();

		if(animator == null) {
			Debug.LogError("Didn't find animator!");
		}

	}

	// Do Graphic & Input updates here
	void Update() {
		if(dead) {
			deathCooldown -= Time.deltaTime;

			if(deathCooldown <= 0) {
				if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
					Application.LoadLevel( Application.loadedLevel );
				}
			}
		}
		else {
			if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
				didFlap = true;
			}
		}
	}

	
	// Do physics engine updates here
	void FixedUpdate () {

		if(dead)
			return;

		GetComponent<Rigidbody2D>().AddForce( Vector2.left * forwardSpeed );
        TouchMove();

		if(didFlap) {
			TouchMove();
			animator.SetTrigger("DoFlap");


			didFlap = false;
		}

		if(GetComponent<Rigidbody2D>().velocity.y > 0) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else {
			float angle = Mathf.Lerp (0, -90, (-GetComponent<Rigidbody2D>().velocity.y / 3f) );
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(godMode)
			return;

		animator.SetTrigger("Death");
		dead = true;
		deathCooldown = 0.5f;
	}

    void TouchMove()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            float middle = Screen.width / 2;

            if (touch.position.x < middle && touch.phase == TouchPhase.Began)
            {
                Debug.Log("Left of the screen is touched");
                //GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
                GetComponent<Rigidbody2D>().AddForce( Vector2.up * flapSpeed );
            }
            else if(touch.position.x > middle && touch.phase == TouchPhase.Began)
            {
                Debug.Log("Right of the screen is touched");
                //GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f);
                GetComponent<Rigidbody2D>().AddForce( Vector2.down * flapSpeed );
            }
        }
    }
}
