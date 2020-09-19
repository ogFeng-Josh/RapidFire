using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon01 : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    
    //[HideInInspector]
    public int bulletForce = 5;

    void Update(){
        
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    
    public void updateSpeed(int attackSpd)
    {
        bulletForce = bulletForce + attackSpd;
    }
    

}
