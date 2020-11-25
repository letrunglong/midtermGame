using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 40f, maxspeed = 3, jumpPow = 5f;
    public Rigidbody2D rigidbody2D;
    public bool faceRight = true;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rigidbody2D.AddForce(Vector2.right * speed * h);

        animator.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));


        if (rigidbody2D.velocity.x > maxspeed)
        {
            rigidbody2D.velocity = new Vector2(maxspeed, rigidbody2D.velocity.y);
        }
        if (rigidbody2D.velocity.x < -maxspeed)
        {
            rigidbody2D.velocity = new Vector2(-maxspeed, rigidbody2D.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.AddForce(new Vector2(0f, jumpPow));
        }
        if (h > 0 && !faceRight)
        {
            Flip();
        }
        if (h < 0 && faceRight)
        {
            Flip();
        }

    }
    public void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale;
        scale = transform.localScale;
        scale.x *= -1;
        this.transform.localScale = scale;
    }
}
