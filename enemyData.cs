using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyData : MonoBehaviour
{
    #region Variables

    public enum enemyState
    {
        //patrolling,
        //chasing,
        placeholderState,
        attacking,
        damage
    }

    //public playerData shieldData;

    [Header("Enemy State: ")]
    public enemyState currentState;

    [Header("Enemy Health: ")]
    public int maxHealth = 100;
    public int currentHealth;
    
    [Header("damage Effects: ")]
    public GameObject deathEffect;
    
    #endregion

    #region System Methods

   //Default Methods:
    private void awake()
    {
        
    }

    private void Start()
    {
        
        healthInitialize();
        //stateInitialise();
    }

    private void Update()
    {
        switchStates();
    }

    #endregion

    protected void switchStates()
    {
        switch(currentState)
        {
            /*
            case enemyState.patrolling:
            //Set 9 Waypoints for enemy to patrol
            patrolState();
            break;
            case enemyState.chasing:
            //Chase Player with pathfinder script
            chaseState();
            break;
            */
            case enemyState.placeholderState:

            break;
            case enemyState.attacking:
            attackState();
            break;
            case enemyState.damage:
            deadState();
            break;
            
        }
    }

    //Method Definitions
    //================
    protected void patrolState()
    {
        //Patrol 9 waypoints in the Arena
        //WIP
    }
    
    protected void chaseState()
    {
        //Chase Player Here
        //WIP

    }

    protected void attackState()
    {
        //Attack Player
        GameObject enemyClear = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(enemyClear, 1.0f);
        Destroy(gameObject);
        //Debug.Log("Died by attack");
    }

    protected void deadState()
    {
        Debug.Log("Enemy loss health");
        //Check health of enemy when taking damage
        //Destroy this game Object when dead
        currentHealth -= 100;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            //Debug.Log("Died");
        }
    }

    #region Collision Systems

    //Collision States
    //================

    protected void OnTriggerEnter2D(Collider2D collider)
    {
        /*
        if(collider.tag.Equals("Player"))
        {
            currentState = enemyState.chasing;
        }
        */
    }

    protected void OnTriggerExit2D(Collider2D collider)
    {
        /*
        if(collider.tag.Equals("Player"))
        {
            currentState = enemyState.patrolling;
        }
        */
    } 

    protected void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.CompareTag("Player") || collision.collider.CompareTag("Shields"))
        {
            //Debug.Log("Attacking");
            currentState = enemyState.attacking;

        }
        else if(collision.collider.CompareTag("bullet01(Player)"))
        {
            currentState = enemyState.damage;
        }
    
    }

    #endregion

    #region Initialization Methods

    //Initialize States
    //=================
    
    protected void stateInitialise()
    {
        currentState = enemyState.placeholderState;
    }
    
    protected void healthInitialize()
    {
        currentHealth = maxHealth;
    }

    #endregion

}
/*
    AI Destination Setter
    myScript = gameObject.GetComponent<AI Destination Setter>();

*/