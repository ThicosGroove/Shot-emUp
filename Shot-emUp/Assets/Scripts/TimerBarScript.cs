using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBarScript : MonoBehaviour
{
    private const float PU_BAR_FILLED = 30f;

    private RectTransform powerUpTimerTransform;

    public PowerUpManager powerUpManager;

    public float fill;

    private void Awake()
    {
        powerUpTimerTransform = transform.Find("/Canvas/PowerUpTimerBar/PUBarFilled").GetComponent<RectTransform>();
    }

    private void Start()
    {
       
    }

    private void Update()
    {
        SetTimer();
    }

    public void SetTimer()
    {
        fill = powerUpManager._speedPowerUpTimer - Time.time; //PRECISO TRANFORMAR ESSE FLOAT ENTRE 0.0 E 1

        
        powerUpTimerTransform.sizeDelta = new Vector2(fill * PU_BAR_FILLED, powerUpTimerTransform.sizeDelta.y);
    }
}
