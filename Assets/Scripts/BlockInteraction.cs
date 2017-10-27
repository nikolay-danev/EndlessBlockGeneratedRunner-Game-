using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInteraction : MonoBehaviour
{
    private bool isPlayerOnBlock;
    BlockManager blockManager;


    void Start()
    {
        blockManager = GameObject.Find("BlockManager").GetComponent<BlockManager>();
    }

    void Update()
    {
        if(isPlayerOnBlock == true)
        {
            Invoke("Drown", 0.3f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isPlayerOnBlock = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            blockManager.SpawnBlocks();
        }
    }
    void Drown()
    {
        transform.position += -transform.up * 5 * Time.deltaTime;
        Destroy(gameObject, 2);
    }
}
