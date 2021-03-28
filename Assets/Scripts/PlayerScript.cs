using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject launcherRotator;
    public GameObject launcher;
    
    public GameObject playerCamera;

    public AudioClip rocketLaunch;
    public AudioClip launcherMovingFX;

    public float healthPoints = 100f;
    
    private float rotationSpeed = 100f;


    void Update()
    {
    
        float rotatorZPos = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float launcherXPos = -Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;

        launcherRotator.transform.Rotate(0f, 0f, rotatorZPos);
        launcher.transform.Rotate(launcherXPos, 0f, 0f);

        if(Input.GetButtonDown("Jump")){

            gameObject.GetComponent<AudioSource>().Play();

        }

        if(Input.GetButton("Jump"))
        {

            GameManager.instance.ChargeShot();

        }
        
        if (Input.GetButtonUp("Jump"))
        {

            GameManager.instance.Fire();
            gameObject.GetComponent<AudioSource>().Stop();
            gameObject.GetComponent<AudioSource>().PlayOneShot(rocketLaunch, 1f);


            
        }


    }

}