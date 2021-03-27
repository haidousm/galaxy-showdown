using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    public GameObject player1HUD;
    public GameObject player2HUD;
    public GameObject player1EnemyHUD;
    public GameObject player2EnemyHUD;

    public void ChargeUp(int currentPlayer, float fillAmount){

        if(currentPlayer == 0){

            player1HUD.transform.Find("ChargeBar").GetComponent<Image>().fillAmount = fillAmount;

        }else{

            player2HUD.transform.Find("ChargeBar").GetComponent<Image>().fillAmount = fillAmount;

        }

    }

    public void DecreaseHealth(int currentPlayer, float fillAmount){

        if(currentPlayer == 0){

            player1HUD.transform.Find("HealthBar").GetComponent<Image>().fillAmount = fillAmount;
            player2EnemyHUD.transform.Find("HealthBar").GetComponent<Image>().fillAmount = fillAmount;

        }else{

            player2HUD.transform.Find("HealthBar").GetComponent<Image>().fillAmount = fillAmount;
            player1EnemyHUD.transform.Find("HealthBar").GetComponent<Image>().fillAmount = fillAmount;

        }

    }

    public void Restart(){

        player1HUD.transform.Find("HealthBar").GetComponent<Image>().fillAmount = 1;
        player1EnemyHUD.transform.Find("HealthBar").GetComponent<Image>().fillAmount = 1;

        player2HUD.transform.Find("HealthBar").GetComponent<Image>().fillAmount = 1;
        player2EnemyHUD.transform.Find("HealthBar").GetComponent<Image>().fillAmount = 1;

    }

    
}
