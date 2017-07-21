using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour {

    Animator anim;
    public float speed = 6f;
    Vector2 movement;
    Rigidbody2D playerRigidbody;

	// Use this for initialization
	void Awake () {
        playerRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        movement.Set(Input.GetAxisRaw("Horizontal"),0f);
        Move();
	}

    void Move()
    {
        Vector3 newScale = transform.localScale;

        if(movement.x != 0f)
        {
            float sign = Mathf.Sign(Input.GetAxis("Horizontal"));
            newScale.x = sign * Mathf.Abs(transform.localScale.x);
        }

        transform.localScale = newScale;

        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + new Vector3(movement.x, movement.y, 0f));
    }
}
