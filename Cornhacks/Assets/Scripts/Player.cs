using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    float horizontal, vertical;
    public float horizontalSpeed = 3f, verticalSpeed = 3f;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

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
