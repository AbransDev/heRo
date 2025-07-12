using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float hp = 100;
    public float initHealth;

    public Image healthbar;


    //enemy move

    public int speed;
    bool faceRight= false;
    public float turnDelay;

    //aniamsyon
    Animator anim;




    void Start()
    {
        initHealth = hp;
        StartCoroutine(SwitchDirections());
        anim= GetComponent<Animator>();
    }


    void Update()
    {

        healthbar.fillAmount = hp / initHealth;

        if(hp<=0)
        {
            Destroy(gameObject);
            PlayerSC.BulletInv +=5;
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime);

    }

    IEnumerator SwitchDirections()
    {
        yield return new WaitForSeconds(turnDelay);
        Switch();
    }

    private void Switch()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;

        speed *= -1;
        StartCoroutine(SwitchDirections());
    }


    void OnTriggerEnter2D(Collider2D other)
    {
      
        if(other.tag == "Pen")
        {
            hp -= PlayerSC.bulletDamage;
        }   
    }

    private void OnCollisionEnter2D(Collision2D item)
    {
        if(item.transform.tag == "Player")
        {
            anim.SetTrigger("Attack");
        }
    }
}
