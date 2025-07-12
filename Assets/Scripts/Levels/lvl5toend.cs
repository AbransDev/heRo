using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl5toend : MonoBehaviour
{
    public GameManager gm;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D item)
    {
        if(item.transform.tag == "Player")
        {
            if(gm.score >= gm.bestscore)
            {
                SceneManager.LoadScene("LastCinematic");
            }
        }
   
    }
}
