using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public HUDManager HUDManager;
    public TurnManager turnManager;
    public ShipManager shipManager;
    public RocketFactory rocketFactory;

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
        for (int i = 0; i < 6; i++)
        {

            if(Input.anyKey){

                break;

            }

            yield return new WaitForSeconds(0.5f);
        }
        
        yield return new WaitForSeconds(0.3f);
        if(gameOver){

            yield break;

        }
        currentPlayer = turnManager.SwitchPlayer();
        DisableOverHead();
        rocketFactory.RelocateRocket(currentPlayer);


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

    public void ActivateShield(int _currentPlayer){

        shipManager.ActivateShield(_currentPlayer);

    }

    public void DeactivateShield(int _currentPlayer){

        shipManager.DeactivateShield(_currentPlayer);

    }

    public void GameOver(){

        gameOver = true;
        StartCoroutine("_GameOver");

    }

    private IEnumerator _GameOver(){

        yield return new WaitForSeconds(0.3f);
        EnableOverHead();
        shipManager.Blow(currentPlayer);
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        menu.gameObject.SetActive(true);

    }

   
}
