using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rig;
    private Animator anim;

    private float moviment;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        moviment = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(moviment * speed, rig.velocity.y);
    }
}
