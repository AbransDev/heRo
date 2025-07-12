using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSC : MonoBehaviour
{


    //ses efektleri

    public GameObject dieEffect;
    AudioSource sDieEffect;

    public GameObject takeDamageEffect;
    AudioSource sTakeDamageEffect;



    //kitap düşürme

    public Transform Book, Muzzle2;

    //HP bar

    public float hp = 100;
    public float initHealth;
    public Image healthbar;

   //bullet envanter

    public static int BulletInv =10;
    public float waitTime = 10;
    float timer = 0;

    //attack

    bool canAttack = true;
    public Transform Pen, Muzzle;
    public float bulletSpeed;
    public static float bulletDamage= 20; 


    //checkpoint
    public Vector2 lastCheckpoint;


    //skor sistemi

    public GameManager gm;


   // Hareket kodlari

    public int speed;
    public int jumpSpeed;

    Animator anim;
    Rigidbody2D rb;

    bool canJump = true;
    bool faceRight = true;


    void Start()
    {
        
        anim= GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sDieEffect= dieEffect.GetComponent<AudioSource>();
        sTakeDamageEffect = takeDamageEffect.GetComponent<AudioSource>();
        initHealth = hp;

    }

    // Update is called once per frame
    void Update()
    {

        healthbar.fillAmount = hp / initHealth;

        if(Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

        if(hp <= 0)
        {
            sDieEffect.Play();
            transform.position = lastCheckpoint;
            hp = 100;
        }

        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            BulletInv +=1;
            timer =0;
        }
            
        if(Input.GetKeyDown(KeyCode.Space))
        {   
            if(BulletInv >= 1)
            {
                shootBullet();
                BulletInv --;
            }
                
        }


    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); 
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);



        if (moveInput > 0 ||moveInput < 0)
        {
            anim.SetBool("isRunning", true);
        }else
        {
            anim.SetBool("isRunning", false);
        }

        if(faceRight == true && moveInput < 0)
        {
            Flip();
        }else if (faceRight == false && moveInput > 0)
        {
            Flip();
        }

        

    }


    private void OnCollisionEnter2D(Collision2D item)
    {
        if(item.transform.tag == "Platform")
        {
            canJump = true;
        }

        if(item.gameObject.tag == "Enemy")
        {

            rb.AddForce(Vector2.up*50);
            rb.AddForce(Vector2.left*5000);
            hp-=10;

            if(gm.score>0)
            {
               dropBook();
               gm.score--;
            }
            sTakeDamageEffect.Play();
            
             
        }
    }

    private void OnTriggerEnter2D(Collider2D item)
    {
        if(item.transform.tag == "Books")
        {
            gm.score++;
            Destroy(item.gameObject);
        }

        if(item.gameObject.tag == "Checkpoint")
        {
          lastCheckpoint = transform.position;
          Destroy(item.gameObject);
        } 
        
        if(item.gameObject.tag == "deadWall")
        {
            hp = 0;
        }

        if(item.gameObject.tag == "Knife")
        {

            rb.AddForce(Vector2.up*50);
            rb.AddForce(Vector2.left*5000);
            hp-=20;
            sTakeDamageEffect.Play();
            
             
        }
    }


    private void Jump()
    {
        if(canJump == true)
        {
            rb.AddForce(Vector2.up * jumpSpeed);
            canJump = false;
        }
    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void shootBullet ()
    {
        
        if(canAttack== true)

        {
        canAttack = false;
        
        Transform tempBullet;
        tempBullet = Instantiate(Pen, Muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(Muzzle.forward * bulletSpeed * 1);
        anim.SetTrigger("attack");
        StartCoroutine(AttackDelay());
        }


    }

     IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.1f);
        canAttack = true;
    }


    void dropBook()

    {
        Transform tempBook;
        tempBook = Instantiate(Book, Muzzle2.position, Quaternion.identity);
    }



}
