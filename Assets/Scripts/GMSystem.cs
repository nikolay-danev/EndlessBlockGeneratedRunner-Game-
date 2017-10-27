using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GMSystem : MonoBehaviour
{
    public bool isOff;
    public Animator SoundButton;
    public AudioSource audioS;


    private void Start()
    {
        SoundButton = GameObject.Find("SoundOnOff").GetComponent<Animator>();
        audioS = GameObject.Find("MusicManager").GetComponent<AudioSource>();

    }
    public void TurnOnOffSound()
    {
        isOff = !isOff;
        if (isOff)
        {
            SoundButton.SetBool("isOff", isOff);
            audioS.enabled = false;
        }
        if (!isOff)
        {
            SoundButton.SetBool("isOff", isOff);
            audioS.enabled = true;
        }
    }
    public void StarGame()
    {
        SceneManager.LoadScene("Game");

    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
