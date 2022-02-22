using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ainda nao funciona
public class TimerBarManager : MonoBehaviour
{
    private const float PU_BAR_FILLED = 0.8f;

    private RectTransform powerUpTimerTransform;

    public float fill;

    private void Awake()
    {
        powerUpTimerTransform = transform.Find("/SpaceShip/CanvasUIPowerUpTimer/PowerUpTimerBar/PUBarFilled").GetComponent<RectTransform>();
    }

    private void Update()
    {
        //SetTimer();
    }

    public void SetTimer(float timer)
    {
        fill = (timer - Time.time) / 10; //PRECISO TRANFORMAR ESSE FLOAT ENTRE 0.0 E 1
        
        powerUpTimerTransform.sizeDelta = new Vector2(fill * PU_BAR_FILLED, powerUpTimerTransform.sizeDelta.y);

        if (powerUpTimerTransform.sizeDelta.x == 0) //preciso rever 
        {
            powerUpTimerTransform.gameObject.SetActive(false);

            //fill = Time.time;
        }
    }
}
