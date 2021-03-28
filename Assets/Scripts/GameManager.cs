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
        currentPlayer = turnManager.SwitchPlayer();
        rocketFactory.RelocateRocket(currentPlayer);

        overHeadCamera.SetActive(false);

    }

    public void Fire(){

        StartCoroutine("_Fire");

    }

    private IEnumerator _Fire(){

        rocketFactory.Fire(currentPlayer);
        HUDManager.ChargeUp(currentPlayer, 1);
        turnManager.DisablePlayers();
        yield return new WaitForSeconds(0.3f);
        EnableOverHead();
        yield return new WaitForSeconds(4f);
        if(gameOver){

            yield break;

        }
        currentPlayer = turnManager.SwitchPlayer();
        DisableOverHead();
        RelocateRocket();

    }

    public void ChargeShot(){

        float currentChargeRatio = rocketFactory.ChargeShot();
        HUDManager.ChargeUp(currentPlayer, currentChargeRatio);

    }

    public void DamageShip(int _currentPlayer, float damagePoints){

        float currentHealthRatio = shipManager.DamageShip(_currentPlayer, damagePoints);
        HUDManager.DecreaseHealth(_currentPlayer, currentHealthRatio);
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
        yield return new WaitForSeconds(1f);
        menu.gameObject.SetActive(true);

        if(winner != -1){

            menu.gameObject.transform.Find("Title").GetComponent<Text>().text = "Player " + (winner + 1) + " Won";

        }

    }

    public void UpdateHUDTimer(int _currentPlayer, int secondsRemaining){

        HUDManager.UpdateTimer(_currentPlayer, secondsRemaining);

    }

    public void UpdateScore(int _currentPlayer, int scoreKey){

        int newScore = turnManager.UpdateScore(_currentPlayer, scoreKey);
        HUDManager.UpdateScore(_currentPlayer, newScore);
        
    }

    public void RelocateRocket(){

        rocketFactory.RelocateRocket(currentPlayer);

    }

    public void GrantPowerUp(int _currentPlayer){

        powerUpManager.GrantPowerUp(_currentPlayer);

    }

    public void MeteorRocket(int _currentPlayer, int powerUp){

        rocketFactory.MeteorRocket(currentPlayer, powerUp);

    }

   
}
