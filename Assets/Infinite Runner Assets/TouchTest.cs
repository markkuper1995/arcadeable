using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update () {
        TouchMove();
	}

	void FixedUpdate () {
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
                GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
            }
            else if(touch.position.x > middle && touch.phase == TouchPhase.Began)
            {
                Debug.Log("Right of the screen is touched");
                GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f);
            }
        }
	}


}
