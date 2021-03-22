using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject launcherRotator;
    public GameObject launcher;
    public GameObject rocketSpawner;
    public GameObject rocketPrefab;

    private float rotationSpeed = 100.0f;
    private float maxForce = 10000f;
    private float chargingSpeed = 2000f;

    private float rocketForce = 500f;


    void Update()
    {

        float rotatorZPos = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float launcherXPos = -Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
        
        launcherRotator.transform.Rotate(0f, 0f, rotatorZPos);
        launcher.transform.Rotate(launcherXPos, 0f, 0f);

        if (Input.GetButtonDown("Jump"))
        {

            if (rocketForce < maxForce)
            {
                
                rocketForce += chargingSpeed * Time.deltaTime;
                

            }
            
            
        }else if (Input.GetButtonUp("Jump"))
        {

            Fire();
            rocketForce = 500f;

        }

    }

    void Fire()
    {
        
        Quaternion rocketRotation = new Quaternion();
        rocketRotation.eulerAngles = new Vector3(-90f, 0f, 0f);
        GameObject rocket = Instantiate(rocketPrefab, rocketSpawner.transform.position, rocketRotation);
        rocket.GetComponent<Rigidbody>().AddForce(rocketSpawner.transform.forward * rocketForce);
        
    }
}