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

    private int currentPlayer;

    void Awake() {

        if(instance == null){

            instance = this;

        }else{

            Destroy(gameObject);

        }
        
    }

    void Start() {

        currentPlayer = turnManager.SwitchPlayer();
        rocketFactory.RelocateBullet(currentPlayer);

        overHeadCamera.SetActive(false);
        
    }

    public void Fire(){

        StartCoroutine("_Fire");

    }

    private IEnumerator _Fire(){

        rocketFactory.Fire(currentPlayer);
        HUDManager.ChargeUp(currentPlayer, 1);
        turnManager.DisablePlayers();

        yield return new WaitForSeconds(3);
        currentPlayer = turnManager.SwitchPlayer();
        rocketFactory.RelocateBullet(currentPlayer);

    }

    public void ChargeShot(){

        float currentChargeRatio = rocketFactory.ChargeShot();
        HUDManager.ChargeUp(currentPlayer, currentChargeRatio);

    }

    public void DamageShip(int _currentPlayer, float damagePoints){

        float currentHealthRatio = shipManager.DamageShip(_currentPlayer, damagePoints);
        HUDManager.DecreaseHealth(_currentPlayer, currentHealthRatio);
    }

    public void GameOver(){

        turnManager.DisableCameras();
        overHeadCamera.SetActive(true);

    }

   
}
