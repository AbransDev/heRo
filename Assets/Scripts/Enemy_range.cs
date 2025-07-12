using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_range : MonoBehaviour
{
    public float hp = 100;
    public float initHealth;

    public Image healthbar;


    bool canAttack = true;
    public Transform Pen, Muzzle;
    public float bulletSpeed;


    void Start()
    {
        initHealth = hp;
    }


    void Update()
    {
        healthbar.fillAmount = hp / initHealth;

        if(hp<=0)
        {
            Destroy(gameObject);
            PlayerSC.BulletInv +=5;
        }

        shootBullet ();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
      
        if(other.tag == "Pen")
        {
            hp -= PlayerSC.bulletDamage;
        }   
    }

    private void shootBullet ()
    {
        
        if(canAttack== true)

        {
        canAttack = false;
        
        Transform tempBullet;
        tempBullet = Instantiate(Pen, Muzzle.position, Quaternion.identity);
        StartCoroutine(AttackDelay());
        }

    }

     IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(2f);
        canAttack = true;
    }


}
