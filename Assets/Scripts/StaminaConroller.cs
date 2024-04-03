using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaConroller : MonoBehaviour
{
    public static StaminaConroller instance;
    [SerializeField] private Image _fuelImage;
    [SerializeField, Range(0.1f,5f)] private float _fuelDrainSpeed = 1f;
    [SerializeField] private float _maxFuelAmount = 100f;
    

    private float _currentFuelAmount;
  

    private void Awake()
    {   if (instance == null)
        {
            instance = this;
        }
       

    }
    private void Start()
    {
        _currentFuelAmount=_maxFuelAmount;
        UpdateUI();
    }
    private void UpdateUI()
    {
        _fuelImage.fillAmount= (_currentFuelAmount/_maxFuelAmount);
    }
    private void Update()
    {
        _currentFuelAmount-=Time.deltaTime*_fuelDrainSpeed;
        UpdateUI();
        if (_currentFuelAmount <= 0)
        {
            _currentFuelAmount = 0;
            UpdateUI();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
    public float GetCurrentFuelAmount()
    {
        return _currentFuelAmount;
    }

    public void RefillStamina()
    {
        _currentFuelAmount = _maxFuelAmount;
        UpdateUI();
    }
   
}
