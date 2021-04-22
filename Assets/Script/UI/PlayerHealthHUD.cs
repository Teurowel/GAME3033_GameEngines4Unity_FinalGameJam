using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthHUD : MonoBehaviour
{
    Image healthSlider;
    [SerializeField] Stats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider = GetComponent<Image>();

        //Subscribe this event
        playerStats.OnHealthChanged.AddListener(OnHealthChangedCallback);
    }

    void OnHealthChangedCallback(float health, float maxHealth)
    {
        //Calculate healthPercent and set it to ui
        float healthPercent = health / maxHealth;
        healthSlider.fillAmount = healthPercent;
    }
}
