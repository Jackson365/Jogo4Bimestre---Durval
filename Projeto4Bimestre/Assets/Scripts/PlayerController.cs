using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    
    private bool isJumping;
    private bool dobleJump;
    private bool isAttack;
    
    private Rigidbody2D rig;
    private Animator anim;

    private float movement;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        AttackMagic();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        if (movement > 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("Transitions", 1);   
            }
            
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (movement < 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("Transitions", 1);    
            }
            
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (movement == 0 && !isJumping && !isAttack)
        {
            anim.SetInteger("Transitions", 0);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                anim.SetInteger("Transitions", 2);
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                dobleJump = true;
                isJumping = true;
            }
            else
            {
                if (dobleJump)
                {
                    anim.SetInteger("Transitions", 2);
                    rig.AddForce(new Vector2(0, jumpForce * 1), ForceMode2D.Impulse);
                    dobleJump = false;
                }
            }
        }
    }

    void AttackMagic()
    {
        StartCoroutine("Attack");
    }

    IEnumerator Attack()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isAttack = true;
            anim.SetInteger("Transitions", 3);
            
            yield return new WaitForSeconds(0.5f);
            anim.SetInteger("Transitions", 0);
            isAttack = false;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
        }
    }
}