using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 1;
    public float jumpAccel = 1;

    Vector3 initialPosition;
    // bool isJumping = false;

    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float leftright = Input.GetAxis("Horizontal") * speed;
        leftright *= Time.deltaTime;
        transform.Translate(leftright, 0, 0);

        if (leftright != 0)
        {
            // sprite look direction
            transform.localScale = new Vector3(-Mathf.Sign(leftright), 1, 1);
        }

        // fixme
        if (Mathf.Abs(body.velocity.y) < 0.01f && Input.GetButton("Jump"))
        {
            // isJumping = true;
            // transform.Translate(0, jumpHeight, 0);
            body.AddForce(new Vector2(0, jumpAccel), ForceMode2D.Impulse);
        }

        if (transform.position.y < -12f || Mathf.Abs(transform.position.x) > 12f)
        {
            transform.position = initialPosition;
        }
    }
}
