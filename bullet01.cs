﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet01 : MonoBehaviour
{
public GameObject hitEffect;

    private void Update(){

        Destroy(gameObject, 5f);
    
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {

        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1);
        Destroy(gameObject);
    
    }
}
