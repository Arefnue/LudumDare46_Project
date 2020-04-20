using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    #region Singleton
    
    public static HealthManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    #endregion
    
    public float maxHealth;
    public float currentHealth;
    public Slider healthSlider;
    public Slider energySlider;

    public float maxEnergy;
    public float currentEnergy;
    public float consumeEnergyWhenSwap;
    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.value = currentHealth;
        currentEnergy = 50f;
        energySlider.value = currentEnergy;
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DecreaseEnergy(consumeEnergyWhenSwap);
        }
    }

    public void DecreaseEnergy(float value)
    {
        currentEnergy -= value;
        energySlider.value = Mathf.MoveTowards(energySlider.value, 0, value);
        if (currentEnergy <= 0)
        {
            currentEnergy = 0;
        }
    }

    public void IncreaseEnergy(float value)
    {
        currentEnergy += value;
        
        energySlider.value = Mathf.MoveTowards(energySlider.value, maxEnergy, value);
        
        if (currentEnergy >= maxEnergy)
        {
            currentEnergy = maxEnergy;
            GameManager.instance.OnWin();
            
        }
    }

    
    

    public void TakeDamage(float value)
    {
        currentHealth -= value;
        healthSlider.value = Mathf.MoveTowards(healthSlider.value, 0, value);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameManager.instance.OnLost();
        }
    }

    public void Heal(float value)
    {
        currentHealth += value;
        
        healthSlider.value = Mathf.MoveTowards(healthSlider.value, maxHealth, value);
        
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

}
