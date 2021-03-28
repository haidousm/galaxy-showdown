using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFactory : MonoBehaviour
{   

    public GameObject rocket;
    public GameObject player1RocketSpawner;
    public GameObject player2RocketSpawner;

    public GameObject ship1RocketForward;
    public GameObject ship2RocketForward;

    private float rocketForce = 200f;
    private float chargingSpeed = 1000f;
    private float minForce = 200f;
    private float maxForce = 5000f;
    

    private void _RelocateRocket(Transform newTransform){
        
        rocket.transform.parent = newTransform;
        rocket.GetComponent<Rigidbody>().useGravity = false;
        rocket.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        Quaternion newRotation = newTransform.rotation;
        newRotation.eulerAngles = new Vector3(-90f, 0f, 0f);

        rocket.transform.position = newTransform.position;
        rocket.transform.rotation = newTransform.rotation;
    }

    public void RelocateRocket(int currentPlayer){

        
        if(currentPlayer == 0){

           _RelocateRocket(player1RocketSpawner.transform);
           
        }else{

           
            _RelocateRocket(player2RocketSpawner.transform);
            
        }

        rocket.GetComponent<RocketScript>().currentPlayer = currentPlayer;

    }

    public void Fire(int currentPlayer){

        rocket.GetComponent<Rigidbody>().useGravity = true;
        if(currentPlayer == 0){

            rocket.GetComponent<Rigidbody>().AddForce(ship1RocketForward.transform.forward * rocketForce);

        }else{

            rocket.GetComponent<Rigidbody>().AddForce(ship2RocketForward.transform.forward * rocketForce);
            

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
