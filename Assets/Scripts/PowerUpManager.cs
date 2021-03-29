using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    // -1: boss fight
    // 0: shield
    // 1: meteor shower
    List<int> powerups = new List<int>(new int[]{1});

    public void GrantPowerUp(){

        System.Random random = new System.Random();
        int powerUpIdx = random.Next(powerups.Count);
        int powerUp = powerups[powerUpIdx];

        powerups.RemoveAt(powerUpIdx);
       
        switch (powerUp)
        {
            case -1:
                // spawn boss
                break;
            case 0:
                GameManager.instance.ActivateShield();
                break;
            case 1:
                GameManager.instance.MeteorRocket(1);
                
                break;
            default:
                break;
        }

    }

}
