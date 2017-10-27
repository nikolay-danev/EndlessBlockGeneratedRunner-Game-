using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    private Vector3 offset;
    public AudioSource audioS;
    private static CameraFollow instance = null;
    public static CameraFollow Instance
    {
        get { return instance; }
    }

    void Start()
    {
        audioS = GetComponent<AudioSource>();
        offset = transform.position - Player.position;
       
    }
    
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Player.position + offset, 5 * Time.deltaTime);
    }

    
}
