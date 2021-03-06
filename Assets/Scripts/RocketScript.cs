using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{

    public GameObject smallExplosion;
    public GameObject smokeEffect;
    public GameObject meteorRain;

    public AudioClip meteorRainFX;

    public float damagePoints = 20f;

    public int currentPlayer = 0;

    public int powerUp = -1;
    public int powerUpPlayer = -1;

    bool firstHit = true;
    
    private IEnumerator OnCollisionEnter(Collision other) {
      
        GameObject smoke = Instantiate(smokeEffect, transform.position, Quaternion.identity);
        if(powerUpPlayer != currentPlayer){

            GameObject explosion = Instantiate(smallExplosion, transform.position, Quaternion.identity);
            gameObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(0.5f);
            Destroy(explosion);
        }

        if(powerUpPlayer == currentPlayer){

            if(powerUp == 1){ // meteor shower

                GameObject meteor = Instantiate(meteorRain, transform.position, Quaternion.identity);
                gameObject.GetComponent<AudioSource>().PlayOneShot(meteorRainFX, 1f);
                yield return new WaitForSeconds(3f);
                Destroy(meteor);

                powerUpPlayer = -1;
                powerUp = -1;
                GameManager.instance.ClearPowerups();
                damagePoints = 50f;

            }

        }


        if(other.gameObject.tag == "Ship_1"){

            GameManager.instance.DamageShip(0, damagePoints);
            GameManager.instance.UpdateScore(0);

        }else if(other.gameObject.tag == "Ship_2"){

            GameManager.instance.DamageShip(1, damagePoints);
            GameManager.instance.UpdateScore(0);

        }else if(other.gameObject.tag == "Large_Drone"){

            Destroy(smoke);
            if(firstHit){
                
                firstHit = false;
                yield break;

            }
            Transform drone = other.gameObject.transform.Find("Drone");
            if(drone != null){

                Destroy(drone.gameObject);

            }
           
            
            GameObject powerUp = other.gameObject.transform.Find("Powerup").gameObject;

            powerUp.GetComponent<Rigidbody>().useGravity = true;
            powerUp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            yield return new WaitForSeconds(1f);
            other.gameObject.SetActive(false);

            GameManager.instance.GrantPowerUp();
            GameManager.instance.UpdateScore(3);


       }else if(other.gameObject.tag == "Small_Drone"){

            Destroy(smoke);
            Transform drone = other.gameObject.transform.Find("Drone");
            if(drone != null){

                Destroy(drone.gameObject);

            }
           
            
            GameObject powerUp = other.gameObject.transform.Find("Powerup").gameObject;

            powerUp.GetComponent<Rigidbody>().useGravity = true;
            powerUp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            yield return new WaitForSeconds(1f);
            other.gameObject.SetActive(false);
            

            GameManager.instance.GrantPowerUp();
            GameManager.instance.UpdateScore(2);
       
        }else{

            Destroy(smoke);

        }

        gameObject.SetActive(false);
        damagePoints = 20;

    }

}
