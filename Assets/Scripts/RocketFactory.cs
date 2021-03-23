using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFactory : MonoBehaviour
{   

    public GameObject rocket;
    public GameObject player1RocketSpawner;
    public GameObject player2RocketSpawner;

    private float rocketForce = 200f;
    private float chargingSpeed = 400f;
    private float minForce = 200f;
    private float maxForce = 2000f;
    

    private void _RelocateBullet(Transform newTransform){
        
        rocket.transform.parent = newTransform;
        rocket.GetComponent<Rigidbody>().useGravity = false;
        rocket.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        Quaternion newRotation = newTransform.rotation;
        newRotation.eulerAngles = new Vector3(-90f, 0f, 0f);

        rocket.transform.position = newTransform.position;
        rocket.transform.rotation = newTransform.rotation;
    }

    public void RelocateBullet(int currentPlayer){

        
        if(currentPlayer == 0){

           _RelocateBullet(player1RocketSpawner.transform);
           
        }else{

           
              _RelocateBullet(player2RocketSpawner.transform);
            
        }

    }

    public void Fire(int currentPlayer){

        rocket.GetComponent<Rigidbody>().useGravity = true;
        if(currentPlayer == 0){

            rocket.GetComponent<Rigidbody>().AddForce(Quaternion.Euler(90f, 0, 0) * rocket.transform.forward * rocketForce);

        }else{

            rocket.GetComponent<Rigidbody>().AddForce(Quaternion.Euler(-90f, 0, 0) * rocket.transform.forward * rocketForce);
            

        }

        rocketForce = minForce;
       
    }

    public float ChargeShot(){

        if(rocketForce < maxForce){

            rocketForce += chargingSpeed * Time.deltaTime;

        }

        return rocketForce / maxForce;
       
    }
    
}
