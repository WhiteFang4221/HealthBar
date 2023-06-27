using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        Player.OnHealthMaxSet += SetMaxHealth;
        Player.OnHealthChanged += SetHealth;
    }
    private void Start()
    {
        _slider = GetComponent<Slider>();
    }
    private void OnDestroy()
    {
        Player.OnHealthMaxSet -= SetMaxHealth; 
        Player.OnHealthChanged -= SetHealth;
    }

    private void SetHealth(int health)
    {
        _slider.value = health;
    }

    private void SetMaxHealth(int maxHealth)
    {
        _slider.maxValue = maxHealth;
        _slider.value = maxHealth;
    }
}
