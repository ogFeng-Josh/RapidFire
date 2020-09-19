using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerData : MonoBehaviour
{
    #region Variables

    //Initializing Data Scripts
    public healthBarScript healthBar; //Declare's health assets in Inspector

    //Player Data:

    [Header("Player Health: ")]
    //Health
    //Adjusts and sets player's health
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Player Shield: ")]
    //Shield
    //Shields give player protection from one collision hit 
    protected int maxLayer = 3;
    public int currentLayer;
    public GameObject[] shieldLayer;

    [Header("Player Movement: ")]
    //Movement
    //Alters player's movement control & speed
    public int moveSpeed = 3;
    public Rigidbody2D rb1;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    [Header("Bullets Projectiles: ")]
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int bulletForce = 5;

    [Header("Game Manger Assets: ")]
    public GameObject playerDead;
    public bool PlayerIsDead = false;


    #endregion

    #region System Methods

    //Default Methods:
    private void awake()
    {
        
    }

    private void Start()
    {
        //Initializes shield data PLACEHOLDER
        //currentLayer = 1;

        //Initializes health data
        healthInitialize();
        //Initializes shield data
        shieldInitialize();

    }

    private void Update()
    {

        //Player Movements
        pmovementUpdate();

        //Player Bullets
        Shoot();

        //Player Dead
        if(currentHealth <= 0)
        {
            PlayerIsDead = true;
            lossScene();
        }

        if(PlayerIsDead == false)
        {
            Time.timeScale = 1.0f;
        }

    }

    #endregion

    //DEBUG Health System
    protected void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }

    protected void FixedUpdate()
    {
        //Player Movements
        rb1.MovePosition(rb1.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb1.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb1.rotation = angle;


    }

    //Update Methods:
    //===============
    public void lossScene()
    {
        Time.timeScale = 0.0f;
        playerDead.SetActive(true);
    }

    public void updateSpeed(int attackSpd)
    {
        bulletForce = bulletForce + attackSpd;
    }

    protected void Shoot()
    {

        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    public void changeTime()
    {
        PlayerIsDead = false;
    }

    //Collision Check
    //===============
    protected void OnCollisionEnter2D(Collision2D collision)
    {


        if(collision.collider.CompareTag("Enemy"))
        {
            //Set layer that minuses one layer if active
            //Minus health if no layers detected
            takeDamage(15);

        }
        else if(collision.collider.CompareTag("Enemy2"))
        {
            takeDamage(25);
        }

    }

    /*
    protected void OnCollisionEnter2D(Collision2D collisionDamage)
    {

    }
    */

    #region Method Initialization
    //Data Initialization 
    //===================

    public void addHealth(int health)
    {
        //Debug.Log("Added health!");
        currentHealth += health;

        healthBar.setHealth(currentHealth);
    }

    protected void shieldDamage()
    {

        int i = 1;
        ++i;
        Destroy(shieldLayer[i]);

        if(i <= -1)
        {
            takeDamage(15);
        }

    }

    protected void healthInitialize()
    {
        currentHealth = maxHealth;    
        healthBar.setMaxHealth(maxHealth);
    }

    protected void shieldInitialize()
    {
        for(int i = 0; i < 3; i++)
        {
            shieldLayer[i].SetActive(false);
        }

        if(currentLayer == 3)
        {
            for(int i = 0; i < currentLayer; i++)
            {
                shieldLayer[i].SetActive(true);
            }
        }
        else if(currentLayer == 2)
        {
            for(int i = 0; i < currentLayer; i++)
            {
                shieldLayer[i].SetActive(true);
            }
        }
        else if(currentLayer == 1)
        {
            for(int i = 0; i < currentLayer; i++)
            {
                shieldLayer[i].SetActive(true);
            }
        }
    }
    
    protected void pmovementUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    #endregion

    #region Database
    //==================

    //Save System DATABASE

    //When Player quits the game, set this up torwards Saving Data
    public void SavePlayer()
    {
        Debug.Log("Player's Data Saved!");
        saveSystem.SavePlayer(this);
    }
    //When Player starts the game, set this up torwards loading data
    //Have this set up as "Press any key to Continue..." Scene
    public void LoadPlayer()
    {
        Debug.Log("Player's Data Loaded!");
        localdata data = saveSystem.LoadPlayer();

        moveSpeed = data.moveSpeed;

    }

    //=================
    #endregion
}
