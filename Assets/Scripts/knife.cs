using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{

    public float lifeTime;
    Rigidbody2D rb;


    void Start()
    {
        Destroy(gameObject, lifeTime);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.left*250);
    }


    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Platform")
        {
            Destroy(gameObject);
        }

        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
        
    }
}
