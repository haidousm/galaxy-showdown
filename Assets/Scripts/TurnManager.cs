using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{ 
    
    public GameObject player1, player2;
    private int currentPlayer;
    
    private int player1Time = 5;
    private int player2Time = 5;

    private int numberOfTurns = 0;
    private int maxTurns = 6;

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

        StartCoroutine("_SwitchPlayer");
        return currentPlayer;

    }

    public IEnumerator _SwitchPlayer(){
        
        player1Time = 5;
        player2Time = 5;
        GameManager.instance.UpdateHUDTimer(0, player1Time);
        GameManager.instance.UpdateHUDTimer(1, player2Time);

        numberOfTurns++;
        if(numberOfTurns > maxTurns){

            GameManager.instance.GameOver(1);
            yield break;

        }

        if(currentPlayer == 0){

            currentPlayer = 1;

            player1.GetComponent<PlayerScript>().enabled = false;
            player2.GetComponent<PlayerScript>().enabled = true;

            player1.GetComponent<PlayerScript>().playerCamera.SetActive(false);
            player2.GetComponent<PlayerScript>().playerCamera.SetActive(true);

            while(player2Time > 0){

                if(Input.GetButton("Jump")){

                    yield break;

                }
                

                yield return new WaitForSeconds(1f);
                player2Time--;
                GameManager.instance.UpdateHUDTimer(1, player2Time);

            }

            SwitchPlayer();

        }else{

            currentPlayer = 0;

            player1.GetComponent<PlayerScript>().enabled = true;
            player2.GetComponent<PlayerScript>().enabled = false;

            player1.GetComponent<PlayerScript>().playerCamera.SetActive(true);
            player2.GetComponent<PlayerScript>().playerCamera.SetActive(false);

            while(player1Time > 0){

                if(Input.GetButton("Jump")){

                   
                    yield break;

                }
                
                yield return new WaitForSeconds(1f);
                player1Time--;
                GameManager.instance.UpdateHUDTimer(0, player1Time);

            }

            SwitchPlayer();
        }


    }


}
