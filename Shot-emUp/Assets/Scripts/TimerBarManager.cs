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

    private float maxTimer;
    private float currentTime;
    private int currentPowerUp;

    private void Start()
    {
        //allCanvas = GameObject.FindGameObjectsWithTag("PowerUpBar");

        //allFillAmount = GameObject.FindGameObjectsWithTag("FillAmount");
        
        powerUpTimerManager = GetComponent<PowerUpManager>();

        spawnManager = GetComponent<PlayerSpawnManager>();

        for (int i = 0; i < allCanvas.Length; i++)
            allCanvas[i].gameObject.SetActive(false);
    }

    private void Update()
    {
        TurnOnTimeBar();
    }

    private void TurnOnTimeBar()   //como fazer pra inverter?
    {
        if (powerUpTimerManager.hasPowerUp && !spawnManager.isDead)
        {
            allCanvas[currentPowerUp].gameObject.SetActive(true);
            SettingTimer();
        }
        else
        {
            allCanvas[allCanvas.Length -1].gameObject.SetActive(false);
            currentTime = GettingTimer(null);
        }
    }

    public float GettingTimer(string powerUp) // um pouco bugado mas funciona.
    {                                         // pegar 2 PU buga muito
        switch (powerUp)                      // pegar o mesmo não reinicia o currentTime p/ MaxTime
        {
            case "Bullet": //liga o canvas[0]
                currentTime = powerUpTimerManager._bulletsPowerUpTimer;
                currentPowerUp = 0;
                break;

            case "Shield": //liga o canvas[1]
                currentTime = powerUpTimerManager._shieldPowerUpTimer;
                currentPowerUp = 1;
                break;

            case "Speed": //liga o canvas[2]
                currentTime = powerUpTimerManager._speedPowerUpTimer;
                currentPowerUp = 2;
                break;

            case null:
                break;              
        }

        return currentTime;
    }

    private void SettingTimer()
    {
        float fillAmout = allFillAmount[currentPowerUp].GetComponent<Image>().fillAmount;

        maxTimer = powerUpTimerManager.maxPowerUpTimer;

        currentTime -= Time.deltaTime;

        Debug.LogWarning(fillAmout);

        if (currentTime < 0) { return; }

        if (spawnManager.isDead) { return; }

        fillAmout = currentTime / maxTimer;
        allFillAmount[currentPowerUp].GetComponent<Image>().fillAmount = fillAmout;
        Debug.Log(fillAmout);
    }



    
    // criar lista com os 3 allCanvas
    //independente do power up, sempre ligar o primeiro e ir na ordem

    // para cada allCanvas um maxTimer, currentTime e fillAmout

    // dar cor especifica para cada power up


}
