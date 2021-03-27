using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    public GameObject player1Ship;
    public GameObject player2Ship;

    public GameObject hugeExplosion;
    public GameObject hugeFire;

    private float minHealth = 0;
    private float maxHealth = 100;

    public float DamageShip(int currentPlayer, float damagePoints){
       
        if(currentPlayer == 0){

            player1Ship.GetComponent<PlayerScript>().healthPoints -= damagePoints;

            if(player1Ship.GetComponent<PlayerScript>().healthPoints <= minHealth){

               // player1Ship.GetComponent<Animator>().enabled = true;

                GameManager.instance.GameOver();

            }

            return player1Ship.GetComponent<PlayerScript>().healthPoints / maxHealth;
         
        }else{

            player2Ship.GetComponent<PlayerScript>().healthPoints -= damagePoints;

            if(player2Ship.GetComponent<PlayerScript>().healthPoints <= minHealth){

                GameManager.instance.GameOver();

            }

            return player2Ship.GetComponent<PlayerScript>().healthPoints / maxHealth;
        }

    }

    public void ActivateShield(int currentPlayer){

        if(currentPlayer == 0){

            player1Ship.transform.Find("Shield").gameObject.SetActive(true);
            player1Ship.tag = "Untagged";
           
        }else{

            player2Ship.transform.Find("Shield").gameObject.SetActive(true);
            player2Ship.tag = "Untagged";
        }


    }

    public void DeactivateShield(int currentPlayer){

        if(currentPlayer == 0){

            player1Ship.transform.Find("Shield").gameObject.SetActive(true);
            player1Ship.tag = "Ship_1";

           
        }else{

            player2Ship.transform.Find("Shield").gameObject.SetActive(true);
            player2Ship.tag = "Ship_1";

        }


    }

    public void Blow(int currentPlayer){

        if(currentPlayer == 0){

            Instantiate(hugeExplosion, player2Ship.transform.position, Quaternion.identity);
            Instantiate(hugeFire, player2Ship.transform.position, Quaternion.identity);
           
            
        }else{

            Instantiate(hugeExplosion, player1Ship.transform.position, Quaternion.identity);
            Instantiate(hugeFire, player1Ship.transform.position, Quaternion.identity);

        }

    }

    public void Restart(){

        player1Ship.GetComponent<PlayerScript>().healthPoints = maxHealth;
        player2Ship.GetComponent<PlayerScript>().healthPoints = maxHealth;

       

    }

}
