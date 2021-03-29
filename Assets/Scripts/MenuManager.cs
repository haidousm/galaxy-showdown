using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button StartGame;
    public Button RestartGame;

    void Start()
    {
      
      StartGame.onClick.AddListener(()=> {
          GameManager.instance.StartGame();  
          gameObject.SetActive(false);
        });
        
    }
}
