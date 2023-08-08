using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer rd;
    private Animator anim;

    private bool doubleJump;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        rd = GetComponent <SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (isGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded() || doubleJump)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            doubleJump = !doubleJump;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            gameObject.tag = "inv";
            Color newColor = new Color(Random.value, Random.value, Random.value);
            rd.material.color = newColor;
            

            // Execute qualquer ação que você desejar aqui
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            gameObject.tag = "Player";
            rd.material.color = Color.white;

        }
        UpdateAnimation();
    }


    private bool isGrounded()
    {

        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        
    }
    private void UpdateAnimation()
    {
        if (dirX > 0f)
        {
            anim.SetBool("running", true);
            rd.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            rd.flipX = true;
        } else
        {
            anim.SetBool("running", false);
        }
        
    }

}
