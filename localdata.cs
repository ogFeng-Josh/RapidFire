using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localdata
{
    [Header("Local Save:")]
    //testversion 01
    //public string playerOne; //Player Name (Will implement Name Input when possible)
    public int atkSpeed;     //Player Bullet Force Speed
    public int moveSpeed;    //Player Movement Speed

    public localdata (playerData playerdata01)
    {
        
        moveSpeed = playerdata01.moveSpeed;
        atkSpeed = playerdata01.bulletForce;

    }


}
