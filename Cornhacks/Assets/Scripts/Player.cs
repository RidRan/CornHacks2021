using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    Animator animator;

    float horizontal, vertical;
    public float horizontalSpeed = 3f, verticalSpeed = 3f;

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
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    void FixedUpdate() {

        float frameTime = Time.deltaTime;

        Vector2 position = rigidbody2d.position;
        position.x += horizontalSpeed * horizontal * frameTime;
        position.y += verticalSpeed * vertical * frameTime;

        rigidbody2d.MovePosition(position);
    }
}
