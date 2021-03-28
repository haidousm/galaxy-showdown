using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{

    public GameObject smallExplosion;
    public GameObject smokeEffect;

    public float damagePoints = 40f;
    
    private IEnumerator OnCollisionEnter(Collision other) {


        //other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(power, transform.position, radius, 3.0F);
      
        GameObject explosion = Instantiate(smallExplosion, transform.position, Quaternion.identity);
        Instantiate(smokeEffect, transform.position, Quaternion.identity);
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

        }
        

    }

}
