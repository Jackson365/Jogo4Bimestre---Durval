using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Colect : MonoBehaviour
{
    public AudioSource caxixi;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            caxixi.Play();
            Destroy(gameObject, 0.4f);
        }
    }
}
