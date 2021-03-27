using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public float damagePoints = 40f;
    private void OnCollisionEnter(Collision other) {

        if(other.gameObject.tag == "Ship_1"){

            GameManager.instance.DamageShip(0, -damagePoints);

        }else if(other.gameObject.tag == "Ship_2"){

            GameManager.instance.DamageShip(1, -damagePoints);

        }

    }

}
