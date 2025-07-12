using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int bestscore;


    TextMeshProUGUI score_txt; 


    void Start()
    {
        score_txt = GameObject.Find("Canvas/score_txt").GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        score_txt.text = score.ToString() + " /" + bestscore.ToString();


    }
}
