using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{

    public GameObject smallExplosion;
    public GameObject smokeEffect;

    public float damagePoints = 40f;

    public int currentPlayer = 0;
    
    private IEnumerator OnCollisionEnter(Collision other) {


        //other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(power, transform.position, radius, 3.0F);
      
        GameObject explosion = Instantiate(smallExplosion, transform.position, Quaternion.identity);
        GameObject smoke = Instantiate(smokeEffect, transform.position, Quaternion.identity);
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.3f);
        Destroy(explosion);
        GameManager.instance.RelocateRocket();

        if(other.gameObject.tag == "Ship_1"){

            GameManager.instance.DamageShip(0, -damagePoints);
            GameManager.instance.UpdateScore(1, 0);

        }else if(other.gameObject.tag == "Ship_2"){

            GameManager.instance.DamageShip(1, -damagePoints);
            GameManager.instance.UpdateScore(0, 0);

        }else if(other.gameObject.tag == "Powerup_Drone"){

            GameObject drone = other.gameObject.transform.Find("Drone").gameObject;
            Destroy(drone);
            GameObject powerUp = other.gameObject.transform.Find("Powerup").gameObject;
            powerUp.GetComponent<Rigidbody>().useGravity = true;
            powerUp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            yield return new WaitForSeconds(1f);
            other.gameObject.SetActive(false);
            Destroy(smoke);
            GameManager.instance.GrantPowerUp(currentPlayer);
       
        }
        

    }

}
