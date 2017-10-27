using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    public Image Info;
    private bool isInfoOpen;
    ScoreManager score;
    private void Start()
    {
        
        score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    public void StarGame()
    {
        SceneManager.LoadScene("Game");
       
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    void Update()
    {
        if(score.bestScore < 1)
        {
            Info.gameObject.SetActive(true);
        }
        else
        {
            Info.gameObject.SetActive(false);
        }
    }
    public void CloseInfo()
    {
        isInfoOpen = false;
        Info.gameObject.SetActive(false);
    }
}
