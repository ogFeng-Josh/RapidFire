using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPowerUp : MonoBehaviour
{
    #region Variables

    public playerData p1;

    #endregion

    #region Method Initialization
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #endregion

    #region Collision System

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.collider.CompareTag("Player"))
        {
            Debug.Log("Detected Player");
            p1.addHealth(15);
            Destroy(gameObject);
        }




    }


    #endregion

}
