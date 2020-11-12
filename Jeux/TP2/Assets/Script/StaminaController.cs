using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{

    [SerializeField]
    private Image staminaStats;
    
    public void DisplayStaminaStats(float staminaValue)
    {
        staminaValue /= 100f;

        staminaStats.fillAmount = staminaValue;
    }
}
