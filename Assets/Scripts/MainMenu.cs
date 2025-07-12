using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public GameObject gameover;
    public void play_btn()
    {
        SceneManager.LoadScene(1);
    }

    public void quit_btn()
    {
        Debug.Log("kapandı");
        Application.Quit();
    }

    public void restart_btn()
    {

        SceneManager.LoadScene( SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        gameover.SetActive(false);
        
    }
}
