using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    public GameObject player1Ship;
    public GameObject player2Ship;

    private float minHealth = 0;
    private float maxHealth = 100;

    public float DamageShip(int currentPlayer, float damagePoints){
       
        if(currentPlayer == 0){

            player1Ship.GetComponent<PlayerScript>().healthPoints -= damagePoints;

            if(player1Ship.GetComponent<PlayerScript>().healthPoints <= minHealth){

                player1Ship.GetComponent<Animator>().enabled = true;
                GameManager.instance.GameOver();

            }

            return player1Ship.GetComponent<PlayerScript>().healthPoints / maxHealth;
         
        }else{

            player2Ship.GetComponent<PlayerScript>().healthPoints -= damagePoints;

            if(player2Ship.GetComponent<PlayerScript>().healthPoints <= minHealth){

                player2Ship.GetComponent<Animator>().enabled = true;
                GameManager.instance.GameOver();

            }

            return player2Ship.GetComponent<PlayerScript>().healthPoints / maxHealth;
        }

    }

}
