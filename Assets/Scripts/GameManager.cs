using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public HUDManager HUDManager;
    public TurnManager turnManager;
    public ShipManager shipManager;
    public RocketFactory rocketFactory;
    public PowerUpManager powerUpManager;

    public GameObject overHeadCamera;
    public GameObject menu;
    private int currentPlayer;

    private bool gameOver = false;

    void Awake() {

        if(instance == null){

            instance = this;

        }else{

            Destroy(gameObject);

        }
        
    }

    public void StartGame(){

        RestartGame();
        SwitchPlayer();
       

        overHeadCamera.SetActive(false);

    }

    public void SwitchPlayer(){

        currentPlayer = turnManager.SwitchPlayer();
        RelocateRocket();

    }


    public void Fire(){

        StartCoroutine("_Fire");

    }

    private IEnumerator _Fire(){

        turnManager.DisablePlayers();

        rocketFactory.Fire(currentPlayer);
        HUDManager.ChargeUp(currentPlayer, 1);

        yield return new WaitForSeconds(0.5f);

        EnableOverHead();

        yield return new WaitForSeconds(5f);
        if(gameOver){

            yield break;

        }

        SwitchPlayer();
        DisableOverHead();

    }

    public void ChargeShot(){

        float currentChargeRatio = rocketFactory.ChargeShot();
        HUDManager.ChargeUp(currentPlayer, currentChargeRatio);

    }

    public void DamageShip(int player, float damagePoints){

     

        float currentHealthRatio = shipManager.DamageShip(player, damagePoints);
        HUDManager.DecreaseHealth(player, currentHealthRatio);

    }

    public void EnableOverHead(){

        turnManager.DisableCameras();
        overHeadCamera.SetActive(true);

    }

    public void DisableOverHead(){

        turnManager.EnableCameras();
        overHeadCamera.SetActive(false);

    }

    public void RestartGame(){

        HUDManager.Restart();
        shipManager.Restart();

        GameObject[] effects = GameObject.FindGameObjectsWithTag("VFX");
        for(int i = 0 ; i < effects.Length; i++){

            Destroy(effects[i]);

        }

        menu.gameObject.transform.Find("Title").gameObject.GetComponent<Text>().text = "Galaxy Showdown";
        
    }

    public void GameOver(int overReason){

        // 0: enemy destroyed
        // 1: turns exhausted

        gameOver = true;
        StartCoroutine(_GameOver(overReason));

    }

    private IEnumerator _GameOver(int overReason){

        // 0: Player 1
        // 1: Player 2
        // -1: Tie

        int winner = turnManager.GetWinner();
        yield return new WaitForSeconds(0.3f);

        EnableOverHead();

        if(overReason == 0){

            shipManager.Blow(currentPlayer);
            gameObject.GetComponent<AudioSource>().Play();

        }

        yield return new WaitForSeconds(0.5f);
        menu.gameObject.SetActive(true);

        if(winner != -1){

            menu.gameObject.transform.Find("Title").GetComponent<Text>().text = "Player " + (winner + 1) + " Won";

        }

    }

    public void UpdateHUDTimer(int secondsRemaining){

        HUDManager.UpdateTimer(currentPlayer, secondsRemaining);

    }

    public void UpdateScore(int scoreKey){

        int newScore = turnManager.UpdateScore(scoreKey);
        HUDManager.UpdateScore(currentPlayer, newScore);
        
    }

    public void RelocateRocket(){

        rocketFactory.RelocateRocket(currentPlayer);

    }

    public void GrantPowerUp(){

        powerUpManager.GrantPowerUp();

    }

    public void MeteorRocket(int powerUp){

        rocketFactory.MeteorRocket(currentPlayer, powerUp);
        
    }

   
}
