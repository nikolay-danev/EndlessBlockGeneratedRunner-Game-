using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public MeshFilter LeftBlock;
    public MeshFilter RightBlock;

    public Mesh Lava;
    public Mesh Ice;
    public Mesh Stone;
    public Mesh Grass;
    public Mesh Dirt;

    private bool isBlockIce;
    private bool isBlockStone;
    private bool isBlockGrass;
    private bool isBlockDirt;
    private bool isBlockLava;

    ScoreManager gold;

    void Start()
    {
        gold = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();   
    }

    public void BuyIceBlock()
    {
        if(gold.gold >= 300)
        {
            isBlockIce = true;
            LeftBlock.mesh = Ice;
            RightBlock.mesh = Ice;
            gold.gold -= 300;
            PlayerPrefs.SetInt("gold", gold.gold);
        }      
    }
    public void BuyStoneBlock()
    {
        if (gold.gold >= 600)
        {
            isBlockStone = true;
            LeftBlock.mesh = Stone;
            RightBlock.mesh = Stone;
            gold.gold -= 600;
            PlayerPrefs.SetInt("gold", gold.gold);
        }       
    }
    public void BuyGrassStone()
    {
        if (gold.gold >= 900)
        {
            isBlockGrass = true;
            LeftBlock.mesh = Grass;
            RightBlock.mesh = Grass;
            gold.gold -= 900;
            PlayerPrefs.SetInt("gold", gold.gold);
        }      
    }
    public void BuyDirtStone()
    {
        if (gold.gold >= 1200)
        {
            isBlockDirt = true;
            LeftBlock.mesh = Dirt;
            RightBlock.mesh = Dirt;
            gold.gold -= 1200;
            PlayerPrefs.SetInt("gold", gold.gold);
        }      
    }
    public void BuyLavaBlock()
    {
        if (gold.gold >= 1500)
        {
            isBlockLava = true;
            LeftBlock.mesh = Lava;
            RightBlock.mesh = Lava;
            gold.gold -= 1500;
            PlayerPrefs.SetInt("gold", gold.gold);
        }
    }
}
