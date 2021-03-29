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

    public Sprite meteorSprite;
    public Sprite shieldSprite;

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

    public void UpdateTimer(int currentPlayer, int secondsRemaining){

        if(currentPlayer == 0){

            player1HUD.transform.Find("TurnTimer").GetComponent<Text>().text = "00:0" + secondsRemaining;

        }else{

            player2HUD.transform.Find("TurnTimer").GetComponent<Text>().text = "00:0" + secondsRemaining;

        }

    }

    public void UpdateScore(int currentPlayer, int newScore){

         if(currentPlayer == 0){

            player1HUD.transform.Find("Score").GetComponent<Text>().text = "Score: " + newScore;

        }else{

            player2HUD.transform.Find("Score").GetComponent<Text>().text = "Score: " + newScore;

        }

    }

    public void MeteorRocket(int currentPlayer){

        if(currentPlayer == 0){

            player1HUD.transform.Find("PowerUp").GetComponent<Image>().sprite = meteorSprite;
            player1HUD.transform.Find("PowerUp").GetComponent<Image>().color = new Color(255, 255, 255, 1f);

        }else{

            player2HUD.transform.Find("PowerUp").GetComponent<Image>().sprite = meteorSprite;
            player2HUD.transform.Find("PowerUp").GetComponent<Image>().color = new Color(255, 255, 255, 1f);

        }

    }

    public void ActivateShield(int currentPlayer){

        if(currentPlayer == 0){
            
            player1HUD.transform.Find("PowerUp").GetComponent<Image>().sprite = shieldSprite;
            player1HUD.transform.Find("PowerUp").GetComponent<Image>().color = new Color(255, 255, 255, 1f);

        }else{

            player2HUD.transform.Find("PowerUp").GetComponent<Image>().sprite = shieldSprite;
            player2HUD.transform.Find("PowerUp").GetComponent<Image>().color = new Color(255, 255, 255, 1f);

        }

    }

    public void ClearPowerups(){

         player1HUD.transform.Find("PowerUp").GetComponent<Image>().color = new Color(255, 255, 255, 0f);
         player2HUD.transform.Find("PowerUp").GetComponent<Image>().color = new Color(255, 255, 255, 0f);

    }

    
}
