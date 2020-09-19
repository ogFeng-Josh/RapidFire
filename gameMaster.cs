using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMaster : MonoBehaviour
{

    #region Variables
    [Header("Player's Attack System: ")]
    //Attack Speed/Damage
    //Adjust Player's Damage & Atk Speed
    public int attackSpeed = 0;
    
    [Header("Player's Health: ")]
    //Health
    //Adjusts and sets player's health
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Player's Shield: ")]
    //Shield
    //Shields give player protection from one collision hit 
    protected int maxLayer = 3;
    public int currentLayer = 1;
    public GameObject[] shieldLayer;

    #region IGNORE
    /*
    //Script Import
    //public static gameMaster instanceGM;
    private playerData atkspdScript;

    [Header("Player's Currency")]
    public Text coinTxt;
    public int plCoins;


    [Header("Player Assets:")]
    public Text speedlvlDisplay;
    public Text reqcoinDisplay;
    public int attackSpd = 0;
    private int requiredCoin = 1;

    //[Header("Other Assets")]
    //public GameObject scriptObject01;
    public GameObject wp01;
    private playerData wpnSpd;
    */
    #endregion
    #endregion

    void Awake()
    {
        //wpnSpd = wp01.GetComponent<playerData>();
        
    

    }
    
    void Start()
    {
        
    }

    public void Update()
    {
        /*
        speedAtkUpdate();
        currencyUpdate();
        upgradeCost01();
        */
    }

    #region IGNOREMETHODS
    /*
    void currencyUpdate()
    {
        coinTxt.text = "Coins: " + plCoins;
    }

    void upgradeCost01()
    {
        reqcoinDisplay.text = "Required Coins: " + requiredCoin;
    }

    void speedAtkUpdate()
    {
        speedlvlDisplay.text = "Atk Speed lvl: " + attackSpd; 
    }

    public void upgrade01()
    {
        if(plCoins >= requiredCoin)
        {
        attackSpd = attackSpd + 1;
        plCoins = plCoins - requiredCoin;
        requiredCoin += 2;
        wpnSpd.bulletForce += attackSpd;
        }
    }
    */
    #endregion
}

