using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameObject gameover;
    Vector3 temp;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        temp = transform.localScale;
        temp.x += Time.deltaTime * 5;
        transform.localScale = temp;
    }

    private void OnTriggerEnter2D(Collider2D item)
    {
        if(item.transform.tag == "Player")
        {   
            gameover.SetActive(true);
            Time.timeScale=0;
            PlayerSC.BulletInv = 10;
        }

    }
}
