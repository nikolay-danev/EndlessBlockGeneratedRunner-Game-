using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public bool canMove;
    private Animator anim;
    private bool isJumping;
    public bool isScoreIncreased;
    public bool isGoldTouched;
    ScoreManager gameOver;
    public AnimationClip GameOverScreenClose;
    public AnimationClip GameOverScreenOpen;
    private Vector3 startPosition;
    private AudioSource audioS;
    public AudioClip Stepping;
    CameraFollow audioL;
    public GameObject soundBtn;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameOver = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        startPosition = transform.position;
        audioS = GetComponent<AudioSource>();
        audioL = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
    }

    void Update()
    {
        if(canMove)
        {
            Moving();
        }
        if(transform.position.y <= -2)
        {
            gameOver.GameOverScree.gameObject.SetActive(true);
            rb.isKinematic = true;
        }
       
    }

    public void Moving()
    {
        if (Input.mousePosition.x < Screen.width/2 && Input.GetMouseButtonDown(0))
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            audioS.clip = Stepping;
            audioS.Play();
            //isJumping = true;
            //anim.SetBool("isJumping", isJumping);
        }
        if (Input.mousePosition.x > Screen.width / 2 && Input.GetMouseButtonDown(0))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            audioS.clip = Stepping;
            audioS.Play();
            // anim.SetBool("isJumping", isJumping);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            canMove = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            canMove = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Chest")
        {
            isScoreIncreased = true;
            gameOver.score++;
        }
        if (other.gameObject.tag == "Gold")
        {
            gameOver.gold += Random.Range(1, 5);
            isGoldTouched = true;
            PlayerPrefs.SetInt("gold", gameOver.gold);
        }
    }

    public void Restart()
    {
        gameOver.score = 0;
        gameOver.GameOverScree.GetComponent<Animation>().clip = GameOverScreenClose;
        gameOver.GameOverScree.GetComponent<Animation>().Play();
        Invoke("CloseGameOver", 0.25f);
    }
    void CloseGameOver()
    {
        gameOver.GameOverScree.gameObject.SetActive(false);
        gameOver.StoreImage.gameObject.SetActive(false);

        SceneManager.LoadScene(1);

    }
   public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }
    public void StoreButton()
    {
        gameOver.GameOverScree.gameObject.SetActive(false);
        gameOver.StoreImage.gameObject.SetActive(true);
    }
}
