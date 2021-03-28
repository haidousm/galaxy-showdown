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

                GameManager.instance.UpdateScore(1);
                GameManager.instance.GameOver(0);

            }

            return player1Ship.GetComponent<PlayerScript>().healthPoints / maxHealth;
         
        }else{

            player2Ship.GetComponent<PlayerScript>().healthPoints -= damagePoints;

            if(player2Ship.GetComponent<PlayerScript>().healthPoints <= minHealth){

                GameManager.instance.UpdateScore(1);
                GameManager.instance.GameOver(0);

            }

            return player2Ship.GetComponent<PlayerScript>().healthPoints / maxHealth;
        }

    }

    public void ActivateShield(int currentPlayer){

        StartCoroutine(_ActivateShield(currentPlayer));

    }

    private IEnumerator _ActivateShield(int currentPlayer){

        if(currentPlayer == 0){

            player1Ship.transform.Find("Shield").gameObject.SetActive(true);
            player1Ship.tag = "Untagged";

            yield return new WaitForSeconds(8f);

            player1Ship.transform.Find("Shield").gameObject.SetActive(false);
            player1Ship.tag = "Ship_1";
           
        }else{

            player2Ship.transform.Find("Shield").gameObject.SetActive(true);
            player2Ship.tag = "Untagged";

            yield return new WaitForSeconds(8f);

            player2Ship.transform.Find("Shield").gameObject.SetActive(false);
            player2Ship.tag = "Ship_2";

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
