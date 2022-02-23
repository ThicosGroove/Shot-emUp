using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBarManager : MonoBehaviour
{
    [SerializeField] private GameObject[] allCanvas;
    [SerializeField] private GameObject[] allFillAmount;
    private PowerUpManager powerUpTimerManager;
    private PlayerSpawnManager spawnManager;

    private float fillAmount;
    private float[] maxTimer = { 1, 2, 3};
    private float[] currentTime = { 1, 2, 3 };
    private int currentPowerUp;

    private void Start()
    {       
        powerUpTimerManager = GetComponent<PowerUpManager>();

        spawnManager = GetComponent<PlayerSpawnManager>();

        for (int i = 0; i < allCanvas.Length; i++)
            allCanvas[i].gameObject.SetActive(false);
    }

    private void Update()
    {
        TurnOnTimeBar();
    }

    private void TurnOnTimeBar()
    {
        if (powerUpTimerManager.hasPowerUp )
        {
            allCanvas[currentPowerUp].gameObject.SetActive(true);
            SettingTimer();
        }
        else if (fillAmount < 0.001f)
        {
            allCanvas[currentPowerUp].gameObject.SetActive(false);
        }
    }            
    
                                              // um pouco bugado mas funciona.
                                              // pegar 2 PowerUps buga muito.
    public float GettingTimer(string powerUp) // pegar o mesmo não reinicia o Coroutine
    {                                         // infelizmente só consegui fazer funcionar direitinho 
        switch (powerUp)                      // com 1 Power Up de uma vez. 
        {                                                   
            case "Bullet": //liga o canvas[0]

                currentPowerUp = 0;
                currentTime[0] = powerUpTimerManager._bulletsPowerUpTimer;
                break;

            case "Shield": //liga o canvas[1]

                currentPowerUp = 1;
                currentTime[1] = powerUpTimerManager._shieldPowerUpTimer;
                break;

            case "Speed": //liga o canvas[2]

                currentPowerUp = 2;
                currentTime[2] = powerUpTimerManager._speedPowerUpTimer;
                break;

            case null:
                break;              
        }

        return currentTime[currentPowerUp];
    }

    private void SettingTimer()
    {
        fillAmount = allFillAmount[currentPowerUp].GetComponent<Image>().fillAmount;

        maxTimer[0] = powerUpTimerManager.maxBulletTimer;
        maxTimer[1] = powerUpTimerManager.maxShieldTimer;
        maxTimer[2] = powerUpTimerManager.maxSpeedTimer;

        currentTime[currentPowerUp] -= Time.deltaTime;

        if (currentTime[currentPowerUp] <= 0) { return; }

        if (spawnManager.isDead) { return; }

        fillAmount = currentTime[currentPowerUp] / maxTimer[currentPowerUp];
        
        allFillAmount[currentPowerUp].GetComponent<Image>().fillAmount = fillAmount;
    }



}
