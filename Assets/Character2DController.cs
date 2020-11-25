using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour
{
    public float Speed;
    public float jumpForce;
    private Rigidbody2D rg;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            characterScale.x = 5;
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime, 0f, 0f));
        }
        else
        {
            if (Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                characterScale.x = -5;
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime, 0f, 0f));
            }
        }

        transform.localScale = characterScale;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rg.velocity.y) < 0.01)
        {
            rg.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("IsJump", true);
        }

        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal") * Speed));

        if (Input.GetAxisRaw("Vertical") < 0f)
        {
            anim.SetBool("IsDown", true);
        }
        else
        {
            if (Input.GetAxisRaw("Vertical") > 0.5f)
            {
                anim.SetBool("IsDown", false);
            }
        }

    }   
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            anim.SetBool("IsHurt", true);
        }
        else
        {
            anim.SetBool("IsJump", false);
            anim.SetBool("IsHurt", false);
        }
        
    }
    
}
