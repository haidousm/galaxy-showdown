using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    // -1: boss fight
    // 0: shield
    // 1: super powerful rocket
    List<int> powerups = new List<int>(new int[]{-1, 0, 0, 0, 0, 1, 1});

    public void GrantPowerUp(int currentPlayer){

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
                // give shield to player
                break;
            case 1:
                // increase rocket size and power
                break;
            default:
                break;
        }

    }

}
