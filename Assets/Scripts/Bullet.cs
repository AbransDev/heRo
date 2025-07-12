using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime;


    void Start()
    {
        Destroy(gameObject, lifeTime);
    }


    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D other)
     {

        if(other.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if(other.tag == "Platform")
        {
            Destroy(gameObject);
        }
        
     }

}
