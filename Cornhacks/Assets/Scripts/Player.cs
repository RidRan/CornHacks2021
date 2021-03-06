﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    Animator animator;

    public bool menu = true, rippleOn = false;

    public ParticleSystem ripple;

    float horizontal, vertical;
    public float horizontalSpeed = 3f, verticalSpeed = 3f, verticalMultiplier = 3f;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    bool left;
    bool right;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        rigidbody2d = GetComponent<Rigidbody2D>();
        ripple.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (!menu) {
            if (!rippleOn) {
                ripple.Play();
                rippleOn = true;
            }
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            if (horizontal < 0) {
                left = true;
                right = false;
            } else if (horizontal > 0) {
                left = false;
                right = true;
            } else {
                left = false;
                right = false;
            }

            animator.SetBool("Turning Left", left);
            animator.SetBool("Turning Right", right);

            transform.position = rigidbody2d.position;
        } else if (rippleOn) {
            ripple.Stop();
            rippleOn = false;
        }

        
        
    }

    void FixedUpdate() {
        if (!menu) {
            float frameTime = Time.deltaTime;

            Vector2 position = rigidbody2d.position;
            position.x += horizontalSpeed * horizontal * frameTime;
            position.y += (verticalSpeed + vertical * verticalMultiplier) * frameTime;

            rigidbody2d.MovePosition(position);
        }
        
    }
}
