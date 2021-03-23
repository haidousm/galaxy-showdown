using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject launcherRotator;
    public GameObject launcher;
    
    public GameObject playerCamera;

    private float rotationSpeed = 100f;
    


    void Update()
    {

        float rotatorZPos = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float launcherXPos = -Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
        
        launcherRotator.transform.Rotate(0f, 0f, rotatorZPos);
        launcher.transform.Rotate(launcherXPos, 0f, 0f);
      
        if(Input.GetButton("Jump"))
        {

            GameManager.instance.ChargeShot();

        }
        
        if (Input.GetButtonUp("Jump"))
        {

            GameManager.instance.Fire();

            
        }

    }

}