using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    public GameObject currentBlock;
    public static BlockManager instance;
    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            SpawnBlocks();
        }
    }

    void Update()
    {

    }

    public void SpawnBlocks()
    {
        int randomIndex = Random.Range(0, 2);
        currentBlock = Instantiate(blockPrefabs[randomIndex], currentBlock.transform.GetChild(0).transform.GetChild(randomIndex).position, Quaternion.identity);
    }
}
