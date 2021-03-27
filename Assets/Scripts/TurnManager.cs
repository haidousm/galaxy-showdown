using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{ 
    
    public GameObject player1, player2;
    private int currentPlayer;

    void Start()
    {

        currentPlayer = Random.Range(0, 2);
        
    }

    public void DisablePlayers(){

        player1.GetComponent<PlayerScript>().enabled = false;
        player2.GetComponent<PlayerScript>().enabled = false;

    }

    public void DisableCameras(){

        player1.GetComponent<PlayerScript>().playerCamera.SetActive(false);
        player2.GetComponent<PlayerScript>().playerCamera.SetActive(false);

    }

     public void EnableCameras(){

        player1.GetComponent<PlayerScript>().playerCamera.SetActive(true);
        player2.GetComponent<PlayerScript>().playerCamera.SetActive(true);

    }

    public int SwitchPlayer(){
        
        if(currentPlayer == 0){

            currentPlayer = 1;

            player1.GetComponent<PlayerScript>().enabled = false;
            player2.GetComponent<PlayerScript>().enabled = true;

            player1.GetComponent<PlayerScript>().playerCamera.SetActive(false);
            player2.GetComponent<PlayerScript>().playerCamera.SetActive(true);

        }else{

            currentPlayer = 0;

            player1.GetComponent<PlayerScript>().enabled = true;
            player2.GetComponent<PlayerScript>().enabled = false;

            player1.GetComponent<PlayerScript>().playerCamera.SetActive(true);
            player2.GetComponent<PlayerScript>().playerCamera.SetActive(false);


        }

        return currentPlayer;
    }
}
